import os
import sys
import csv
import json
import urllib.request
import urllib.error

SUPABASE_URL = "https://zulnridrrztmgjdfmgjw.supabase.co/rest/v1"
API_KEY = os.environ.get("SUPABASE_SERVICE_ROLE_KEY", "")

TABLE_MAP = [
    ("aplicaciones", "Aplicaciones.csv"),
    ("permisos_usuarios", "Permisos_Usuarios.csv"),
    ("menus", "Menus.csv"),
    ("menus_usuarios", "MenusUsuarios.csv"),
    ("botones_menus", "Botones_menus.csv"),
    ("permisos_usuarios_botones", "Permisos_UsuariosBotones.csv"),
    ("aplicaciones_usuarios", "AplicacionesUsuarios.csv"),
    ("tss_grupo", "Tss_Grupo.csv"),
    ("tss_departamento", "Tss_Departamento.csv"),
    ("tss_medidas_pesos", "Tss_Medidas_Pesos.csv"),
    ("tss_forma_pago", "Tss_Forma_Pago.csv"),
    ("tss_datos_del_contribuyente", "Tss_Datos_Del_Contribuyente.csv"),
    ("tss_producto", "Tss_Producto.csv"),
    ("tss_cliente", "Tss_Cliente.csv"),
    ("tss_generar_pedido", "Tss_Generar_Pedido.csv"),
    ("tss_generar_pedido_detalle", "Tss_Generar_Pedido_Detalle.csv"),
    ("tss_nota_remision", "Tss_Nota_Remision.csv"),
    ("tss_registro_pago_cliente", "Tss_Registro_Pago_Cliente.csv"),
    ("tss_registro_pago_cliente_detalle", "Tss_Registro_Pago_Cliente_Detalle.csv")
]

def clean_value(val):
    if val is None or val == "" or val == "NULL":
        return None
    val_str = str(val).strip()
    if val_str.lower() in ["true", "false"]:
        return val_str.lower() == "true"
    return val_str

def upload_batch(table_name, records):
    url = f"{SUPABASE_URL}/{table_name}"
    data = json.dumps(records).encode("utf-8")
    req = urllib.request.Request(url, data=data, method="POST", headers={
        "apikey": API_KEY,
        "Authorization": f"Bearer {API_KEY}",
        "Content-Type": "application/json",
        "Prefer": "resolution=ignore-duplicates"
    })
    try:
        with urllib.request.urlopen(req) as resp:
            return resp.status in (200, 201)
    except urllib.error.HTTPError as e:
        err_msg = e.read().decode("utf-8")
        print(f"Error subiendo a {table_name}: {e.code} - {err_msg}")
        return False

def main():
    csv_dir = os.path.join(os.path.dirname(os.path.abspath(__file__)), "csv")
    print(f"Iniciando carga de datos a Supabase...")

    for table_name, csv_filename in TABLE_MAP:
        file_path = os.path.join(csv_dir, csv_filename)
        if not os.path.exists(file_path):
            print(f"[SKIP] No existe archivo: {csv_filename}")
            continue

        print(f"\nProcesando {csv_filename} -> {table_name}...")
        with open(file_path, mode="r", encoding="utf-8-sig") as f:
            reader = csv.reader(f)
            try:
                headers = next(reader)
            except StopIteration:
                continue

            cleaned_headers = [h.strip().lower() for h in headers]
            
            batch = []
            total_inserted = 0
            batch_size = 200

            for row in reader:
                if not row or all(v.strip() == "" for v in row):
                    continue
                record = {}
                for h, v in zip(cleaned_headers, row):
                    record[h] = clean_value(v)
                batch.append(record)

                if len(batch) >= batch_size:
                    if upload_batch(table_name, batch):
                        total_inserted += len(batch)
                        print(f"  Insertados {total_inserted} registros...", end="\r")
                    batch = []

            if batch:
                if upload_batch(table_name, batch):
                    total_inserted += len(batch)

            print(f"  Finalizado: {total_inserted} registros en '{table_name}'.")

    print("\n=======================================================")
    print("MIGRACION DE DATOS A SUPABASE COMPLETADA CON EXITO")
    print("=======================================================")

if __name__ == "__main__":
    main()
