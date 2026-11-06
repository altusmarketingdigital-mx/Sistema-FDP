"use client";

import { useEffect, useState } from "react";
import Link from "next/link";
import { usePathname } from "next/navigation";

interface MenuItem {
  nombre: string;
  url: string;
  badge?: string;
  icon?: string;
}

interface MenuGroup {
  id: string;
  nombre: string;
  items: MenuItem[];
}

const MODULOS_SISTEMA: MenuGroup[] = [
  {
    id: "ventas",
    nombre: "Ventas y Pedidos",
    items: [
      { nombre: "Captura de Pedidos", url: "/dashboard/pedidos/nuevo" },
      { nombre: "Historial de Pedidos", url: "/dashboard/pedidos" },
    ]
  },
  {
    id: "catalogos",
    nombre: "Catálogos del Sistema",
    items: [
      { nombre: "Productos e Inventario", url: "/dashboard/catalogos/productos" },
      { nombre: "Clientes y Crédito", url: "/dashboard/catalogos/clientes" },
    ]
  },
  {
    id: "cxc",
    nombre: "Cuentas por Cobrar",
    items: [
      { nombre: "Cobranza y Abonos", url: "/dashboard/cobranza" },
      { nombre: "Historial de Pagos", url: "/dashboard/cobranza/historial" },
    ]
  },
  {
    id: "reportes",
    nombre: "Reportes",
    items: [
      { nombre: "Movimientos Generales", url: "/dashboard/reportes/movimientos" },
    ]
  },
  {
    id: "seguridad",
    nombre: "Seguridad y Accesos",
    items: [
      { nombre: "Usuarios del Sistema", url: "/dashboard/seguridad/usuarios" },
    ]
  }
];

export default function DashboardLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const [usuario, setUsuario] = useState<any>(null);
  const pathname = usePathname();

  useEffect(() => {
    const token = localStorage.getItem("token");
    const userStr = localStorage.getItem("usuario");

    if (!token || !userStr) {
      window.location.href = "/login";
      return;
    }

    try {
      setUsuario(JSON.parse(userStr));
    } catch {
      setUsuario({ usuario: "Usuario", nombreCompleto: "Usuario Activo", nomina: "00000" });
    }
  }, []);

  const cerrarSesion = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("usuario");
    window.location.href = "/login";
  };

  return (
    <div className="min-h-screen flex bg-slate-50 text-slate-800">
      {/* Sidebar fijo blanco/claro con sombras suaves */}
      <aside className="w-64 bg-white border-r border-slate-200 flex flex-col justify-between shrink-0 shadow-sm">
        <div>
          {/* Header del sidebar */}
          <div className="h-16 flex items-center px-6 border-b border-slate-100 gap-3 bg-white">
            <div className="w-9 h-9 rounded-xl bg-blue-600 flex items-center justify-center font-black text-white text-base shadow-md shadow-blue-500/20">
              A
            </div>
            <div>
              <span className="font-bold text-slate-900 tracking-tight text-sm block">Altus Pv</span>
              <span className="text-[10px] text-blue-600 font-semibold uppercase tracking-wider block">Punto de Venta Web</span>
            </div>
          </div>

          {/* Menú de navegación */}
          <nav className="p-4 space-y-4 overflow-y-auto max-h-[calc(100vh-140px)]">
            <div className="px-3 py-1 text-[11px] font-bold text-slate-400 uppercase tracking-wider">
              Módulos Activos
            </div>

            {MODULOS_SISTEMA.map((grupo) => (
              <div key={grupo.id} className="space-y-1">
                <div className="px-3 py-1 text-[11px] font-bold text-slate-500 uppercase tracking-wider">
                  {grupo.nombre}
                </div>
                <div className="space-y-0.5 border-l-2 border-slate-100 ml-2 pl-2">
                  {grupo.items.map((item) => {
                    const isActive = pathname === item.url;
                    return (
                      <Link
                        key={item.url}
                        href={item.url}
                        className={`block px-3 py-2 text-xs font-medium rounded-lg transition ${
                          isActive
                            ? "bg-blue-600 text-white font-semibold shadow-sm shadow-blue-600/30"
                            : "text-slate-600 hover:text-slate-900 hover:bg-slate-100"
                        }`}
                      >
                        {item.nombre}
                      </Link>
                    );
                  })}
                </div>
              </div>
            ))}
          </nav>
        </div>

        {/* Footer del usuario */}
        <div className="p-4 border-t border-slate-100 bg-slate-50/50">
          <div className="flex items-center gap-2 mb-3">
            <div className="w-8 h-8 rounded-full bg-blue-100 border border-blue-200 flex items-center justify-center text-xs font-bold text-blue-700">
              {usuario?.usuario ? usuario.usuario.substring(0, 2).toUpperCase() : "US"}
            </div>
            <div className="overflow-hidden">
              <p className="text-xs font-bold text-slate-800 truncate">{usuario?.nombreCompleto || usuario?.usuario || "Usuario"}</p>
              <p className="text-[10px] text-slate-500 truncate">Nómina: {usuario?.nomina || "Activo"}</p>
            </div>
          </div>
          <button
            onClick={cerrarSesion}
            className="w-full py-2 px-3 text-xs font-semibold text-rose-600 bg-rose-50 hover:bg-rose-100 border border-rose-200 rounded-lg transition text-center"
          >
            Cerrar Sesión
          </button>
        </div>
      </aside>

      {/* Área de contenido */}
      <main className="flex-1 flex flex-col min-w-0">
        <header className="h-16 bg-white border-b border-slate-200 flex items-center justify-between px-8 shadow-xs">
          <h2 className="text-base font-bold text-slate-900 tracking-tight">Panel Principal &bull; Altus Pv</h2>
          <span className="text-xs px-3 py-1 rounded-full bg-emerald-50 text-emerald-700 border border-emerald-200 font-semibold">
            ● Sistema Conectado
          </span>
        </header>
        <div className="p-8 flex-1 overflow-auto bg-slate-50">
          {children}
        </div>
      </main>
    </div>
  );
}
