const API_URL = process.env.NEXT_PUBLIC_API_URL || "http://localhost:5000/api";

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
  inventario_Minimo?: string;
  inventario_Maximo?: string;
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
    method: "GET",
    headers: {
      "Authorization": `Bearer ${token}`,
      "Content-Type": "application/json",
    },
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
