"use client";

import { useEffect, useState } from "react";
import { fetchUsuariosSistemaApi, UsuarioSistema } from "@/lib/api";

export default function UsuariosSeguridadPage() {
  const [usuarios, setUsuarios] = useState<UsuarioSistema[]>([]);
  const [cargando, setCargando] = useState(true);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token) return;

    fetchUsuariosSistemaApi(token)
      .then((data) => setUsuarios(data))
      .catch((err) => console.error(err))
      .finally(() => setCargando(false));
  }, []);

  return (
    <div className="space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-white">Administración de Usuarios & Seguridad</h1>
          <p className="text-sm text-slate-400">Control de cuentas con acceso al sistema &bull; Base ELYON_dbPermisosV</p>
        </div>
        <button className="px-4 py-2.5 bg-emerald-600 hover:bg-emerald-500 text-white font-medium text-sm rounded-lg shadow transition self-start md:self-auto">
          <span>+ Nuevo Usuario</span>
        </button>
      </div>

      <div className="bg-slate-900 border border-slate-800 rounded-xl overflow-hidden shadow-sm">
        {cargando ? (
          <div className="p-8 text-center text-slate-400 text-sm">Consultando usuarios registrados...</div>
        ) : (
          <div className="overflow-x-auto">
            <table className="w-full text-left text-sm text-slate-300">
              <thead className="bg-slate-950 text-xs uppercase text-slate-400 border-b border-slate-800">
                <tr>
                  <th className="px-6 py-3.5 font-semibold">Usuario</th>
                  <th className="px-6 py-3.5 font-semibold">Nombre Completo</th>
                  <th className="px-6 py-3.5 font-semibold">Nómina</th>
                  <th className="px-6 py-3.5 font-semibold">Correo</th>
                  <th className="px-6 py-3.5 font-semibold text-center">Rol</th>
                  <th className="px-6 py-3.5 font-semibold text-center">Estatus</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-800">
                {usuarios.map((u) => (
                  <tr key={u.idUsuario} className="hover:bg-slate-800/40 transition">
                    <td className="px-6 py-4 font-mono font-bold text-emerald-400 text-xs">
                      {u.usuario}
                    </td>
                    <td className="px-6 py-4 font-medium text-white">{u.nombreCompleto}</td>
                    <td className="px-6 py-4 font-mono text-xs text-slate-400">{u.nomina || "—"}</td>
                    <td className="px-6 py-4 text-xs text-slate-400">{u.correo || "—"}</td>
                    <td className="px-6 py-4 text-center">
                      <span className={`px-2.5 py-0.5 rounded text-[11px] font-semibold ${
                        u.esAdmin ? "bg-purple-500/10 text-purple-400 border border-purple-500/20" : "bg-slate-800 text-slate-300"
                      }`}>
                        {u.esAdmin ? "Administrador" : "Operador"}
                      </span>
                    </td>
                    <td className="px-6 py-4 text-center">
                      <span className={`inline-block px-2.5 py-0.5 rounded-full text-[11px] font-semibold ${
                        u.activo ? "bg-emerald-500/10 text-emerald-400 border border-emerald-500/20" : "bg-rose-500/10 text-rose-400"
                      }`}>
                        {u.activo ? "Activo" : "Inactivo"}
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
