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

  // Formulario de partida por clave
  const [claveBusqueda, setClaveBusqueda] = useState<string>("");
  const [cantidadDefecto, setCantidadDefecto] = useState<number>(1);
  const [errorProducto, setErrorProducto] = useState<string | null>(null);

  // Modal de Búsqueda por Nombre de Producto
  const [modalAbierto, setModalAbierto] = useState<boolean>(false);
  const [terminoBusquedaNombre, setTerminoBusquedaNombre] = useState<string>("");
  const [resultadosModal, setResultadosModal] = useState<Producto[]>([]);
  const inputModalRef = useRef<HTMLInputElement>(null);
  const inputClaveRef = useRef<HTMLInputElement>(null);

  // Modal de Búsqueda de Clientes
  const [modalClienteAbierto, setModalClienteAbierto] = useState<boolean>(false);
  const [terminoCliente, setTerminoCliente] = useState<string>("");
  const [clientesFiltradosModal, setClientesFiltradosModal] = useState<Cliente[]>([]);
  const inputClienteModalRef = useRef<HTMLInputElement>(null);

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

  // Función reutilizable para insertar producto directamente a la tabla
  const agregarProductoDirecto = (prod: Producto, cant: number = 1) => {
    const cantValida = cant > 0 ? cant : 1;
    const precioUnitario = prod.precio_Venta_1 || 0;
    
    // Si el producto ya está en la lista, aumentamos la cantidad
    setPartidas((prevPartidas) => {
      const idxExistente = prevPartidas.findIndex(
        (p) => p.claveProducto.toLowerCase() === prod.clave.toLowerCase()
      );

      if (idxExistente >= 0) {
        const actualizadas = [...prevPartidas];
        const partidaActual = actualizadas[idxExistente];
        const nuevaCant = Number((partidaActual.cantidad + cantValida).toFixed(2));
        const nuevoImporte = Number((nuevaCant * partidaActual.precioVenta - partidaActual.descuento).toFixed(2));
        
        actualizadas[idxExistente] = {
          ...partidaActual,
          cantidad: nuevaCant,
          importe: Math.max(0, nuevoImporte)
        };
        return actualizadas;
      } else {
        const nuevoImporte = Number((cantValida * precioUnitario).toFixed(2));
        const nuevaPartida: PartidaPedido = {
          claveProducto: prod.clave,
          nombreProducto: prod.producto,
          cantidad: cantValida,
          umVenta: prod.uM_Venta || "PZA",
          precioVenta: precioUnitario,
          descuento: 0,
          importe: Math.max(0, nuevoImporte)
        };
        return [nuevaPartida, ...prevPartidas];
      }
    });

    // Limpiar campo de clave y mantener foco
    setClaveBusqueda("");
    setErrorProducto(null);
    inputClaveRef.current?.focus();
  };

  // Buscar por clave al presionar Enter
  const buscarYAgregarPorClave = (e?: React.FormEvent) => {
    if (e) e.preventDefault();
    const clave = claveBusqueda.trim();
    if (!clave) return;

    const prod = productos.find(
      (p) => p.clave.toLowerCase() === clave.toLowerCase()
    );

    if (prod) {
      agregarProductoDirecto(prod, cantidadDefecto);
    } else {
      setErrorProducto(`No se encontró ningún producto con la clave "${clave}".`);
    }
  };

  const handleKeyDownClave = (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (e.key === "Enter") {
      e.preventDefault();
      buscarYAgregarPorClave();
    }
  };

  // Abrir Modal de Búsqueda de Clientes
  const abrirModalClientes = () => {
    setModalClienteAbierto(true);
    setTerminoCliente("");
    setClientesFiltradosModal(clientes.slice(0, 50));
    setTimeout(() => {
      inputClienteModalRef.current?.focus();
    }, 100);
  };

  const handleFiltrarClientesModal = (termino: string) => {
    setTerminoCliente(termino);
    const t = termino.toLowerCase().trim();
    if (!t) {
      setClientesFiltradosModal(clientes.slice(0, 50));
      return;
    }
    const filtrados = clientes.filter(
      (c) =>
        (c.vchNombre && c.vchNombre.toLowerCase().includes(t)) ||
        (c.vchRFC && c.vchRFC.toLowerCase().includes(t))
    );
    setClientesFiltradosModal(filtrados.slice(0, 50));
  };

  const seleccionarClienteDesdeModal = (c: Cliente) => {
    setClienteSeleccionado(c);
    setDiasCredito(c.intDiasCredito || 0);
    setModalClienteAbierto(false);
  };

  // Abrir Modal de Búsqueda de Productos
  const abrirModalBusqueda = () => {
    setModalAbierto(true);
    setTerminoBusquedaNombre("");
    setResultadosModal(productos.slice(0, 50));
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

  // Seleccionar producto desde el modal: lo manda DIRECTO a la tabla y cierra el modal
  const seleccionarDesdeModal = (p: Producto) => {
    agregarProductoDirecto(p, cantidadDefecto);
    setModalAbierto(false);
  };

  // Modificar cantidad o descuento en la tabla directamente
  const handleActualizarCantidadEnTabla = (index: number, nuevaCantidad: number) => {
    if (nuevaCantidad <= 0) return;
    setPartidas((prev) => {
      const actualizadas = [...prev];
      const p = actualizadas[index];
      const imp = Number((nuevaCantidad * p.precioVenta - p.descuento).toFixed(2));
      actualizadas[index] = {
        ...p,
        cantidad: nuevaCantidad,
        importe: Math.max(0, imp)
      };
      return actualizadas;
    });
  };

  const handleActualizarDescuentoEnTabla = (index: number, nuevoDescuento: number) => {
    if (nuevoDescuento < 0) return;
    setPartidas((prev) => {
      const actualizadas = [...prev];
      const p = actualizadas[index];
      const imp = Number((p.cantidad * p.precioVenta - nuevoDescuento).toFixed(2));
      actualizadas[index] = {
        ...p,
        descuento: nuevoDescuento,
        importe: Math.max(0, imp)
      };
      return actualizadas;
    });
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
        setMensajeExito(`¡Pedido registrado exitosamente! Folio: ${res.idPedido}`);
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
          <p className="text-sm text-slate-500 mt-0.5">Captura directa por clave o búsqueda por nombre al instante</p>
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
          <div className="flex items-center justify-between mb-1.5">
            <label className="text-xs font-bold text-slate-600 uppercase tracking-wider">Cliente ({clientes.length})</label>
            <button
              type="button"
              onClick={abrirModalClientes}
              className="text-xs text-blue-600 hover:text-blue-800 font-bold flex items-center gap-1 transition"
            >
              <svg className="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z" />
              </svg>
              Buscar Cliente
            </button>
          </div>
          <select
            value={clienteSeleccionado?.pK_Id_Cliente || 0}
            onChange={(e) => {
              const c = clientes.find((x) => x.pK_Id_Cliente === Number(e.target.value)) || null;
              setClienteSeleccionado(c);
              setDiasCredito(c?.intDiasCredito || 0);
            }}
            className="w-full px-3.5 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white transition"
          >
            {clientes.map((c) => (
              <option key={c.pK_Id_Cliente} value={c.pK_Id_Cliente}>
                {c.vchNombre} (Crédito: {c.intDiasCredito || 0} días)
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

      {/* Barra de Captura Rápida de Producto (Envío Automático a la Tabla) */}
      <div className="bg-white border border-slate-200 rounded-2xl p-6 shadow-xs space-y-3">
        <form onSubmit={buscarYAgregarPorClave} className="grid grid-cols-1 md:grid-cols-12 gap-3 items-end">
          <div className="md:col-span-2">
            <label className="block text-xs font-bold text-slate-600 uppercase tracking-wider mb-1.5">
              Cantidad
            </label>
            <input
              type="number"
              min="0.01"
              step="any"
              value={cantidadDefecto}
              onChange={(e) => setCantidadDefecto(Number(e.target.value))}
              className="w-full px-3.5 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 text-sm font-semibold focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white text-center transition"
            />
          </div>

          <div className="md:col-span-7">
            <div className="flex items-center justify-between mb-1.5">
              <label className="text-xs font-bold text-slate-600 uppercase tracking-wider">
                Ingresa Clave (Enter para agregar)
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
                onKeyDown={handleKeyDownClave}
                placeholder="Escribe la clave del producto y presiona Enter..."
                className="w-full px-4 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 font-mono text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white transition"
              />
            </div>
          </div>

          <div className="md:col-span-3">
            <button
              type="submit"
              className="w-full py-2.5 bg-blue-600 hover:bg-blue-700 text-white font-bold text-sm rounded-xl shadow-xs transition flex items-center justify-center gap-1.5"
            >
              <svg className="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 4v16m8-8H4" />
              </svg>
              Agregar Producto
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

      {/* Tabla de Partidas con edición directa */}
      <div className="bg-white border border-slate-200 rounded-2xl overflow-hidden shadow-xs">
        <table className="w-full text-left text-sm text-slate-700">
          <thead className="bg-slate-50 text-xs uppercase text-slate-500 border-b border-slate-200">
            <tr>
              <th className="px-6 py-3.5 font-bold">Clave</th>
              <th className="px-6 py-3.5 font-bold">Producto</th>
              <th className="px-6 py-3.5 font-bold text-center w-28">Cant.</th>
              <th className="px-6 py-3.5 font-bold text-right">Precio</th>
              <th className="px-6 py-3.5 font-bold text-right w-28">Desc. ($)</th>
              <th className="px-6 py-3.5 font-bold text-right">Importe</th>
              <th className="px-6 py-3.5 font-bold text-center">Acción</th>
            </tr>
          </thead>
          <tbody className="divide-y divide-slate-100">
            {partidas.length === 0 ? (
              <tr>
                <td colSpan={7} className="px-6 py-12 text-center text-slate-400 text-sm font-medium">
                  No hay artículos agregados. Ingresa una clave o pulsa &quot;Buscar por Nombre&quot;.
                </td>
              </tr>
            ) : (
              partidas.map((p, idx) => (
                <tr key={idx} className="hover:bg-slate-50/80 transition">
                  <td className="px-6 py-3.5 font-mono text-blue-600 font-bold text-xs">{p.claveProducto}</td>
                  <td className="px-6 py-3.5 font-medium text-slate-900">{p.nombreProducto}</td>
                  <td className="px-6 py-3.5 text-center">
                    <input
                      type="number"
                      min="0.01"
                      step="any"
                      value={p.cantidad}
                      onChange={(e) => handleActualizarCantidadEnTabla(idx, Number(e.target.value))}
                      className="w-20 px-2 py-1 bg-slate-50 border border-slate-300 rounded-lg text-slate-900 text-xs font-semibold text-center focus:outline-none focus:ring-1 focus:ring-blue-600 focus:bg-white"
                    />
                  </td>
                  <td className="px-6 py-3.5 text-right font-medium text-slate-600">${p.precioVenta.toFixed(2)}</td>
                  <td className="px-6 py-3.5 text-right">
                    <input
                      type="number"
                      min="0"
                      step="any"
                      value={p.descuento}
                      onChange={(e) => handleActualizarDescuentoEnTabla(idx, Number(e.target.value))}
                      className="w-20 px-2 py-1 bg-slate-50 border border-slate-300 rounded-lg text-slate-900 text-xs font-semibold text-right focus:outline-none focus:ring-1 focus:ring-blue-600 focus:bg-white"
                    />
                  </td>
                  <td className="px-6 py-3.5 text-right font-black text-slate-900">${p.importe.toFixed(2)}</td>
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
                <p className="text-xs text-slate-500 mt-0.5">Haz clic sobre cualquier producto para agregarlo automáticamente al pedido</p>
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
            <div className="flex-1 overflow-y-auto p-4 space-y-1.5 divide-y divide-slate-100">
              {resultadosModal.length === 0 ? (
                <div className="py-12 text-center text-slate-400 text-sm">
                  No se encontraron productos que coincidan con &quot;{terminoBusquedaNombre}&quot;.
                </div>
              ) : (
                resultadosModal.map((p) => (
                  <div
                    key={p.id}
                    onClick={() => seleccionarDesdeModal(p)}
                    className="p-3 rounded-xl hover:bg-blue-50 border border-transparent hover:border-blue-200 cursor-pointer flex items-center justify-between transition group"
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
                    <div className="text-right flex items-center gap-4">
                      <span className="text-base font-extrabold text-emerald-600">
                        ${Number(p.precio_Venta_1).toFixed(2)}
                      </span>
                      <span className="px-3 py-1.5 bg-blue-600 hover:bg-blue-700 text-white text-xs font-bold rounded-lg shadow-xs transition">
                        + Agregar
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
      {/* PANTALLA EMERGENTE (MODAL) PARA BÚSQUEDA DE CLIENTES */}
      {modalClienteAbierto && (
        <div className="fixed inset-0 z-50 flex items-center justify-center p-4 bg-slate-900/40 backdrop-blur-xs">
          <div className="bg-white rounded-2xl shadow-2xl border border-slate-200 w-full max-w-2xl flex flex-col max-h-[85vh] animate-in fade-in zoom-in-95 duration-150">
            {/* Cabecera del Modal */}
            <div className="p-5 border-b border-slate-100 flex items-center justify-between">
              <div>
                <h3 className="text-lg font-bold text-slate-900">Buscar Cliente</h3>
                <p className="text-xs text-slate-500 mt-0.5">Selecciona el cliente para aplicar sus días de crédito</p>
              </div>
              <button
                type="button"
                onClick={() => setModalClienteAbierto(false)}
                className="w-8 h-8 rounded-full bg-slate-100 hover:bg-slate-200 text-slate-600 flex items-center justify-center font-bold text-sm transition"
              >
                ✕
              </button>
            </div>

            {/* Input de Búsqueda */}
            <div className="p-5 border-b border-slate-100 bg-slate-50">
              <div className="relative">
                <input
                  ref={inputClienteModalRef}
                  type="text"
                  value={terminoCliente}
                  onChange={(e) => handleFiltrarClientesModal(e.target.value)}
                  placeholder="Escribe el nombre o RFC del cliente..."
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

            {/* Lista de Clientes */}
            <div className="flex-1 overflow-y-auto p-4 space-y-1.5 divide-y divide-slate-100">
              {clientesFiltradosModal.length === 0 ? (
                <div className="py-12 text-center text-slate-400 text-sm">
                  No se encontraron clientes que coincidan con &quot;{terminoCliente}&quot;.
                </div>
              ) : (
                clientesFiltradosModal.map((c) => (
                  <div
                    key={c.pK_Id_Cliente}
                    onClick={() => seleccionarClienteDesdeModal(c)}
                    className="p-3 rounded-xl hover:bg-blue-50 border border-transparent hover:border-blue-200 cursor-pointer flex items-center justify-between transition group"
                  >
                    <div>
                      <p className="text-sm font-semibold text-slate-900 group-hover:text-blue-700 transition">
                        {c.vchNombre}
                      </p>
                      <p className="text-xs text-slate-400">
                        RFC: {c.vchRFC || "XAXX010101000"} &bull; Crédito: {c.intDiasCredito || 0} días
                      </p>
                    </div>
                    <span className="px-3 py-1.5 bg-blue-600 hover:bg-blue-700 text-white text-xs font-bold rounded-lg shadow-xs transition">
                      Seleccionar
                    </span>
                  </div>
                ))
              )}
            </div>

            {/* Pie del Modal */}
            <div className="p-4 border-t border-slate-100 bg-slate-50 flex items-center justify-between text-xs text-slate-500">
              <span>Mostrando {clientesFiltradosModal.length} clientes</span>
              <button
                type="button"
                onClick={() => setModalClienteAbierto(false)}
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
