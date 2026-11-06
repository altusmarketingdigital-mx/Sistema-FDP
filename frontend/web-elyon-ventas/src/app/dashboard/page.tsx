export default function DashboardHome() {
  return (
    <div className="space-y-6">
      <div className="bg-slate-900 border border-slate-800 rounded-xl p-6 shadow-sm">
        <h3 className="text-xl font-bold text-white mb-2">Bienvenido a Altus Pv</h3>
        <p className="text-slate-400 text-sm max-w-2xl leading-relaxed">
          Sistema integral de Punto de Venta, Pedidos, Facturación, Inventarios y Cuentas por Cobrar. Navega a través de los módulos disponibles en el menú lateral.
        </p>
      </div>

      <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
        <div className="bg-slate-900 border border-slate-800 rounded-xl p-6">
          <div className="text-xs uppercase tracking-wider text-slate-400 font-semibold mb-1">Módulo</div>
          <div className="text-lg font-bold text-white">Pedidos & Ventas</div>
          <p className="text-xs text-slate-500 mt-2">Captura de pedidos, folios y conversión a remisiones.</p>
        </div>

        <div className="bg-slate-900 border border-slate-800 rounded-xl p-6">
          <div className="text-xs uppercase tracking-wider text-slate-400 font-semibold mb-1">Módulo</div>
          <div className="text-lg font-bold text-white">Catálogos de Negocio</div>
          <p className="text-xs text-slate-500 mt-2">Gestión de productos, clientes, proveedores y vendedores.</p>
        </div>

        <div className="bg-slate-900 border border-slate-800 rounded-xl p-6">
          <div className="text-xs uppercase tracking-wider text-slate-400 font-semibold mb-1">Módulo</div>
          <div className="text-lg font-bold text-white">Cobranza & CxC</div>
          <p className="text-xs text-slate-500 mt-2">Abonos, estados de cuenta y cancelación de notas.</p>
        </div>
      </div>
    </div>
  );
}
