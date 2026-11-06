"use client";

import { useEffect, useState } from "react";
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
    } catch (err: any) {
      alert("Error de red al guardar pedido.");
    } finally {
      setGuardando(false);
    }
  };

  return (
    <div className="space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-white">Generar Nuevo Pedido</h1>
          <p className="text-sm text-slate-400">Captura ágil de venta en mostrador &bull; Conversión a Remisión / Ticket</p>
        </div>
        <div className="flex items-center gap-3">
          <a
            href="/dashboard/pedidos"
            className="px-4 py-2 bg-slate-800 hover:bg-slate-700 text-slate-300 text-sm font-medium rounded-lg border border-slate-700 transition"
          >
            Ver Historial
          </a>
        </div>
      </div>

      {mensajeExito && (
        <div className="p-4 bg-emerald-500/10 border border-emerald-500/20 text-emerald-300 rounded-xl flex items-center justify-between">
          <div className="flex items-center gap-3">
            <span className="font-semibold">{mensajeExito}</span>
          </div>
          {idPedidoGenerado && (
            <a
              href={`/impresion/ticket/${idPedidoGenerado}`}
              target="_blank"
              className="px-4 py-1.5 bg-emerald-600 hover:bg-emerald-500 text-white text-xs font-semibold rounded-lg shadow transition"
            >
              Imprimir Ticket 80mm
            </a>
          )}
        </div>
      )}

      {/* Datos del Cliente y Condiciones */}
      <div className="bg-slate-900 border border-slate-800 rounded-xl p-5 grid grid-cols-1 md:grid-cols-3 gap-4">
        <div>
          <label className="block text-xs font-semibold text-slate-400 uppercase tracking-wider mb-2">Cliente</label>
          <select
            value={clienteSeleccionado?.pK_Id_Cliente || 0}
            onChange={(e) => handleCambioCliente(Number(e.target.value))}
            className="w-full px-3 py-2 bg-slate-950 border border-slate-700 rounded-lg text-white text-sm focus:outline-none focus:ring-2 focus:ring-emerald-500"
          >
            {clientes.map((c) => (
              <option key={c.pK_Id_Cliente} value={c.pK_Id_Cliente}>
                {c.vchNombre || "Cliente General"} (Crédito: {c.intDiasCredito} días)
              </option>
            ))}
          </select>
        </div>

        <div>
          <label className="block text-xs font-semibold text-slate-400 uppercase tracking-wider mb-2">Días de Crédito</label>
          <input
            type="number"
            value={diasCredito}
            onChange={(e) => setDiasCredito(Number(e.target.value))}
            className="w-full px-3 py-2 bg-slate-950 border border-slate-700 rounded-lg text-white text-sm focus:outline-none focus:ring-2 focus:ring-emerald-500"
          />
        </div>

        <div>
          <label className="block text-xs font-semibold text-slate-400 uppercase tracking-wider mb-2">Comentarios</label>
          <input
            type="text"
            value={comentario}
            onChange={(e) => setComentario(e.target.value)}
            placeholder="Nota o referencia de entrega..."
            className="w-full px-3 py-2 bg-slate-950 border border-slate-700 rounded-lg text-white text-sm focus:outline-none focus:ring-2 focus:ring-emerald-500"
          />
        </div>
      </div>

      {/* Captura de Productos */}
      <form onSubmit={handleAgregarPartida} className="bg-slate-900 border border-slate-800 rounded-xl p-5 grid grid-cols-1 md:grid-cols-6 gap-3 items-end">
        <div className="md:col-span-2">
          <label className="block text-xs font-semibold text-slate-400 uppercase tracking-wider mb-2">Producto</label>
          <select
            value={productoSeleccionado?.id || 0}
            onChange={(e) => handleCambioProducto(Number(e.target.value))}
            className="w-full px-3 py-2 bg-slate-950 border border-slate-700 rounded-lg text-white text-sm focus:outline-none focus:ring-2 focus:ring-emerald-500"
          >
            {productos.map((p) => (
              <option key={p.id} value={p.id}>
                {p.clave} - {p.producto} (${Number(p.precio_Venta_1).toFixed(2)})
              </option>
            ))}
          </select>
        </div>

        <div>
          <label className="block text-xs font-semibold text-slate-400 uppercase tracking-wider mb-2">Cantidad</label>
          <input
            type="number"
            step={productoSeleccionado?.tiene_Decimal ? "0.01" : "1"}
            min="0.01"
            value={cantidad}
            onChange={(e) => setCantidad(Number(e.target.value))}
            className="w-full px-3 py-2 bg-slate-950 border border-slate-700 rounded-lg text-white text-sm focus:outline-none focus:ring-2 focus:ring-emerald-500"
          />
        </div>

        <div>
          <label className="block text-xs font-semibold text-slate-400 uppercase tracking-wider mb-2">Precio ($)</label>
          <input
            type="number"
            step="0.01"
            value={precio}
            onChange={(e) => setPrecio(Number(e.target.value))}
            className="w-full px-3 py-2 bg-slate-950 border border-slate-700 rounded-lg text-white text-sm focus:outline-none focus:ring-2 focus:ring-emerald-500"
          />
        </div>

        <div>
          <label className="block text-xs font-semibold text-slate-400 uppercase tracking-wider mb-2">Descuento ($)</label>
          <input
            type="number"
            step="0.01"
            value={descuento}
            onChange={(e) => setDescuento(Number(e.target.value))}
            className="w-full px-3 py-2 bg-slate-950 border border-slate-700 rounded-lg text-white text-sm focus:outline-none focus:ring-2 focus:ring-emerald-500"
          />
        </div>

        <div>
          <button
            type="submit"
            className="w-full py-2 bg-emerald-600 hover:bg-emerald-500 text-white font-semibold text-sm rounded-lg shadow transition"
          >
            + Agregar
          </button>
        </div>
      </form>

      {/* Tabla de Partidas */}
      <div className="bg-slate-900 border border-slate-800 rounded-xl overflow-hidden shadow-sm">
        <table className="w-full text-left text-sm text-slate-300">
          <thead className="bg-slate-950 text-xs uppercase text-slate-400 border-b border-slate-800">
            <tr>
              <th className="px-6 py-3 font-semibold">Clave</th>
              <th className="px-6 py-3 font-semibold">Producto</th>
              <th className="px-6 py-3 font-semibold text-center">Cant.</th>
              <th className="px-6 py-3 font-semibold text-right">Precio</th>
              <th className="px-6 py-3 font-semibold text-right">Desc.</th>
              <th className="px-6 py-3 font-semibold text-right">Importe</th>
              <th className="px-6 py-3 font-semibold text-center">Acción</th>
            </tr>
          </thead>
          <tbody className="divide-y divide-slate-800">
            {partidas.length === 0 ? (
              <tr>
                <td colSpan={7} className="px-6 py-8 text-center text-slate-500 text-sm">
                  No hay artículos agregados al pedido.
                </td>
              </tr>
            ) : (
              partidas.map((p, idx) => (
                <tr key={idx} className="hover:bg-slate-800/40 transition">
                  <td className="px-6 py-3 font-mono text-emerald-400 text-xs">{p.claveProducto}</td>
                  <td className="px-6 py-3 font-medium text-white">{p.nombreProducto}</td>
                  <td className="px-6 py-3 text-center">{p.cantidad} {p.umVenta}</td>
                  <td className="px-6 py-3 text-right">${p.precioVenta.toFixed(2)}</td>
                  <td className="px-6 py-3 text-right text-rose-400">${p.descuento.toFixed(2)}</td>
                  <td className="px-6 py-3 text-right font-semibold text-white">${p.importe.toFixed(2)}</td>
                  <td className="px-6 py-3 text-center">
                    <button
                      onClick={() => handleEliminarPartida(idx)}
                      className="text-xs text-rose-400 hover:text-rose-300 font-medium"
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
        <div className="p-6 bg-slate-950 border-t border-slate-800 flex flex-col md:flex-row items-center justify-between gap-4">
          <div className="text-sm text-slate-400">
            Total de partidas: <span className="font-semibold text-white">{partidas.length}</span>
          </div>
          <div className="flex items-center gap-6">
            <div className="text-right">
              <span className="text-xs text-slate-400 block uppercase tracking-wider font-semibold">Total a Pagar</span>
              <span className="text-3xl font-extrabold text-emerald-400">${totalPedido.toFixed(2)}</span>
            </div>
            <button
              onClick={handleGuardarPedido}
              disabled={guardando || partidas.length === 0}
              className="px-8 py-3.5 bg-emerald-600 hover:bg-emerald-500 disabled:opacity-50 text-white font-bold text-base rounded-xl shadow-lg shadow-emerald-600/30 transition"
            >
              {guardando ? "Procesando..." : "Confirmar & Guardar Pedido"}
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}
