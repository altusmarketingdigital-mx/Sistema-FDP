"use client";

import { useEffect, useState } from "react";
import { fetchMenuApi } from "@/lib/api";

export default function DashboardLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  const [usuario, setUsuario] = useState<any>(null);
  const [menuData, setMenuData] = useState<any>(null);
  const [cargando, setCargando] = useState(true);

  useEffect(() => {
    const token = localStorage.getItem("token");
    const userStr = localStorage.getItem("usuario");

    if (!token || !userStr) {
      window.location.href = "/login";
      return;
    }

    setUsuario(JSON.parse(userStr));

    fetchMenuApi(token)
      .then((data) => {
        setMenuData(data);
      })
      .catch((err) => {
        console.error("Error al cargar menú:", err);
      })
      .finally(() => {
        setCargando(false);
      });
  }, []);

  const cerrarSesion = () => {
    localStorage.removeItem("token");
    localStorage.removeItem("usuario");
    window.location.href = "/login";
  };

  if (cargando) {
    return (
      <div className="min-h-screen bg-slate-900 flex items-center justify-center text-white">
        <div className="flex items-center gap-3">
          <div className="w-5 h-5 border-2 border-emerald-500 border-t-transparent rounded-full animate-spin"></div>
          <span>Cargando sistema y permisos...</span>
        </div>
      </div>
    );
  }

  const DEFAULT_MENU = [
    {
      PK_Menu: 100,
      nombre: "Ventas y Pedidos",
      MenuHijo: [
        { PK_Menu: 101, nombre: "Captura de Pedidos", url: "/dashboard/pedidos/nuevo" },
        { PK_Menu: 102, nombre: "Historial de Pedidos", url: "/dashboard/pedidos" },
      ]
    },
    {
      PK_Menu: 200,
      nombre: "Catálogos",
      MenuHijo: [
        { PK_Menu: 201, nombre: "Productos", url: "/dashboard/catalogos/productos" },
        { PK_Menu: 202, nombre: "Clientes", url: "/dashboard/catalogos/clientes" },
      ]
    },
    {
      PK_Menu: 300,
      nombre: "Cuentas por Cobrar",
      MenuHijo: [
        { PK_Menu: 301, nombre: "Cobranza y Abonos", url: "/dashboard/cobranza" },
        { PK_Menu: 302, nombre: "Historial de Pagos", url: "/dashboard/cobranza/historial" },
      ]
    },
    {
      PK_Menu: 400,
      nombre: "Reportes",
      MenuHijo: [
        { PK_Menu: 401, nombre: "Movimientos y Auditoría", url: "/dashboard/reportes/movimientos" },
      ]
    },
    {
      PK_Menu: 500,
      nombre: "Seguridad",
      MenuHijo: [
        { PK_Menu: 501, nombre: "Usuarios y Permisos", url: "/dashboard/seguridad/usuarios" },
      ]
    }
  ];

  const menuPadres = (menuData?.MenuPadre && menuData.MenuPadre.length > 0) ? menuData.MenuPadre : DEFAULT_MENU;

  return (
    <div className="min-h-screen flex bg-slate-950 text-slate-100">
      {/* Sidebar dinámico */}
      <aside className="w-64 bg-slate-900 border-r border-slate-800 flex flex-col justify-between">
        <div>
          {/* Header del sidebar */}
          <div className="h-16 flex items-center px-6 border-b border-slate-800 gap-3">
            <div className="w-8 h-8 rounded-lg bg-emerald-600 flex items-center justify-center font-bold text-white shadow-md shadow-emerald-600/30">
              A
            </div>
            <div>
              <span className="font-semibold text-white tracking-wide text-sm block">Altus Pv</span>
              <span className="text-[10px] text-emerald-400 font-medium uppercase tracking-wider">Punto de Venta Web</span>
            </div>
          </div>

          {/* Menú de navegación */}
          <nav className="p-4 space-y-3">
            <div className="px-3 py-1 text-[11px] font-semibold text-slate-400 uppercase tracking-wider">
              Módulos Activos
            </div>

            {menuPadres.map((padre: any) => (
              <div key={padre.PK_Menu} className="mb-2">
                <div className="px-3 py-1 text-xs font-semibold text-emerald-400 uppercase tracking-wider flex items-center justify-between">
                  <span>{padre.vchMenu || padre.nombre}</span>
                </div>
                {padre.MenuHijo && padre.MenuHijo.length > 0 && (
                  <div className="mt-1 space-y-0.5 border-l border-slate-800 pl-2">
                    {padre.MenuHijo.map((hijo: any) => (
                      <a
                        key={hijo.PK_Menu}
                        href={hijo.url || "#"}
                        className="block px-3 py-1.5 text-xs font-medium rounded-md text-slate-300 hover:text-white hover:bg-slate-800 transition"
                      >
                        {hijo.vchMenu || hijo.nombre}
                      </a>
                    ))}
                  </div>
                )}
              </div>
            ))}
          </nav>
        </div>

        {/* Footer del usuario */}
        <div className="p-4 border-t border-slate-800">
          <div className="flex items-center justify-between mb-3">
            <div className="flex items-center gap-2">
              <div className="w-8 h-8 rounded-full bg-slate-700 flex items-center justify-center text-xs font-bold text-emerald-400">
                {usuario?.usuario?.substring(0, 2).toUpperCase()}
              </div>
              <div className="overflow-hidden">
                <p className="text-sm font-medium text-white truncate">{usuario?.nombreCompleto || usuario?.usuario}</p>
                <p className="text-xs text-slate-400 truncate">Nómina: {usuario?.nomina}</p>
              </div>
            </div>
          </div>
          <button
            onClick={cerrarSesion}
            className="w-full py-2 px-3 text-xs font-medium text-rose-400 bg-rose-500/10 hover:bg-rose-500/20 border border-rose-500/20 rounded-md transition text-center"
          >
            Cerrar Sesión
          </button>
        </div>
      </aside>

      {/* Área de contenido */}
      <main className="flex-1 flex flex-col">
        <header className="h-16 bg-slate-900/60 backdrop-blur border-b border-slate-800 flex items-center justify-between px-8">
          <h2 className="text-lg font-semibold text-white">Panel Principal</h2>
          <span className="text-xs px-2.5 py-1 rounded-full bg-emerald-500/10 text-emerald-400 border border-emerald-500/20 font-medium">
            Conectado a SQL Server (Tss_Inventario)
          </span>
        </header>
        <div className="p-8 flex-1">
          {children}
        </div>
      </main>
    </div>
  );
}
