"use client";

import { useEffect, useState } from "react";
import { fetchProductosApi, Producto } from "@/lib/api";

export default function ProductosPage() {
  const [productos, setProductos] = useState<Producto[]>([]);
  const [busqueda, setBusqueda] = useState("");
  const [cargando, setCargando] = useState(true);

  const cargarProductos = async (filtro = "") => {
    const token = localStorage.getItem("token");
    if (!token) return;

    setCargando(true);
    try {
      const data = await fetchProductosApi(token, filtro);
      setProductos(data);
    } catch (err) {
      console.error(err);
    } finally {
      setCargando(false);
    }
  };

  useEffect(() => {
    cargarProductos();
  }, []);

  const handleBuscar = (e: React.FormEvent) => {
    e.preventDefault();
    cargarProductos(busqueda);
  };

  return (
    <div className="space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-slate-900">Catálogo de Productos</h1>
          <p className="text-sm text-slate-500">Listado general de artículos, precios y unidades de venta.</p>
        </div>
        <button className="px-4 py-2.5 bg-emerald-600 hover:bg-emerald-500 text-slate-900 font-medium text-sm rounded-lg shadow-md transition flex items-center gap-2 self-start md:self-auto">
          <span>+ Nuevo Producto</span>
        </button>
      </div>

      {/* Barra de búsqueda */}
      <form onSubmit={handleBuscar} className="flex gap-3">
        <input
          type="text"
          value={busqueda}
          onChange={(e) => setBusqueda(e.target.value)}
          placeholder="Buscar producto por nombre o clave..."
          className="flex-1 px-4 py-2.5 bg-white border border-slate-200 rounded-lg text-slate-900 placeholder-slate-500 focus:outline-none focus:ring-2 focus:ring-emerald-500 text-sm"
        />
        <button
          type="submit"
          className="px-5 py-2.5 bg-slate-800 hover:bg-slate-200 text-slate-200 text-sm font-medium rounded-lg border border-slate-300 transition"
        >
          Buscar
        </button>
      </form>

      {/* Tabla de productos */}
      <div className="bg-white border border-slate-200 rounded-xl overflow-hidden shadow-sm">
        {cargando ? (
          <div className="p-8 text-center text-slate-500 text-sm">Cargando productos desde SQL Server...</div>
        ) : productos.length === 0 ? (
          <div className="p-8 text-center text-slate-500 text-sm">No se encontraron productos registrados.</div>
        ) : (
          <div className="overflow-x-auto">
            <table className="w-full text-left text-sm text-slate-700">
              <thead className="bg-slate-50 text-xs uppercase text-slate-500 border-b border-slate-200">
                <tr>
                  <th className="px-6 py-3.5 font-semibold">Clave</th>
                  <th className="px-6 py-3.5 font-semibold">Descripción del Producto</th>
                  <th className="px-6 py-3.5 font-semibold">U.M.</th>
                  <th className="px-6 py-3.5 font-semibold text-right">Precio Venta</th>
                  <th className="px-6 py-3.5 font-semibold text-center">Permite Decimal</th>
                  <th className="px-6 py-3.5 font-semibold text-right">Acciones</th>
                </tr>
              </thead>
              <tbody className="divide-y divide-slate-100">
                {productos.map((p) => (
                  <tr key={p.id} className="hover:bg-slate-50 transition">
                    <td className="px-6 py-4 font-mono text-emerald-600 text-xs font-semibold">{p.clave}</td>
                    <td className="px-6 py-4 font-medium text-slate-900">{p.producto}</td>
                    <td className="px-6 py-4">{p.uM_Venta || "PZA"}</td>
                    <td className="px-6 py-4 text-right font-medium text-slate-900">
                      ${Number(p.precio_Venta_1 || 0).toFixed(2)}
                    </td>
                    <td className="px-6 py-4 text-center">
                      <span className={`inline-block px-2 py-0.5 rounded text-[11px] font-semibold ${
                        p.tiene_Decimal ? "bg-cyan-500/10 text-cyan-400 border border-cyan-500/20" : "bg-slate-800 text-slate-500"
                      }`}>
                        {p.tiene_Decimal ? "Sí (Kg/Mtr)" : "No (Pza)"}
                      </span>
                    </td>
                    <td className="px-6 py-4 text-right">
                      <button className="text-xs text-slate-500 hover:text-emerald-600 font-medium transition mr-3">
                        Editar
                      </button>
                      <button className="text-xs text-rose-400 hover:text-rose-300 font-medium transition">
                        Eliminar
                      </button>
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
