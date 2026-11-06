"use client";

import { useEffect, useState } from "react";
import { fetchHistorialPedidosApi, PedidoHistorial } from "@/lib/api";

export default function HistorialPedidosPage() {
  const [pedidos, setPedidos] = useState<PedidoHistorial[]>([]);
  const [cargando, setCargando] = useState(true);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token) return;

    fetchHistorialPedidosApi(token)
      .then((data) => setPedidos(data))
      .catch((err) => console.error(err))
      .finally(() => setCargando(false));
  }, []);

  return (
    <div className="space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-slate-900">Historial de Pedidos</h1>
          <p className="text-sm text-slate-500">Listado de pedidos registrados pendientes o listos para remisión.</p>
        </div>
        <a
          href="/dashboard/pedidos/nuevo"
          className="px-4 py-2.5 bg-emerald-600 hover:bg-emerald-500 text-slate-900 font-medium text-sm rounded-lg shadow-md transition self-start md:self-auto"
        >
          + Nuevo Pedido
        </a>
      </div>

      <div className="bg-white border border-slate-200 rounded-xl overflow-hidden shadow-sm">
        {cargando ? (
          <div className="p-8 text-center text-slate-500 text-sm">Consultando pedidos desde SQL Server...</div>
        ) : pedidos.length === 0 ? (
          <div className="p-8 text-center text-slate-500 text-sm">No se encontraron pedidos registrados.</div>
        ) : (
          <div className="overflow-x-auto">
            <table className="w-full text-left text-sm text-slate-700">
              <thead className="bg-slate-50 text-xs uppercase text-slate-500 border-b border-slate-200">
                <tr>
                  <th className="px-6 py-3.5 font-semibold">Folio</th>
                  <th className="px-6 py-3.5 font-semibold">Cliente</th>
                  <th className="px-6 py-3.5 font-semibold">Fecha Venta</th>
                  <th className="px-6 py-3.5 font-semibold text-center">Días Crédito</th>
                  <th className="px-6 py-3.5 font-semibold text-right">Acción</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {pedidos.map((p) => (
                  <tr key={p.id_Pedido} className="hover:bg-slate-50 transition">
                    <td className="px-6 py-4 font-mono text-emerald-600 text-xs font-bold">
                      {p.folio} {p.id_Pedido}
                    </td>
                    <td className="px-6 py-4 font-medium text-slate-900">{p.nombre_Cliente || "Público en General"}</td>
                    <td className="px-6 py-4 text-xs text-slate-500">
                      {new Date(p.fecha_Venta).toLocaleString()}
                    </td>
                    <td className="px-6 py-4 text-center">
                      <span className="px-2 py-0.5 rounded text-[11px] bg-slate-800 text-slate-700 font-medium">
                        {p.dias_Credito} días
                      </span>
                    </td>
                    <td className="px-6 py-4 text-right">
                      <a
                        href={`/impresion/ticket/${p.id_Pedido}`}
                        target="_blank"
                        className="px-3 py-1 bg-slate-800 hover:bg-slate-200 text-emerald-600 text-xs font-semibold rounded border border-slate-300 transition"
                      >
                        🖨️ Ver Ticket
                      </a>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        )}
      </div>
    </div>
  );
}
