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

export interface MenuItem {
  PK_Menu: number;
  idPadre: number;
  nombre: string;
  tipo: string;
  url?: string;
  MenuHijo?: MenuItem[];
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
  if (!res.ok) {
    throw new Error("No se pudo obtener el menú del usuario");
  }
  return res.json();
}
