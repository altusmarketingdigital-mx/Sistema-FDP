import Link from "next/link";

export default function DashboardHome() {
  return (
    <div className="space-y-6 max-w-6xl">
      <div className="bg-white border border-slate-200 rounded-2xl p-7 shadow-xs">
        <div className="inline-flex items-center gap-2 px-3 py-1 rounded-full bg-blue-50 text-blue-700 text-xs font-semibold mb-3">
          <span>Versión Web 2.0</span>
        </div>
        <h3 className="text-2xl font-bold text-slate-900 mb-2">Bienvenido a Altus Pv</h3>
        <p className="text-slate-600 text-sm max-w-3xl leading-relaxed">
          Plataforma moderna para la administración de Punto de Venta, facturación electrónica, catálogo de productos, emisión de remisiones, control de cuentas por cobrar y seguridad.
        </p>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        <Link 
          href="/dashboard/pedidos/nuevo"
          className="group bg-white border border-slate-200 rounded-2xl p-6 shadow-xs hover:border-blue-500 hover:shadow-md transition"
        >
          <div className="w-10 h-10 rounded-xl bg-blue-50 text-blue-600 flex items-center justify-center mb-4 group-hover:bg-blue-600 group-hover:text-white transition">
            <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M16 11V7a4 4 0 00-8 0v4M5 9h14l1 12H4L5 9z" />
            </svg>
          </div>
          <div className="text-xs uppercase tracking-wider text-slate-400 font-bold mb-1">Módulo</div>
          <div className="text-lg font-bold text-slate-900 group-hover:text-blue-600 transition">Pedidos & Ventas</div>
          <p className="text-xs text-slate-500 mt-2 leading-relaxed">Captura ágil de pedidos, cálculo automático de importes y emisión de tickets térmicos de 80 mm.</p>
        </Link>

        <Link 
          href="/dashboard/catalogos/productos"
          className="group bg-white border border-slate-200 rounded-2xl p-6 shadow-xs hover:border-emerald-500 hover:shadow-md transition"
        >
          <div className="w-10 h-10 rounded-xl bg-emerald-50 text-emerald-600 flex items-center justify-center mb-4 group-hover:bg-emerald-600 group-hover:text-white transition">
            <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M20 7l-8-4-8 4m16 0l-8 4m8-4v10l-8 4m0-10L4 7m8 4v10M4 7v10l8 4" />
            </svg>
          </div>
          <div className="text-xs uppercase tracking-wider text-slate-400 font-bold mb-1">Módulo</div>
          <div className="text-lg font-bold text-slate-900 group-hover:text-emerald-600 transition">Catálogos de Negocio</div>
          <p className="text-xs text-slate-500 mt-2 leading-relaxed">Control de más de 6,800 productos, precios de venta, grupos, departamentos y catálogo de clientes.</p>
        </Link>

        <Link 
          href="/dashboard/cobranza"
          className="group bg-white border border-slate-200 rounded-2xl p-6 shadow-xs hover:border-indigo-500 hover:shadow-md transition"
        >
          <div className="w-10 h-10 rounded-xl bg-indigo-50 text-indigo-600 flex items-center justify-center mb-4 group-hover:bg-indigo-600 group-hover:text-white transition">
            <svg className="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 8c-1.657 0-3 .895-3 2s1.343 2 3 2 3 .895 3 2-1.343 2-3 2m0-8c1.11 0 2.08.402 2.599 1M12 8V7m0 1v8m0 0v1m0-1c-1.11 0-2.08-.402-2.599-1M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
            </svg>
          </div>
          <div className="text-xs uppercase tracking-wider text-slate-400 font-bold mb-1">Módulo</div>
          <div className="text-lg font-bold text-slate-900 group-hover:text-indigo-600 transition">Cobranza & CxC</div>
          <p className="text-xs text-slate-500 mt-2 leading-relaxed">Registro de abonos, saldos a favor, estado de cuenta y cancelación de notas de remisión.</p>
        </Link>
      </div>
    </div>
  );
}
