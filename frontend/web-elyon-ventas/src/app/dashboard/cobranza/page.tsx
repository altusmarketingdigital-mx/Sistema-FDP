"use client";

import { useEffect, useState } from "react";
import {
  fetchNotasSinPagoApi,
  registrarPagoClienteApi,
  NotaSinPago
} from "@/lib/api";

export default function RegistrarCobranzaPage() {
  const [notas, setNotas] = useState<NotaSinPago[]>([]);
  const [notaSeleccionada, setNotaSeleccionada] = useState<NotaSinPago | null>(null);

  const [saldoAnterior, setSaldoAnterior] = useState<number>(500);
  const [pagoAplicar, setPagoAplicar] = useState<number>(0);
  const [importeRecibido, setImporteRecibido] = useState<number>(0);
  const [formaPago, setFormaPago] = useState<number>(1); // 1 = Efectivo

  const [procesando, setProcesando] = useState(false);
  const [cargandoNotas, setCargandoNotas] = useState(true);
  const [mensaje, setMensaje] = useState<{ tipo: "exito" | "error"; texto: string } | null>(null);

  const cargarNotas = () => {
    const token = localStorage.getItem("token");
    if (!token) return;

    setCargandoNotas(true);
    fetchNotasSinPagoApi(token)
      .then((data) => {
        setNotas(data);
        if (data.length > 0) {
          setNotaSeleccionada(data[0]);
        }
      })
      .catch((err) => console.error(err))
      .finally(() => setCargandoNotas(false));
  };

  useEffect(() => {
    cargarNotas();
  }, []);

  const saldoNuevo = Math.max(0, saldoAnterior - pagoAplicar);
  const cambio = Math.max(0, importeRecibido - pagoAplicar);

  const handleCobrar = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!notaSeleccionada || pagoAplicar <= 0) {
      alert("Selecciona una nota y captura el importe a abonar.");
      return;
    }

    const token = localStorage.getItem("token");
    if (!token) return;

    setProcesando(true);
    setMensaje(null);

    try {
      const res = await registrarPagoClienteApi(token, {
        idCliente: 1, // Id general o del cliente asociado
        idNotaRemision: notaSeleccionada.no_Nota,
        saldoAnterior,
        interes: 0,
        saldoFavor: 0,
        pagoAplicar,
        formaPago,
        importeRecibido,
      });

      if (res.exito) {
        setMensaje({
          tipo: "exito",
          texto: `¡Abono registrado con éxito! Folio de Pago ID: ${res.idPago}. Nuevo Saldo: $${saldoNuevo.toFixed(2)}`
        });
        setPagoAplicar(0);
        setImporteRecibido(0);
        cargarNotas();
      } else {
        setMensaje({ tipo: "error", texto: res.mensaje || "Error al procesar el cobro." });
      }
    } catch (err: any) {
      setMensaje({ tipo: "error", texto: "Error de conexión al registrar pago." });
    } finally {
      setProcesando(false);
    }
  };

  return (
    <div className="space-y-6">
      <div className="flex flex-col md:flex-row md:items-center justify-between gap-4">
        <div>
          <h1 className="text-2xl font-bold text-slate-900">Recepción de Pagos & Cobranza</h1>
          <p className="text-sm text-slate-500">Registro de abonos a notas de remisión pendientes &bull; Cuentas por Cobrar</p>
        </div>
        <a
          href="/dashboard/cobranza/historial"
          className="px-4 py-2 bg-slate-800 hover:bg-slate-200 text-slate-700 text-sm font-medium rounded-lg border border-slate-300 transition self-start md:self-auto"
        >
          Historial de Pagos
        </a>
      </div>

      {mensaje && (
        <div className={`p-4 rounded-xl border text-sm flex items-center justify-between ${
          mensaje.tipo === "exito"
            ? "bg-emerald-500/10 border-emerald-500/20 text-emerald-300"
            : "bg-rose-500/10 border-rose-500/20 text-rose-300"
        }`}>
          <span>{mensaje.texto}</span>
        </div>
      )}

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
        {/* Formulario de Pago */}
        <div className="lg:col-span-1 bg-white border border-slate-200 rounded-xl p-6 shadow-sm">
          <h2 className="text-base font-bold text-slate-900 mb-4">Captura de Cobro</h2>

          <form onSubmit={handleCobrar} className="space-y-4">
            <div>
              <label className="block text-xs font-semibold text-slate-500 uppercase tracking-wider mb-2">
                Nota de Remisión Seleccionada
              </label>
              <div className="p-3 bg-slate-50 border border-slate-200 rounded-lg text-sm font-medium text-emerald-600">
                {notaSeleccionada 
                  ? `Nota #${notaSeleccionada.no_Nota} (${notaSeleccionada.no_Pedido})` 
                  : "Ninguna nota seleccionada"}
              </div>
              <p className="text-xs text-slate-500 mt-1">Cliente: {notaSeleccionada?.cliente || "—"}</p>
            </div>

            <div>
              <label className="block text-xs font-semibold text-slate-500 uppercase tracking-wider mb-2">
                Saldo Actual ($)
              </label>
              <input
                type="number"
                step="0.01"
                value={saldoAnterior}
                onChange={(e) => setSaldoAnterior(Number(e.target.value))}
                className="w-full px-3 py-2.5 bg-slate-50 border border-slate-300 rounded-lg text-slate-900 font-mono text-sm focus:outline-none focus:ring-2 focus:ring-emerald-500"
              />
            </div>

            <div>
              <label className="block text-xs font-semibold text-slate-500 uppercase tracking-wider mb-2">
                Importe a Abonar / Pagar ($)
              </label>
              <input
                type="number"
                step="0.01"
                min="0.01"
                required
                value={pagoAplicar}
                onChange={(e) => setPagoAplicar(Number(e.target.value))}
                className="w-full px-3 py-2.5 bg-slate-50 border border-emerald-500/40 rounded-lg text-slate-900 font-mono text-base font-bold focus:outline-none focus:ring-2 focus:ring-emerald-500"
              />
            </div>

            <div className="grid grid-cols-2 gap-3">
              <div>
                <label className="block text-xs font-semibold text-slate-500 uppercase tracking-wider mb-2">
                  Efectivo Recibido
                </label>
                <input
                  type="number"
                  step="0.01"
                  value={importeRecibido}
                  onChange={(e) => setImporteRecibido(Number(e.target.value))}
                  className="w-full px-3 py-2 bg-slate-50 border border-slate-300 rounded-lg text-slate-900 font-mono text-sm focus:outline-none focus:ring-2 focus:ring-emerald-500"
                />
              </div>
              <div>
                <label className="block text-xs font-semibold text-slate-500 uppercase tracking-wider mb-2">
                  Cambio
                </label>
                <div className="px-3 py-2 bg-slate-50 border border-slate-200 rounded-lg text-slate-700 font-mono text-sm font-semibold">
                  ${cambio.toFixed(2)}
                </div>
              </div>
            </div>

            <div className="pt-2 border-t border-slate-200 flex justify-between items-center text-sm">
              <span className="text-slate-500">Saldo Restante:</span>
              <span className="text-base font-extrabold text-slate-900 font-mono">${saldoNuevo.toFixed(2)}</span>
            </div>

            <button
              type="submit"
              disabled={procesando || !notaSeleccionada || pagoAplicar <= 0}
              className="w-full py-3 bg-emerald-600 hover:bg-emerald-500 disabled:opacity-50 text-slate-900 font-bold text-sm rounded-lg shadow-lg shadow-blue-600/25 transition mt-2"
            >
              {procesando ? "Registrando cobro..." : "Aplicar Abono"}
            </button>
          </form>
        </div>

        {/* Lista de Notas de Remisión con Saldo */}
        <div className="lg:col-span-2 bg-white border border-slate-200 rounded-xl overflow-hidden shadow-sm flex flex-col">
          <div className="p-4 bg-slate-50 border-b border-slate-200 flex items-center justify-between">
            <span className="text-xs font-semibold text-slate-500 uppercase tracking-wider">
              Notas de Remisión Pendientes de Cobro ({notas.length})
            </span>
          </div>

          <div className="flex-1 overflow-x-auto">
            {cargandoNotas ? (
              <div className="p-8 text-center text-slate-500 text-sm">Consultando cartera pendiente en SQL Server...</div>
            ) : notas.length === 0 ? (
              <div className="p-8 text-center text-slate-500 text-sm">No hay notas pendientes de cobro.</div>
            ) : (
              <table className="w-full text-left text-sm text-slate-700">
                <thead className="bg-slate-50 text-xs uppercase text-slate-500 border-b border-slate-200">
                  <tr>
                    <th className="px-5 py-3 font-semibold">Nota</th>
                    <th className="px-5 py-3 font-semibold">Pedido</th>
                    <th className="px-5 py-3 font-semibold">Cliente</th>
                    <th className="px-5 py-3 font-semibold">Fecha</th>
                    <th className="px-5 py-3 font-semibold text-right">Acción</th>
                  </tr>
                </thead>
                <tbody className="divide-y divide-slate-100">
                  {notas.map((n) => {
                    const esSeleccionada = notaSeleccionada?.no_Nota === n.no_Nota;
                    return (
                      <tr
                        key={n.no_Nota}
                        className={`transition cursor-pointer ${
                          esSeleccionada ? "bg-emerald-500/10 text-slate-900" : "hover:bg-slate-50"
                        }`}
                        onClick={() => setNotaSeleccionada(n)}
                      >
                        <td className="px-5 py-3 font-mono font-bold text-emerald-600 text-xs">#{n.no_Nota}</td>
                        <td className="px-5 py-3 font-mono text-xs text-slate-500">{n.no_Pedido}</td>
                        <td className="px-5 py-3 font-medium">{n.cliente}</td>
                        <td className="px-5 py-3 text-xs text-slate-500">
                          {new Date(n.fecha_Remision).toLocaleDateString()}
                        </td>
                        <td className="px-5 py-3 text-right">
                          <button
                            type="button"
                            onClick={(e) => {
                              e.stopPropagation();
                              setNotaSeleccionada(n);
                            }}
                            className={`px-3 py-1 text-xs rounded font-semibold transition ${
                              esSeleccionada
                                ? "bg-emerald-600 text-slate-900"
                                : "bg-slate-800 text-slate-700 hover:bg-slate-200"
                            }`}
                          >
                            {esSeleccionada ? "Seleccionada" : "Cobrar"}
                          </button>
                        </td>
                      </tr>
                    );
                  })}
                </tbody>
              </table>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}
