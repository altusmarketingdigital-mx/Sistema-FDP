"use client";

import { useEffect, useState } from "react";
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
  const [productoSeleccionado, setProductoSeleccionado] = useState<Producto | null>(null);
  const [cantidad, setCantidad] = useState<number>(1);
  const [precio, setPrecio] = useState<number>(0);
  const [descuento, setDescuento] = useState<number>(0);

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
      if (data.length > 0) {
        setProductoSeleccionado(data[0]);
        setPrecio(data[0].precio_Venta_1 || 0);
      }
    });
  }, []);

  const handleCambioCliente = (idCliente: number) => {
    const c = clientes.find((x) => x.pK_Id_Cliente === idCliente) || null;
    setClienteSeleccionado(c);
    setDiasCredito(c?.intDiasCredito || 0);
  };

  const handleCambioProducto = (idProducto: number) => {
    const p = productos.find((x) => x.id === idProducto) || null;
    setProductoSeleccionado(p);
    setPrecio(p?.precio_Venta_1 || 0);
  };

  const handleAgregarPartida = (e: React.FormEvent) => {
    e.preventDefault();
    if (!productoSeleccionado || cantidad <= 0) return;

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
    setCantidad(1);
    setDescuento(0);
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
          <p className="text-sm text-slate-500 mt-0.5">Captura ágil de venta en mostrador &bull; Conversión a Remisión / Ticket</p>
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

      {/* Captura de Productos */}
      <form onSubmit={handleAgregarPartida} className="bg-white border border-slate-200 rounded-2xl p-6 shadow-xs grid grid-cols-1 md:grid-cols-6 gap-4 items-end">
        <div className="md:col-span-2">
          <label className="block text-xs font-bold text-slate-600 uppercase tracking-wider mb-1.5">Producto</label>
          <select
            value={productoSeleccionado?.id || 0}
            onChange={(e) => handleCambioProducto(Number(e.target.value))}
            className="w-full px-3.5 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white transition"
          >
            {productos.map((p) => (
              <option key={p.id} value={p.id}>
                {p.clave} - {p.producto} (${Number(p.precio_Venta_1).toFixed(2)})
              </option>
            ))}
          </select>
        </div>

        <div>
          <label className="block text-xs font-bold text-slate-600 uppercase tracking-wider mb-1.5">Cantidad</label>
          <input
            type="number"
            step={productoSeleccionado?.tiene_Decimal ? "0.01" : "1"}
            min="0.01"
            value={cantidad}
            onChange={(e) => setCantidad(Number(e.target.value))}
            className="w-full px-3.5 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white transition"
          />
        </div>

        <div>
          <label className="block text-xs font-bold text-slate-600 uppercase tracking-wider mb-1.5">Precio ($)</label>
          <input
            type="number"
            step="0.01"
            value={precio}
            onChange={(e) => setPrecio(Number(e.target.value))}
            className="w-full px-3.5 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white transition"
          />
        </div>

        <div>
          <label className="block text-xs font-bold text-slate-600 uppercase tracking-wider mb-1.5">Descuento ($)</label>
          <input
            type="number"
            step="0.01"
            value={descuento}
            onChange={(e) => setDescuento(Number(e.target.value))}
            className="w-full px-3.5 py-2.5 bg-slate-50 border border-slate-300 rounded-xl text-slate-900 text-sm focus:outline-none focus:ring-2 focus:ring-blue-600 focus:bg-white transition"
          />
        </div>

        <div>
          <button
            type="submit"
            className="w-full py-2.5 bg-emerald-600 hover:bg-emerald-700 text-white font-bold text-sm rounded-xl shadow-xs transition"
          >
            + Agregar
          </button>
        </div>
      </form>

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
    </div>
  );
}
