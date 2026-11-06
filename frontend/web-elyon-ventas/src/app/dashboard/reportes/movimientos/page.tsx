"use client";

import { useEffect, useState } from "react";
import {
  fetchReporteMovimientosApi,
  fetchResumenDiaApi,
  MovimientoReporte,
  ResumenDia
} from "@/lib/api";

export default function ReporteMovimientosPage() {
  const [movimientos, setMovimientos] = useState<MovimientoReporte[]>([]);
  const [resumen, setResumen] = useState<ResumenDia | null>(null);
  const [cargando, setCargando] = useState(true);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token) return;

    Promise.all([
      fetchReporteMovimientosApi(token),
      fetchResumenDiaApi(token)
    ])
      .then(([movs, res]) => {
        setMovimientos(movs);
        setResumen(res);
      })
      .catch((err) => console.error(err))
      .finally(() => setCargando(false));
  }, []);

  const exportarCSV = () => {
    if (movimientos.length === 0) return;

    const headers = ["ID", "Cliente", "RFC", "Pedido", "Folio", "Fecha Pedido", "Nota Remision", "Fecha Remision", "Cajero", "Estatus Nota", "Id Pago", "Saldo Anterior", "Saldo Nuevo"];
    const rows = movimientos.map((m) => [
      m.id,
      `"${m.nombreCliente}"`,
      `"${m.rfc}"`,
      m.idPedido,
      `"${m.folio}"`,
      m.fechaVentaPedido ? new Date(m.fechaVentaPedido).toLocaleDateString() : "",
      m.idNotaRemision,
      m.fechaNotaRemision ? new Date(m.fechaNotaRemision).toLocaleDateString() : "",
      `"${m.nombreCajeroNota}"`,
      `"${m.estatusNotas}"`,
      m.idPago,
      m.saldoAnterior,
      m.saldoNuevo
    ]);

    const csvContent = "data:text/csv;charset=utf-8," + [headers.join(","), ...rows.map(e => e.join(","))].join("\n");
    const encodedUri = encodeURI(csvContent);
    const link = document.createElement("a");
    link.setAttribute("href", encodedUri);
    link.setAttribute("download", `Reporte_Movimientos_${new Date().toISOString().slice(0, 10)}.csv`);
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
  };

  return (
    <div className="space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-slate-900">Reporte General de Movimientos</h1>
          <p className="text-sm text-slate-500">Trazabilidad completa: Clientes &bull; Pedidos &bull; Notas de Remisión &bull; Cobranza</p>
        </div>
        <button
          onClick={exportarCSV}
          disabled={movimientos.length === 0}
          className="px-4 py-2.5 bg-emerald-600 hover:bg-emerald-500 disabled:opacity-50 text-slate-900 font-medium text-sm rounded-lg shadow transition flex items-center gap-2 self-start md:self-auto cursor-pointer"
        >
          <span>📥 Exportar a Excel (CSV)</span>
        </button>
      </div>

      {/* Tarjetas de Resumen Financiero */}
      {resumen && (
        <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
          <div className="bg-white border border-slate-200 p-5 rounded-xl">
            <span className="text-xs font-semibold text-slate-500 uppercase tracking-wider block mb-1">
              Pedidos de Hoy
            </span>
            <span className="text-2xl font-bold text-slate-900">{resumen.totalPedidos}</span>
          </div>

          <div className="bg-white border border-slate-200 p-5 rounded-xl">
            <span className="text-xs font-semibold text-slate-500 uppercase tracking-wider block mb-1">
              Cobranza Histórica Aplicada
            </span>
            <span className="text-2xl font-bold text-emerald-600 font-mono">
              ${resumen.totalCobrado.toFixed(2)}
            </span>
          </div>

          <div className="bg-white border border-slate-200 p-5 rounded-xl">
            <span className="text-xs font-semibold text-slate-500 uppercase tracking-wider block mb-1">
              Registros Consolidados
            </span>
            <span className="text-2xl font-bold text-cyan-400 font-mono">
              {movimientos.length}
            </span>
          </div>
        </div>
      )}

      {/* Tabla de Movimientos */}
      <div className="bg-white border border-slate-200 rounded-xl overflow-hidden shadow-sm">
        {cargando ? (
          <div className="p-8 text-center text-slate-500 text-sm">Ejecutando spSELReporteMovimientos...</div>
        ) : movimientos.length === 0 ? (
          <div className="p-8 text-center text-slate-500 text-sm">No se encontraron movimientos registrados.</div>
        ) : (
          <div className="overflow-x-auto">
            <table className="w-full text-left text-sm text-slate-700">
              <thead className="bg-slate-50 text-xs uppercase text-slate-500 border-b border-slate-200">
                <tr>
                  <th className="px-5 py-3 font-semibold">Cliente</th>
                  <th className="px-5 py-3 font-semibold">Pedido</th>
                  <th className="px-5 py-3 font-semibold">Nota Remisión</th>
                  <th className="px-5 py-3 font-semibold">Cajero</th>
                  <th className="px-5 py-3 font-semibold text-center">Estatus</th>
                  <th className="px-5 py-3 font-semibold text-right">Saldo Ant.</th>
                  <th className="px-5 py-3 font-semibold text-right">Saldo Nvo.</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {movimientos.map((m) => (
                  <tr key={m.id} className="hover:bg-slate-50 transition">
                    <td className="px-5 py-3.5 font-medium text-slate-900">
                      <div>{m.nombreCliente}</div>
                      <div className="text-[11px] font-mono text-slate-500">{m.rfc || "—"}</div>
                    </td>
                    <td className="px-5 py-3.5 font-mono text-xs text-slate-700">
                      {m.folio} #{m.idPedido}
                    </td>
                    <td className="px-5 py-3.5 font-mono text-xs text-emerald-600">
                      {m.idNotaRemision > 0 ? `Remisión #${m.idNotaRemision}` : "—"}
                    </td>
                    <td className="px-5 py-3.5 text-xs text-slate-500">
                      {m.nombreCajeroNota || "—"}
                    </td>
                    <td className="px-5 py-3.5 text-center">
                      <span className={`px-2 py-0.5 rounded text-[11px] font-semibold ${
                        m.estatusNotas === "Pagado"
                          ? "bg-emerald-500/10 text-emerald-600 border border-emerald-500/20"
                          : m.estatusNotas === "Cancelado"
                          ? "bg-rose-500/10 text-rose-400 border border-rose-500/20"
                          : "bg-amber-500/10 text-amber-400 border border-amber-500/20"
                      }`}>
                        {m.estatusNotas || "Sin Pago"}
                      </span>
                    </td>
                    <td className="px-5 py-3.5 text-right font-mono text-xs">
                      ${Number(m.saldoAnterior).toFixed(2)}
                    </td>
                    <td className="px-5 py-3.5 text-right font-mono text-xs font-semibold text-slate-900">
                      ${Number(m.saldoNuevo).toFixed(2)}
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
