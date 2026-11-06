import os
import sys
import psycopg2

def execute_ddl(connection_string):
    sql_path = os.path.join(os.path.dirname(os.path.abspath(__file__)), "01_schema_supabase.sql")
    print(f"Leyendo DDL desde {sql_path}...")
    with open(sql_path, "r", encoding="utf-8") as f:
        ddl_content = f.read()

    print("Conectando a Supabase PostgreSQL...")
    conn = psycopg2.connect(connection_string)
    cur = conn.cursor()
    print("Ejecutando DDL en Supabase...")
    cur.execute(ddl_content)
    conn.commit()
    print("DDL ejecutado y tablas creadas exitosamente.")
    cur.close()
    conn.close()

if __name__ == "__main__":
    conn_str = sys.argv[1] if len(sys.argv) > 1 else os.environ.get("SUPABASE_DB_URL")
    if not conn_str:
        print("Cadena de conexión no proporcionada.")
        sys.exit(1)
    execute_ddl(conn_str)
