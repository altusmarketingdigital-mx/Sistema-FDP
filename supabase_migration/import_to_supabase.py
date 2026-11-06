import os
import sys
import csv
import psycopg2

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

def import_data(connection_string):
    csv_dir = os.path.join(os.path.dirname(os.path.abspath(__file__)), "csv")
    print(f"Conectando a Supabase PostgreSQL...")
    conn = psycopg2.connect(connection_string)
    cur = conn.cursor()

    for table_name, csv_filename in TABLE_MAP:
        file_path = os.path.join(csv_dir, csv_filename)
        if not os.path.exists(file_path):
            print(f"[SKIP] No encontrado: {csv_filename}")
            continue

        print(f"Importando {csv_filename} -> {table_name}...")
        with open(file_path, mode="r", encoding="utf-8-sig") as f:
            reader = csv.reader(f)
            headers = next(reader)
            # Sanitizar nombres de columnas a snake_case si aplica o comillas dobles
            cols_clause = ", ".join([f'"{h.strip().lower()}"' for h in headers])
            placeholders = ", ".join(["%s"] * len(headers))
            insert_sql = f'INSERT INTO {table_name} ({cols_clause}) VALUES ({placeholders}) ON CONFLICT DO NOTHING'
            
            rows = []
            for row in reader:
                sanitized_row = [None if val == "" else val for val in row]
                rows.append(sanitized_row)
            
            if rows:
                cur.executemany(insert_sql, rows)
                conn.commit()
                print(f"  -> {len(rows)} registros procesados.")

    cur.close()
    conn.close()
    print("\nMigración a Supabase completada con éxito.")

if __name__ == "__main__":
    if len(sys.argv) < 2:
        print("Uso: python import_to_supabase.py \"postgresql://postgres:[PASSWORD]@[HOST]:5432/postgres\"")
        sys.exit(1)
    import_data(sys.argv[1])
