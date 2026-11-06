"use client";

import { useEffect, useState } from "react";
import { fetchHistorialPagosApi, PagoHistorial } from "@/lib/api";

export default function HistorialPagosPage() {
  const [pagos, setPagos] = useState<PagoHistorial[]>([]);
  const [cargando, setCargando] = useState(true);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token) return;

    fetchHistorialPagosApi(token)
      .then((data) => setPagos(data))
      .catch((err) => console.error(err))
      .finally(() => setCargando(false));
  }, []);

  return (
    <div className="space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-white">Historial de Pagos & Abonos</h1>
          <p className="text-sm text-slate-400">Auditoría de cobros aplicados a clientes en el sistema.</p>
        </div>
        <a
          href="/dashboard/cobranza"
          className="px-4 py-2 bg-emerald-600 hover:bg-emerald-500 text-white font-medium text-sm rounded-lg shadow transition self-start md:self-auto"
        >
          + Cobrar a Cliente
        </a>
      </div>

      <div className="bg-slate-900 border border-slate-800 rounded-xl overflow-hidden shadow-sm">
        {cargando ? (
          <div className="p-8 text-center text-slate-400 text-sm">Consultando bitácora de pagos...</div>
        ) : pagos.length === 0 ? (
          <div className="p-8 text-center text-slate-400 text-sm">No hay registros de pago en la base de datos.</div>
        ) : (
          <div className="overflow-x-auto">
            <table className="w-full text-left text-sm text-slate-300">
              <thead className="bg-slate-950 text-xs uppercase text-slate-400 border-b border-slate-800">
                <tr>
                  <th className="px-6 py-3.5 font-semibold">Folio Pago</th>
                  <th className="px-6 py-3.5 font-semibold">Cliente</th>
                  <th className="px-6 py-3.5 font-semibold">Nota Remisión</th>
                  <th className="px-6 py-3.5 font-semibold text-right">Saldo Anterior</th>
                  <th className="px-6 py-3.5 font-semibold text-right">Saldo Posterior</th>
                  <th className="px-6 py-3.5 font-semibold text-center">Fecha Pago</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-800">
                {pagos.map((p) => (
                  <tr key={p.id} className="hover:bg-slate-800/40 transition">
                    <td className="px-6 py-4 font-mono text-emerald-400 font-bold text-xs">PAG #{p.id}</td>
                    <td className="px-6 py-4 font-medium text-white">{p.nombre}</td>
                    <td className="px-6 py-4 font-mono text-xs text-slate-400">Nota #{p.idnota}</td>
                    <td className="px-6 py-4 text-right text-slate-300 font-mono">
                      ${Number(p.saldO_ANTERIOR).toFixed(2)}
                    </td>
                    <td className="px-6 py-4 text-right font-mono font-semibold text-emerald-400">
                      ${Number(p.saldO_NUEVO).toFixed(2)}
                    </td>
                    <td className="px-6 py-4 text-center text-xs text-slate-400">
                      {new Date(p.fechatimbrado).toLocaleString()}
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
