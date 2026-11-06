"use client";

import { useEffect, useState } from "react";
import { fetchClientesApi, Cliente } from "@/lib/api";

export default function ClientesPage() {
  const [clientes, setClientes] = useState<Cliente[]>([]);
  const [busqueda, setBusqueda] = useState("");
  const [cargando, setCargando] = useState(true);

  const cargarClientes = async (filtro = "") => {
    const token = localStorage.getItem("token");
    if (!token) return;

    setCargando(true);
    try {
      const data = await fetchClientesApi(token, filtro);
      setClientes(data);
    } catch (err) {
      console.error(err);
    } finally {
      setCargando(false);
    }
  };

  useEffect(() => {
    cargarClientes();
  }, []);

  const handleBuscar = (e: React.FormEvent) => {
    e.preventDefault();
    cargarClientes(busqueda);
  };

  return (
    <div className="space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-slate-900">Catálogo de Clientes</h1>
          <p className="text-sm text-slate-500">Control de cartera, condiciones de crédito y estado de bloqueo.</p>
        </div>
        <button className="px-4 py-2.5 bg-emerald-600 hover:bg-emerald-500 text-slate-900 font-medium text-sm rounded-lg shadow-md transition flex items-center gap-2 self-start md:self-auto">
          <span>+ Nuevo Cliente</span>
        </button>
      </div>

      <form onSubmit={handleBuscar} className="flex gap-3">
        <input
          type="text"
          value={busqueda}
          onChange={(e) => setBusqueda(e.target.value)}
          placeholder="Buscar cliente por nombre o razón social..."
          className="flex-1 px-4 py-2.5 bg-white border border-slate-200 rounded-lg text-slate-900 placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-emerald-500 text-sm"
        />
        <button
          type="submit"
          className="px-5 py-2.5 bg-slate-800 hover:bg-slate-200 text-slate-200 text-sm font-medium rounded-lg border border-slate-300 transition"
        >
          Buscar
        </button>
      </form>

      <div className="bg-white border border-slate-200 rounded-xl overflow-hidden shadow-sm">
        {cargando ? (
          <div className="p-8 text-center text-slate-500 text-sm">Cargando cartera de clientes...</div>
        ) : clientes.length === 0 ? (
          <div className="p-8 text-center text-slate-500 text-sm">No se encontraron clientes registrados.</div>
        ) : (
          <div className="overflow-x-auto">
            <table className="w-full text-left text-sm text-slate-700">
              <thead className="bg-slate-50 text-xs uppercase text-slate-500 border-b border-slate-200">
                <tr>
                  <th className="px-6 py-3.5 font-semibold">Cliente / Razón Social</th>
                  <th className="px-6 py-3.5 font-semibold">RFC</th>
                  <th className="px-6 py-3.5 font-semibold">Teléfono</th>
                  <th className="px-6 py-3.5 font-semibold text-center">Días Crédito</th>
                  <th className="px-6 py-3.5 font-semibold text-right">Límite Crédito</th>
                  <th className="px-6 py-3.5 font-semibold text-center">Estatus</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {clientes.map((c) => (
                  <tr key={c.pK_Id_Cliente} className="hover:bg-slate-50 transition">
                    <td className="px-6 py-4 font-medium text-slate-900">{c.vchNombre}</td>
                    <td className="px-6 py-4 font-mono text-xs text-slate-500">{c.vchRFC || "XAXX010101000"}</td>
                    <td className="px-6 py-4">{c.vchTelefono || "—"}</td>
                    <td className="px-6 py-4 text-center">{c.intDiasCredito} días</td>
                    <td className="px-6 py-4 text-right font-medium text-emerald-600">
                      ${Number(c.vchLimiteCredito || 0).toFixed(2)}
                    </td>
                    <td className="px-6 py-4 text-center">
                      <span className={`inline-block px-2.5 py-0.5 rounded-full text-[11px] font-semibold ${
                        c.bBloqueoCliente 
                          ? "bg-rose-500/10 text-rose-400 border border-rose-500/20" 
                          : "bg-emerald-500/10 text-emerald-600 border border-emerald-500/20"
                      }`}>
                        {c.bBloqueoCliente ? "Bloqueado" : "Activo"}
                      </span>
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
