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
          <h1 className="text-2xl font-bold text-slate-900">Administración de Usuarios & Seguridad</h1>
          <p className="text-sm text-slate-500">Control de cuentas con acceso al sistema &bull; Base ELYON_dbPermisosV</p>
        </div>
        <button className="px-4 py-2.5 bg-emerald-600 hover:bg-emerald-500 text-slate-900 font-medium text-sm rounded-lg shadow transition self-start md:self-auto">
          <span>+ Nuevo Usuario</span>
        </button>
      </div>

      <div className="bg-white border border-slate-200 rounded-xl overflow-hidden shadow-sm">
        {cargando ? (
          <div className="p-8 text-center text-slate-500 text-sm">Consultando usuarios registrados...</div>
        ) : (
          <div className="overflow-x-auto">
            <table className="w-full text-left text-sm text-slate-700">
              <thead className="bg-slate-50 text-xs uppercase text-slate-500 border-b border-slate-200">
                <tr>
                  <th className="px-6 py-3.5 font-semibold">Usuario</th>
                  <th className="px-6 py-3.5 font-semibold">Nombre Completo</th>
                  <th className="px-6 py-3.5 font-semibold">Nómina</th>
                  <th className="px-6 py-3.5 font-semibold">Correo</th>
                  <th className="px-6 py-3.5 font-semibold text-center">Rol</th>
                  <th className="px-6 py-3.5 font-semibold text-center">Estatus</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {usuarios.map((u) => (
                  <tr key={u.idUsuario} className="hover:bg-slate-50 transition">
                    <td className="px-6 py-4 font-mono font-bold text-emerald-600 text-xs">
                      {u.usuario}
                    </td>
                    <td className="px-6 py-4 font-medium text-slate-900">{u.nombreCompleto}</td>
                    <td className="px-6 py-4 font-mono text-xs text-slate-500">{u.nomina || "—"}</td>
                    <td className="px-6 py-4 text-xs text-slate-500">{u.correo || "—"}</td>
                    <td className="px-6 py-4 text-center">
                      <span className={`px-2.5 py-0.5 rounded text-[11px] font-semibold ${
                        u.esAdmin ? "bg-purple-500/10 text-purple-400 border border-purple-500/20" : "bg-slate-800 text-slate-700"
                      }`}>
                        {u.esAdmin ? "Administrador" : "Operador"}
                      </span>
                    </td>
                    <td className="px-6 py-4 text-center">
                      <span className={`inline-block px-2.5 py-0.5 rounded-full text-[11px] font-semibold ${
                        u.activo ? "bg-emerald-500/10 text-emerald-600 border border-emerald-500/20" : "bg-rose-500/10 text-rose-400"
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
