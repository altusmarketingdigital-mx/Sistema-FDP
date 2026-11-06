"use client";

import { useEffect, useState, useRef } from "react";
import Link from "next/link";
import {
  fetchClientesApi,
  fetchProductosApi,
  guardarPedidoApi,
  Cliente,
  Producto,
  PartidaPedido
} from "@/lib/api";

export default function NuevoPedidoPage() {
  const [clientes, setClientes] = useState<Cliente[]>([]);
  const [productos, setProductos] = useState<Producto[]>([]);
  const [clienteSeleccionado, setClienteSeleccionado] = useState<Cliente | null>(null);

  // Formulario de partida
  const [claveBusqueda, setClaveBusqueda] = useState<string>("");
  const [productoSeleccionado, setProductoSeleccionado] = useState<Producto | null>(null);
  const [cantidad, setCantidad] = useState<number>(1);
  const [precio, setPrecio] = useState<number>(0);
  const [descuento, setDescuento] = useState<number>(0);
  const [errorProducto, setErrorProducto] = useState<string | null>(null);

  // Modal de Búsqueda por Nombre
  const [modalAbierto, setModalAbierto] = useState<boolean>(false);
  const [terminoBusquedaNombre, setTerminoBusquedaNombre] = useState<string>("");
  const [resultadosModal, setResultadosModal] = useState<Producto[]>([]);
  const [buscandoEnModal, setBuscandoEnModal] = useState<boolean>(false);
  const inputModalRef = useRef<HTMLInputElement>(null);
  const inputClaveRef = useRef<HTMLInputElement>(null);

  // Partidas del pedido
  const [partidas, setPartidas] = useState<PartidaPedido[]>([]);
  const [comentario, setComentario] = useState("");
  const [diasCredito, setDiasCredito] = useState(0);

  const [guardando, setGuardando] = useState(false);
  const [mensajeExito, setMensajeExito] = useState<string | null>(null);
  const [idPedidoGenerado, setIdPedidoGenerado] = useState<number | null>(null);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token) return;

    fetchClientesApi(token).then((data) => {
      setClientes(data);
      if (data.length > 0) {
        setClienteSeleccionado(data[0]);
        setDiasCredito(data[0].intDiasCredito || 0);
      }
    });

    fetchProductosApi(token).then((data) => {
      setProductos(data);
    });
  }, []);

  // Buscar por clave al presionar Enter o perder foco
  const buscarPorClave = (claveAValidar?: string) => {
    const clave = (claveAValidar !== undefined ? claveAValidar : claveBusqueda).trim();
    if (!clave) {
      setProductoSeleccionado(null);
      setErrorProducto(null);
      return;
    }

    const prod = productos.find(
      (p) => p.clave.toLowerCase() === clave.toLowerCase()
    );

    if (prod) {
      setProductoSeleccionado(prod);
      setPrecio(prod.precio_Venta_1 || 0);
      setErrorProducto(null);
    } else {
      setProductoSeleccionado(null);
      setErrorProducto(`No se encontró ningún producto con la clave "${clave}".`);
    }
  };

  const handleKeyDownClave = (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key === "Enter") {
      e.preventDefault();
      buscarPorClave();
    }
  };

  // Abrir Modal de Búsqueda por Nombre
  const abrirModalBusqueda = () => {
    setModalAbierto(true);
    setTerminoBusquedaNombre("");
    setResultadosModal(productos.slice(0, 50)); // Primeros 50 productos de arranque
    setTimeout(() => {
      inputModalRef.current?.focus();
    }, 100);
  };

  // Filtrar en el Modal
  const handleFiltrarPorNombre = (termino: string) => {
    setTerminoBusquedaNombre(termino);
    const t = termino.toLowerCase().trim();
    if (!t) {
      setResultadosModal(productos.slice(0, 50));
      return;
    }

    const filtrados = productos.filter(
      (p) =>
        p.producto.toLowerCase().includes(t) ||
        p.clave.toLowerCase().includes(t)
    );
    setResultadosModal(filtrados.slice(0, 50));
  };

  // Seleccionar producto desde el modal
  const seleccionarDesdeModal = (p: Producto) => {
    setProductoSeleccionado(p);
    setClaveBusqueda(p.clave);
    setPrecio(p.precio_Venta_1 || 0);
    setErrorProducto(null);
    setModalAbierto(false);
    inputClaveRef.current?.focus();
  };

  const handleCambioCliente = (idCliente: number) => {
    const c = clientes.find((x) => x.pK_Id_Cliente === idCliente) || null;
    setClienteSeleccionado(c);
    setDiasCredito(c?.intDiasCredito || 0);
  };

  const handleAgregarPartida = (e: React.FormEvent) => {
    e.preventDefault();
    if (!productoSeleccionado) {
      alert("Ingresa una clave válida o selecciona un producto por nombre.");
      return;
    }
    if (cantidad <= 0) {
      alert("La cantidad debe ser mayor a 0.");
      return;
    }

    const importe = (cantidad * precio) - descuento;
    const nuevaPartida: PartidaPedido = {
      claveProducto: productoSeleccionado.clave,
      nombreProducto: productoSeleccionado.producto,
      cantidad,
      umVenta: productoSeleccionado.uM_Venta || "PZA",
      precioVenta: precio,
      descuento,
      importe: Math.max(0, importe)
    };

    setPartidas([...partidas, nuevaPartida]);
    // Limpiar para siguiente captura
    setClaveBusqueda("");
    setProductoSeleccionado(null);
    setCantidad(1);
    setPrecio(0);
    setDescuento(0);
    setErrorProducto(null);
    inputClaveRef.current?.focus();
  };

  const handleEliminarPartida = (index: number) => {
    setPartidas(partidas.filter((_, i) => i !== index));
  };

  const totalPedido = partidas.reduce((acc, p) => acc + p.importe, 0);

  const handleGuardarPedido = async () => {
    if (!clienteSeleccionado) {
      alert("Selecciona un cliente.");
      return;
    }
    if (partidas.length === 0) {
      alert("Agrega al menos un producto a la lista.");
      return;
    }

    const token = localStorage.getItem("token");
    if (!token) return;

    setGuardando(true);
    setMensajeExito(null);

    try {
      const res = await guardarPedidoApi(token, {
        folio: "PED",
        idCliente: clienteSeleccionado.pK_Id_Cliente,
        diasCredito,
        metodoPago: diasCredito > 0 ? 2 : 1, // 1 = Contado, 2 = Crédito
        comentario,
        partidas
      });

      if (res.exito) {
        setIdPedidoGenerado(res.idPedido);
        setMensajeExito(`¡Pedido registrado exitosamente! ID Folio: ${res.idPedido}`);
        setPartidas([]);
        setComentario("");
      } else {
        alert(res.mensaje || "Error al registrar el pedido.");
      }
    } catch {
      alert("Error de red al guardar pedido.");
    } finally {
      setGuardando(false);
    }
  };

  return (
    <div className="space-y-6 max-w-6xl">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-slate-900 tracking-tight">Generar Nuevo Pedido</h1>
          <p className="text-sm text-slate-500 mt-0.5">Captura ágil por clave de producto o búsqueda por nombre</p>
        </div>
        <div className="flex items-center gap-3">
          <Link
            href="/dashboard/pedidos"
            className="px-4 py-2 bg-white hover:bg-slate-50 text-slate-700 text-xs font-semibold rounded-xl border border-slate-200 shadow-xs transition"
          >
            Ver Historial
          </Link>
        </div>
      </div>

      {mensajeExito && (
        <div className="p-4 bg-emerald-50 border border-emerald-200 text-emerald-800 rounded-2xl flex items-center justify-between shadow-xs">
          <div className="flex items-center gap-3">
            <span className="font-semibold text-sm">{mensajeExito}</span>
          </div>
          {idPedidoGenerado && (
            <a
              href={`/impresion/ticket/${idPedidoGenerado}`}
              target="_blank"
              className="px-4 py-1.5 bg-emerald-600 hover:bg-emerald-700 text-white text-xs font-bold rounded-lg shadow-sm transition"
            >
              Imprimir Ticket 80mm
            </a>
          )}
        </div>
      )}

      {/* Datos del Cliente y Condiciones */}
      <div className="bg-white border border-slate-200 rounded-2xl p-6 shadow-xs grid grid-cols-1 md:grid-cols-3 gap-5">
        <div>
          <label className="block text-xs font-bold text-slate-600 uppercase tracking-wider mb-1.5">Cliente</label>
          <select
            value={clienteSeleccionado?.pK_Id_Cliente || 0}
            onChange={(e) => handleCambioCliente(Number(e.target.value))}
            className="w-full px-3.5 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white transition"
          >
            {clientes.map((c) => (
              <option key={c.pK_Id_Cliente} value={c.pK_Id_Cliente}>
                {c.vchNombre || "Cliente General"} (Crédito: {c.intDiasCredito} días)
              </option>
            ))}
          </select>
        </div>

        <div>
          <label className="block text-xs font-bold text-slate-600 uppercase tracking-wider mb-1.5">Días de Crédito</label>
          <input
            type="number"
            value={diasCredito}
            onChange={(e) => setDiasCredito(Number(e.target.value))}
            className="w-full px-3.5 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white transition"
          />
        </div>

        <div>
          <label className="block text-xs font-bold text-slate-600 uppercase tracking-wider mb-1.5">Comentarios</label>
          <input
            type="text"
            value={comentario}
            onChange={(e) => setComentario(e.target.value)}
            placeholder="Nota o referencia de entrega..."
            className="w-full px-3.5 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white transition"
          />
        </div>
      </div>

      {/* Captura de Productos por Clave con Botón a Modal de Búsqueda */}
      <div className="bg-white border border-slate-200 rounded-2xl p-6 shadow-xs space-y-4">
        <form onSubmit={handleAgregarPartida} className="grid grid-cols-1 md:grid-cols-12 gap-3 items-end">
          {/* Campo de Clave */}
          <div className="md:col-span-3">
            <div className="flex items-center justify-between mb-1.5">
              <label className="text-xs font-bold text-slate-600 uppercase tracking-wider">
                Clave del Producto
              </label>
              <button
                type="button"
                onClick={abrirModalBusqueda}
                className="text-xs text-blue-600 hover:text-blue-800 font-bold flex items-center gap-1 transition"
              >
                <svg className="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" />
                </svg>
                Buscar por Nombre
              </button>
            </div>
            <div className="relative">
              <input
                ref={inputClaveRef}
                type="text"
                value={claveBusqueda}
                onChange={(e) => {
                  setClaveBusqueda(e.target.value);
                  setErrorProducto(null);
                }}
                onBlur={() => buscarPorClave()}
                onKeyDown={handleKeyDownClave}
                placeholder="Ej. 0001 (Enter para buscar)"
                className="w-full px-3.5 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 font-mono text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white transition"
              />
              <button
                type="button"
                onClick={() => buscarPorClave()}
                title="Validar Clave"
                className="absolute right-2 top-2 p-1 text-slate-400 hover:text-blue-600 transition"
              >
                <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 5l7 7-7 7" />
                </svg>
              </button>
            </div>
          </div>

          {/* Nombre / Descripción del Producto Detectado */}
          <div className="md:col-span-4">
            <label className="block text-xs font-bold text-slate-600 uppercase tracking-wider mb-1.5">
              Descripción del Producto
            </label>
            <div className={`px-3.5 py-2.5 rounded-xl border text-sm font-medium truncate flex items-center justify-between ${
              productoSeleccionado 
                ? "bg-blue-50/50 border-blue-200 text-slate-900" 
                : "bg-slate-100/60 border-slate-200 text-slate-400"
            }`}>
              <span>{productoSeleccionado ? productoSeleccionado.producto : "Introduce una clave o busca por nombre..."}</span>
              {productoSeleccionado && (
                <span className="text-[10px] font-bold px-2 py-0.5 rounded-full bg-blue-100 text-blue-700 shrink-0">
                  {productoSeleccionado.uM_Venta || "PZA"}
                </span>
              )}
            </div>
          </div>

          {/* Cantidad */}
          <div className="md:col-span-1">
            <label className="block text-xs font-bold text-slate-600 uppercase tracking-wider mb-1.5">Cant.</label>
            <input
              type="number"
              step={productoSeleccionado?.tiene_Decimal ? "0.01" : "1"}
              min="0.01"
              value={cantidad}
              onChange={(e) => setCantidad(Number(e.target.value))}
              className="w-full px-3 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white text-center transition"
            />
          </div>

          {/* Precio */}
          <div className="md:col-span-1">
            <label className="block text-xs font-bold text-slate-600 uppercase tracking-wider mb-1.5">Precio ($)</label>
            <input
              type="number"
              step="0.01"
              value={precio}
              onChange={(e) => setPrecio(Number(e.target.value))}
              className="w-full px-3 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white text-right transition"
            />
          </div>

          {/* Descuento */}
          <div className="md:col-span-1">
            <label className="block text-xs font-bold text-slate-600 uppercase tracking-wider mb-1.5">Desc. ($)</label>
            <input
              type="number"
              step="0.01"
              value={descuento}
              onChange={(e) => setDescuento(Number(e.target.value))}
              className="w-full px-3 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white text-right transition"
            />
          </div>

          {/* Botón Agregar */}
          <div className="md:col-span-2">
            <button
              type="submit"
              disabled={!productoSeleccionado}
              className="w-full py-2.5 bg-emerald-600 hover:bg-emerald-700 disabled:opacity-40 text-white font-bold text-sm rounded-xl shadow-xs transition flex items-center justify-center gap-1.5"
            >
              <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 4v16m8-8H4" />
              </svg>
              + Agregar
            </button>
          </div>
        </form>

        {errorProducto && (
          <div className="p-3 rounded-xl bg-amber-50 border border-amber-200 text-amber-800 text-xs flex items-center justify-between">
            <span>{errorProducto}</span>
            <button
              type="button"
              onClick={abrirModalBusqueda}
              className="font-bold underline text-amber-900 ml-2"
            >
              Buscar producto por nombre aquí
            </button>
          </div>
        )}
      </div>

      {/* Tabla de Partidas */}
      <div className="bg-white border border-slate-200 rounded-2xl overflow-hidden shadow-xs">
        <table className="w-full text-left text-sm text-slate-700">
          <thead className="bg-slate-50 text-xs uppercase text-slate-500 border-b border-slate-200">
            <tr>
              <th className="px-6 py-3.5 font-bold">Clave</th>
              <th className="px-6 py-3.5 font-bold">Producto</th>
              <th className="px-6 py-3.5 font-bold text-center">Cant.</th>
              <th className="px-6 py-3.5 font-bold text-right">Precio</th>
              <th className="px-6 py-3.5 font-bold text-right">Desc.</th>
              <th className="px-6 py-3.5 font-bold text-right">Importe</th>
              <th className="px-6 py-3.5 font-bold text-center">Acción</th>
            </tr>
          </thead>
          <tbody className="divide-y divide-slate-100">
            {partidas.length === 0 ? (
              <tr>
                <td colSpan={7} className="px-6 py-10 text-center text-slate-400 text-sm font-medium">
                  No hay artículos agregados al pedido.
                </td>
              </tr>
            ) : (
              partidas.map((p, idx) => (
                <tr key={idx} className="hover:bg-slate-50/80 transition">
                  <td className="px-6 py-3.5 font-mono text-blue-600 font-semibold text-xs">{p.claveProducto}</td>
                  <td className="px-6 py-3.5 font-medium text-slate-900">{p.nombreProducto}</td>
                  <td className="px-6 py-3.5 text-center text-slate-600">{p.cantidad} {p.umVenta}</td>
                  <td className="px-6 py-3.5 text-right font-medium text-slate-600">${p.precioVenta.toFixed(2)}</td>
                  <td className="px-6 py-3.5 text-right text-rose-600 font-medium">${p.descuento.toFixed(2)}</td>
                  <td className="px-6 py-3.5 text-right font-bold text-slate-900">${p.importe.toFixed(2)}</td>
                  <td className="px-6 py-3.5 text-center">
                    <button
                      onClick={() => handleEliminarPartida(idx)}
                      className="text-xs text-rose-600 hover:text-rose-800 font-bold px-2 py-1 rounded hover:bg-rose-50 transition"
                    >
                      Quitar
                    </button>
                  </td>
                </tr>
              ))
            )}
          </tbody>
        </table>

        {/* Resumen Total y Botón de Cobro */}
        <div className="p-6 bg-slate-50 border-t border-slate-200 flex flex-col md:flex-row items-center justify-between gap-4">
          <div className="text-sm text-slate-500 font-medium">
            Total de partidas: <span className="font-bold text-slate-900">{partidas.length}</span>
          </div>
          <div className="flex items-center gap-6">
            <div className="text-right">
              <span className="text-xs text-slate-400 block uppercase tracking-wider font-bold">Total a Pagar</span>
              <span className="text-3xl font-black text-emerald-600">${totalPedido.toFixed(2)}</span>
            </div>
            <button
              onClick={handleGuardarPedido}
              disabled={guardando || partidas.length === 0}
              className="px-8 py-3.5 bg-blue-600 hover:bg-blue-700 disabled:opacity-50 text-white font-bold text-base rounded-xl shadow-md shadow-blue-600/25 transition"
            >
              {guardando ? "Procesando..." : "Confirmar & Guardar Pedido"}
            </button>
          </div>
        </div>
      </div>

      {/* PANTALLA EMERGENTE (MODAL) PARA BÚSQUEDA POR NOMBRE */}
      {modalAbierto && (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-slate-900/40 backdrop-blur-xs">
          <div className="bg-white rounded-2xl shadow-2xl border border-slate-200 w-full max-w-3xl flex flex-col max-h-[85vh] animate-in fade-in zoom-in-95 duration-150">
            {/* Cabecera del Modal */}
            <div className="p-5 border-b border-slate-100 flex items-center justify-between">
              <div>
                <h3 className="text-lg font-bold text-slate-900">Buscar Producto por Nombre</h3>
                <p className="text-xs text-slate-500 mt-0.5">Escribe el nombre o descripción para filtrar el catálogo ({productos.length} productos)</p>
              </div>
              <button
                type="button"
                onClick={() => setModalAbierto(false)}
                className="w-8 h-8 rounded-full bg-slate-100 hover:bg-slate-200 text-slate-600 flex items-center justify-center font-bold text-sm transition"
              >
                ✕
              </button>
            </div>

            {/* Input de Búsqueda */}
            <div className="p-5 border-b border-slate-100 bg-slate-50">
              <div className="relative">
                <input
                  ref={inputModalRef}
                  type="text"
                  value={terminoBusquedaNombre}
                  onChange={(e) => handleFiltrarPorNombre(e.target.value)}
                  placeholder="Escribe el nombre del producto (ej. Manzana, Charola, Aceite)..."
                  className="w-full pl-10 pr-4 py-3 bg-white border border-slate-300 rounded-xl text-slate-900 text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:border-transparent shadow-xs transition"
                />
                <svg
                  className="w-5 h-5 text-slate-400 absolute left-3 top-3.5"
                  fill="none"
                  stroke="currentColor"
                  viewBox="0 0 24 24"
                >
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" />
                </svg>
              </div>
            </div>

            {/* Lista de Resultados */}
            <div className="flex-1 overflow-y-auto p-4 space-y-2 divide-y divide-slate-100">
              {resultadosModal.length === 0 ? (
                <div className="py-12 text-center text-slate-400 text-sm">
                  No se encontraron productos que coincidan con &quot;{terminoBusquedaNombre}&quot;.
                </div>
              ) : (
                resultadosModal.map((p) => (
                  <div
                    key={p.id}
                    onClick={() => seleccionarDesdeModal(p)}
                    className="p-3 pt-3.5 rounded-xl hover:bg-blue-50/80 border border-transparent hover:border-blue-200 cursor-pointer flex items-center justify-between transition group"
                  >
                    <div className="flex items-center gap-3">
                      <span className="px-2.5 py-1 rounded-lg bg-slate-100 font-mono text-xs font-bold text-slate-700 group-hover:bg-blue-600 group-hover:text-white transition">
                        {p.clave}
                      </span>
                      <div>
                        <p className="text-sm font-semibold text-slate-900 group-hover:text-blue-700 transition">
                          {p.producto}
                        </p>
                        <p className="text-xs text-slate-400">
                          Unidad: {p.uM_Venta || "PZA"}
                        </p>
                      </div>
                    </div>
                    <div className="text-right">
                      <span className="text-base font-extrabold text-emerald-600">
                        ${Number(p.precio_Venta_1).toFixed(2)}
                      </span>
                      <span className="block text-[10px] text-blue-600 font-bold opacity-0 group-hover:opacity-100 transition">
                        Seleccionar ↵
                      </span>
                    </div>
                  </div>
                ))
              )}
            </div>

            {/* Pie del Modal */}
            <div className="p-4 border-t border-slate-100 bg-slate-50 flex items-center justify-between text-xs text-slate-500">
              <span>Mostrando {resultadosModal.length} resultados</span>
              <button
                type="button"
                onClick={() => setModalAbierto(false)}
                className="px-4 py-2 bg-white hover:bg-slate-100 text-slate-700 font-semibold rounded-xl border border-slate-200 transition"
              >
                Cerrar
              </button>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}
