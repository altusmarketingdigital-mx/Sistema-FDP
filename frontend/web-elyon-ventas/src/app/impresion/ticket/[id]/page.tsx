"use client";

import { useEffect, useState, Suspense } from "react";
import { useParams } from "next/navigation";
import { fetchTicketPedidoApi, TicketData } from "@/lib/api";

function TicketContent() {
  const params = useParams();
  const idPedido = Number(params.id);

  const [ticket, setTicket] = useState<TicketData | null>(null);
  const [cargando, setCargando] = useState(true);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token || !idPedido) return;

    fetchTicketPedidoApi(token, idPedido)
      .then((data) => {
        setTicket(data);
        setCargando(false);
      })
      .catch((err) => {
        console.error(err);
        setCargando(false);
      });
  }, [idPedido]);

  const imprimir = () => {
    window.print();
  };

  if (cargando) {
    return <div className="p-8 text-center text-sm font-mono">Cargando formato de ticket 80mm...</div>;
  }

  if (!ticket) {
    return <div className="p-8 text-center text-sm font-mono text-red-600">No se encontró información del pedido.</div>;
  }

  return (
    <div className="bg-slate-100 min-h-screen py-8 flex flex-col items-center">
      {/* Botón flotante para mandar imprimir */}
      <div className="no-print mb-6 flex gap-4">
        <button
          onClick={imprimir}
          className="px-6 py-2.5 bg-emerald-600 hover:bg-emerald-500 text-white font-bold text-sm rounded-lg shadow-md transition flex items-center gap-2 cursor-pointer"
        >
          <span>🖨️ Mandar a Impresora Térmica</span>
        </button>
        <button
          onClick={() => window.close()}
          className="px-4 py-2.5 bg-slate-700 hover:bg-slate-600 text-white text-sm rounded-lg transition cursor-pointer"
        >
          Cerrar
        </button>
      </div>

      {/* Vista de Ticket Térmico 80 mm */}
      <div className="ticket-container bg-white text-black p-4 shadow-xl border border-gray-300 font-mono text-xs w-[320px]">
        {/* Cabecera */}
        <div className="text-center border-b border-dashed border-gray-400 pb-3 mb-3">
          <h1 className="text-sm font-bold uppercase tracking-wide">
            {ticket.empresa.razonSocial || "FRUTERÍA DEL PUERTO"}
          </h1>
          <p className="text-[11px] text-gray-700">RFC: {ticket.empresa.rfc || "FDP123456789"}</p>
          <p className="text-[10px] text-gray-600">{ticket.empresa.domicilio}</p>
          <p className="text-[10px] text-gray-600">Tel: {ticket.empresa.telefono}</p>
        </div>

        {/* Metadatos del Pedido */}
        <div className="text-[11px] space-y-1 border-b border-dashed border-gray-400 pb-2 mb-2">
          <div className="flex justify-between">
            <span className="font-bold">FOLIO:</span>
            <span>{ticket.encabezado.folio || `PED ${ticket.encabezado.id}`}</span>
          </div>
          <div className="flex justify-between">
            <span>FECHA:</span>
            <span>{ticket.encabezado.fecha} {ticket.encabezado.hora}</span>
          </div>
          <div className="flex justify-between">
            <span>CAJERO:</span>
            <span className="uppercase">{ticket.encabezado.cajero}</span>
          </div>
          {ticket.encabezado.condicion && (
            <div className="flex justify-between">
              <span>CONDICIÓN:</span>
              <span>{ticket.encabezado.condicion}</span>
            </div>
          )}
        </div>

        {/* Detalle de Productos */}
        <div className="mb-3">
          <table className="w-full text-[11px] text-left">
            <thead>
              <tr className="border-b border-gray-400">
                <th className="py-1">Cant.</th>
                <th className="py-1">Desc.</th>
                <th className="py-1 text-right">Importe</th>
              </tr>
            </thead>
            <tbody className="divide-y divide-dotted divide-gray-300">
              {ticket.articulos.map((art, i) => (
                <tr key={i}>
                  <td className="py-1.5 align-top w-12">{art.cantidad}</td>
                  <td className="py-1.5 align-top">
                    <div className="font-semibold">{art.descripcion}</div>
                    <div className="text-[10px] text-gray-500">
                      ${art.precio.toFixed(2)} c/u {art.descuento > 0 ? `(-$${art.descuento.toFixed(2)})` : ""}
                    </div>
                  </td>
                  <td className="py-1.5 align-top text-right font-bold">
                    ${art.importe.toFixed(2)}
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>

        {/* Totales */}
        <div className="border-t-2 border-black pt-2 space-y-1 text-right">
          <div className="text-base font-extrabold flex justify-between">
            <span>TOTAL:</span>
            <span>${ticket.total.toFixed(2)}</span>
          </div>
          {ticket.montoLetra && (
            <div className="text-[10px] text-left italic text-gray-700 mt-1">
              {ticket.montoLetra}
            </div>
          )}
        </div>

        {/* Pie de Ticket */}
        <div className="text-center text-[10px] text-gray-600 border-t border-dashed border-gray-400 mt-4 pt-3">
          <p className="font-bold">¡GRACIAS POR SU COMPRA!</p>
          <p className="mt-1">Favor de conservar este ticket para cualquier aclaración o remisión.</p>
        </div>
      </div>

      <style jsx global>{`
        @media print {
          body {
            background: white !important;
            padding: 0 !important;
            margin: 0 !important;
          }
          .no-print {
            display: none !important;
          }
          .ticket-container {
            border: none !important;
            box-shadow: none !important;
            width: 100% !important;
            max-width: 80mm !important;
            padding: 0 !important;
            margin: 0 !important;
          }
        }
      `}</style>
    </div>
  );
}

export default function TicketPrintPage() {
  return (
    <Suspense fallback={<div className="p-8 text-center text-sm font-mono">Cargando ticket...</div>}>
      <TicketContent />
    </Suspense>
  );
}
