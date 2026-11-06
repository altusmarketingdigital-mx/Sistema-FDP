const API_URL = process.env.NEXT_PUBLIC_API_URL || "http://localhost:5050/api";

export interface LoginResponse {
  exito: boolean;
  mensaje: string;
  token?: string;
  usuario?: {
    idUsuario: number;
    usuario: string;
    nombreCompleto: string;
    nomina: string;
    correo: string;
    esAdmin: boolean;
  };
}

export interface Producto {
  id: number;
  clave: string;
  producto: string;
  precio_Venta_1: number;
  uM_Venta: string;
  tiene_Decimal: boolean;
}

export interface Cliente {
  pK_Id_Cliente: number;
  vchNombre: string;
  vchRFC?: string;
  vchTelefono?: string;
  vchLimiteCredito?: string;
  intDiasCredito: number;
  bBloqueoCliente: boolean;
  flDescuento: number;
}

export interface PartidaPedido {
  claveProducto: string;
  nombreProducto: string;
  cantidad: number;
  umVenta: string;
  precioVenta: number;
  descuento: number;
  importe: number;
  comentarioProducto?: string;
}

export interface GuardarPedidoPayload {
  folio: string;
  idCliente: number;
  diasCredito: number;
  metodoPago: number;
  comentario: string;
  partidas: PartidaPedido[];
}

export interface PedidoHistorial {
  id_Pedido: number;
  folio: string;
  id: string;
  id_Cajero: number;
  fecha_Venta: string;
  id_Cliente: number;
  nombre_Cliente: string;
  dias_Credito: number;
  vencha_Vencimiento?: string;
}

export interface TicketData {
  encabezado: {
    id: number;
    folio: string;
    fecha: string;
    hora: string;
    condicion: string;
    cajero: string;
    comentario: string;
  };
  empresa: {
    razonSocial: string;
    rfc: string;
    domicilio: string;
    colonia: string;
    cp: string;
    telefono: string;
  };
  articulos: {
    clave: string;
    descripcion: string;
    cantidad: string;
    precio: number;
    descuento: number;
    importe: number;
  }[];
  total: number;
  montoLetra: string;
}

export interface NotaSinPago {
  no_Nota: number;
  no_Pedido: string;
  cliente: string;
  cajero: string;
  fecha_Remision: string;
  fecha_Venta: string;
  fecha_Vencimiento: string;
  dias_Credito: number;
}

export interface PagoHistorial {
  id: number;
  idcliente: number;
  nombre: string;
  idnota: number;
  saldO_ANTERIOR: number;
  saldO_NUEVO: number;
  fechatimbrado: string;
}

export async function loginApi(usuario: string, contrasena: string): Promise<LoginResponse> {
  const res = await fetch(`${API_URL}/auth/login`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ usuario, contrasena }),
  });
  return res.json();
}

export async function fetchMenuApi(token: string): Promise<any> {
  const res = await fetch(`${API_URL}/auth/menu`, {
    headers: { "Authorization": `Bearer ${token}` },
  });
  if (!res.ok) throw new Error("No se pudo obtener el menú del usuario");
  return res.json();
}

export async function fetchProductosApi(token: string, filtro?: string): Promise<Producto[]> {
  const url = filtro ? `${API_URL}/catalogos/productos?filtro=${encodeURIComponent(filtro)}` : `${API_URL}/catalogos/productos`;
  const res = await fetch(url, {
    headers: { "Authorization": `Bearer ${token}` }
  });
  if (!res.ok) throw new Error("Error al consultar productos");
  return res.json();
}

export async function fetchClientesApi(token: string, filtro?: string): Promise<Cliente[]> {
  const url = filtro ? `${API_URL}/catalogos/clientes?filtro=${encodeURIComponent(filtro)}` : `${API_URL}/catalogos/clientes`;
  const res = await fetch(url, {
    headers: { "Authorization": `Bearer ${token}` }
  });
  if (!res.ok) throw new Error("Error al consultar clientes");
  return res.json();
}

export async function guardarPedidoApi(token: string, payload: GuardarPedidoPayload) {
  const res = await fetch(`${API_URL}/ventas/pedidos`, {
    method: "POST",
    headers: {
      "Authorization": `Bearer ${token}`,
      "Content-Type": "application/json"
    },
    body: JSON.stringify(payload)
  });
  return res.json();
}

export async function fetchHistorialPedidosApi(token: string): Promise<PedidoHistorial[]> {
  const res = await fetch(`${API_URL}/ventas/pedidos`, {
    headers: { "Authorization": `Bearer ${token}` }
  });
  if (!res.ok) throw new Error("Error al obtener historial de pedidos");
  return res.json();
}

export async function fetchTicketPedidoApi(token: string, idPedido: number): Promise<TicketData> {
  const res = await fetch(`${API_URL}/ventas/pedidos/${idPedido}/ticket`, {
    headers: { "Authorization": `Bearer ${token}` }
  });
  if (!res.ok) throw new Error("Error al obtener datos del ticket");
  return res.json();
}

export async function fetchNotasSinPagoApi(token: string): Promise<NotaSinPago[]> {
  const res = await fetch(`${API_URL}/cobranza/notas-sin-pago`, {
    headers: { "Authorization": `Bearer ${token}` }
  });
  if (!res.ok) throw new Error("Error al consultar notas sin pago");
  return res.json();
}

export async function fetchHistorialPagosApi(token: string): Promise<PagoHistorial[]> {
  const res = await fetch(`${API_URL}/cobranza/pagos`, {
    headers: { "Authorization": `Bearer ${token}` }
  });
  if (!res.ok) throw new Error("Error al consultar historial de pagos");
  return res.json();
}

export async function registrarPagoClienteApi(token: string, payload: any) {
  const res = await fetch(`${API_URL}/cobranza/pagos`, {
    method: "POST",
    headers: {
      "Authorization": `Bearer ${token}`,
      "Content-Type": "application/json"
    },
    body: JSON.stringify(payload)
  });
  return res.json();
}

export async function cancelarNotaRemisionApi(token: string, idNotaRemision: number, motivo: string) {
  const res = await fetch(`${API_URL}/cobranza/cancelar-remision`, {
    method: "POST",
    headers: {
      "Authorization": `Bearer ${token}`,
      "Content-Type": "application/json"
    },
    body: JSON.stringify({ idNotaRemision, motivo })
  });
  return res.json();
}
