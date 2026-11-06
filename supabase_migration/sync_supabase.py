import os
import sys
import csv
import json
import re
from datetime import datetime
import urllib.request
import urllib.error

SUPABASE_URL = "https://zulnridrrztmgjdfmgjw.supabase.co/rest/v1"
API_KEY = os.environ.get("SUPABASE_SERVICE_ROLE_KEY", "")

# Mapeo de columnas CSV a columnas de Supabase
COLUMN_MAPS = {
    "aplicaciones": {
        "pk_aplicacion": "pk_aplicacion",
        "vchnombreapp": "vchnombreapp",
        "vchdescripcion": "vchdescripcion"
    },
    "permisos_usuarios": {
        "pk_permisousuario": "pk_permisousuario",
        "vchusuario": "vchusuario",
        "vchusuariosistema": "vchusuariosistema",
        "no_nomina": "no_nomina",
        "vchcorreo": "vchcorreo",
        "vchcontrasena": "vchcontrasena",
        "bitactivo": "bitactivo",
        "fk_plantel": "fk_plantel",
        "bitverificacion": "bitverificacion",
        "intautenticacion": "intautenticacion",
        "bitloggeado": "bitloggeado",
        "dttfechacreacion": "dttfechacreacion",
        "bitadmn": "bitadmn",
        "dtfechanacimiento": "dtfechanacimiento",
        "vchnombre": "vchnombre",
        "vchpaterno": "vchpaterno",
        "vchmaterno": "vchmaterno",
        "vchclavedepto": "vchclavedepto",
        "vchdescdepto": "vchdescdepto",
        "vchdescpuesto": "vchdescpuesto",
        "seguridadadmin": "seguridadadmin"
    },
    "menus": {
        "pk_menu": "pk_menu",
        "fk_aplicacion": "fk_aplicacion",
        "idpadre": "idpadre",
        "nombre": "nombre",
        "tipo": "tipo",
        "url": "url",
        "bactivo": "bactivo"
    },
    "menus_usuarios": {
        "pk_menuusuario": "pk_menuusuario",
        "fk_menu": "fk_menu",
        "fk_permisousuario": "fk_permisousuario"
    },
    "botones_menus": {
        "pk_botonmenu": "pk_botonmenu",
        "fk_menus": "fk_menus",
        "vchnombreboton": "vchnombreboton",
        "vchdescripcion": "vchdescripcion"
    },
    "permisos_usuarios_botones": {
        "pk_permisousuarioboton": "pk_permisousuarioboton",
        "fk_botonmenu": "fk_botonmenu",
        "fk_permisousuario": "fk_permisousuario"
    },
    "tss_grupo": {
        "pk_id_grupo": "pk_id_grupo",
        "vchclavegrupo": "vchclavegrupo",
        "vchnombre_grupo": "vchnombre",
        "bactivo": "bactivo"
    },
    "tss_departamento": {
        "pk_id_departamento": "pk_id_departamento",
        "vchclavedepartamento": "vchclavedepartamento",
        "vchnombre_departamento": "vchnombre",
        "bactivo": "bactivo"
    },
    "tss_datos_del_contribuyente": {
        "pk_id_datos": "pk_id_datos_contribuyente",
        "vchrazonsocial": "vchrazonsocial",
        "vchrfc": "vchrfc",
        "vchcalle": "vchcalle",
        "vchnoext": "vchnoext",
        "vchnoint": "vchnoint",
        "vchcolonia": "vchcolonia",
        "vchcodigopostal": "vchcodigopostal",
        "vchtelefono": "vchtelefono"
    },
    "tss_producto": {
        "pk_id_producto": "pk_id_producto",
        "vchclaveproducto": "vchclaveproducto",
        "vchnombre": "vchnombre",
        "vchlocalizacion": "vchlocalizacion",
        "bitarticulocondecimal": "bitarticulocondecimal",
        "vch_um_compra": "vch_um_compra",
        "vch_um_venta": "vch_um_venta",
        "vchcontenido": "vchcontenido",
        "intclavegrupo": "intclavegrupo",
        "intclavedepartamento": "intclavedepartamento",
        "vchinventariominimo": "vchinventariominimo",
        "vchinventariomaximo": "vchinventariomaximo",
        "bitproductoexento": "bitproductoexento",
        "fltieps": "fltieps",
        "fltiva": "fltiva",
        "fltpreciocompra": "fltpreciocompra",
        "ftl_margenutilidad_1": "ftl_margenutilidad_1",
        "flt_precioventa_1": "flt_precioventa_1",
        "ftl_margenutilidad_2": "ftl_margenutilidad_2",
        "flt_precioventa_2": "flt_precioventa_2",
        "ftl_margenutilidad_3": "ftl_margenutilidad_3",
        "flt_precioventa_3": "flt_precioventa_3",
        "vch_clave_unidad_medida": "vch_clave_unidad_medida",
        "vch_clave_prodservicio": "vch_clave_prodservicio",
        "bactivo": "bactivo"
    },
    "tss_cliente": {
        "pk_id_cliente": "pk_id_cliente",
        "vchconsecutivo_pv": "vchconsecutivo_pv",
        "vchcontacto": "vchcontacto",
        "vchnombre": "vchnombre",
        "vchcalle": "vchcalle",
        "vchnoexterior": "vchnoexterior",
        "vchnointerior": "vchnointerior",
        "vchcolonia": "vchcolonia",
        "vchciudad": "vchciudad",
        "vchcodigopostal": "vchcodigopostal",
        "vchmunicipio": "vchmunicipio",
        "vchestado": "vchestado",
        "vchpais": "vchpais",
        "vchemail": "vchemail",
        "vchtelefono": "vchtelefono",
        "vchtelefono_2": "vchtelefono_2",
        "vchrfc": "vchrfc",
        "vchlimitecredito": "vchlimitecredito",
        "intdiascredito": "intdiascredito",
        "vchnocuenta": "vchnocuenta",
        "bbloqueocliente": "bbloqueocliente",
        "vchmotivobloqueo": "vchmotivobloqueo",
        "bclienteexportacion": "bclienteexportacion",
        "intcostofactuacion": "intcostofactuacion",
        "fldescuento": "fldescuento",
        "vchcomentarios": "vchcomentarios",
        "bactivo": "bactivo"
    },
    "tss_generar_pedido": {
        "pk_id_genera_pedido": "pk_id_genera_pedido",
        "vchfolio": "vchfolio",
        "fk_id_usuario": "fk_id_usuario",
        "dtp_fechaventa": "dtp_fechaventa",
        "fk_id_cliente": "fk_id_cliente",
        "intdiascredito": "intdiascredito",
        "dtp_fechavencimientocredito": "dtp_fechavencimientocredito",
        "fk_metodo_pago": "fk_metodo_pago",
        "fk_forma_pago": "fk_forma_pago",
        "flt_totalventa": "flt_totalventa",
        "vchcomentario": "vchcomentario",
        "bactivo": "bactivo"
    },
    "tss_generar_pedido_detalle": {
        "pk_id_generar_pedido_detalle": "pk_id_generar_pedido_detalle",
        "fk_id_generar_pedido": "fk_id_generar_pedido",
        "fk_id_clave_producto": "fk_id_clave_producto",
        "vchcomentarioproducto": "vchcomentarioproducto",
        "fltcantidad": "fltcantidad",
        "vchumventa": "vchumventa",
        "fltprecioventa": "fltprecioventa",
        "dcdescuento": "dcdescuento",
        "fltimporte": "fltimporte",
        "bactivo": "bactivo"
    },
    "tss_nota_remision": {
        "pk_id_nota_remision": "pk_id_nota_remision",
        "fk_id_no_pedido": "fk_id_no_pedido",
        "dtp_fecha_nota_remision": "dtp_fecha_nota_remision",
        "fk_id_cajero": "fk_id_cajero",
        "vchestatus_nota_remision": "vchestatus_nota_remision",
        "bactivo": "bactivo"
    },
    "tss_registro_pago_cliente": {
        "pk_id_registro_pago_cliente": "pk_id_registro_pago_cliente",
        "fk_id_cliente": "fk_id_cliente",
        "fk_id_nota_remision": "fk_id_nota_remision",
        "flt_saldo_anterior": "flt_saldo_anterior",
        "flt_interes": "flt_interes",
        "flt_saldo_favor": "flt_saldo_favor",
        "flt_pago_aplicar": "flt_pago_aplicar",
        "flt_saldo_nuevo": "flt_saldo_nuevo",
        "dtp_fecha_timbrado": "dtp_fecha_timbrado",
        "bactivo": "bactivo"
    },
    "tss_registro_pago_cliente_detalle": {
        "pk_id_registro_pago_cliente_detalle": "pk_id_registro_pago_cliente_detalle",
        "fk_id_registro_pago_cliente": "fk_id_registro_pago_cliente",
        "fk_id_forma_pago": "fk_id_forma_pago",
        "flt_importe_pago": "flt_importe_pago",
        "flt_total_pago": "flt_total_pago",
        "flt_cambio_pago": "flt_cambio_pago",
        "bactivo": "bactivo"
    }
}

TABLES_ORDER = [
    ("aplicaciones", "Aplicaciones.csv"),
    ("permisos_usuarios", "Permisos_Usuarios.csv"),
    ("menus", "Menus.csv"),
    ("menus_usuarios", "MenusUsuarios.csv"),
    ("botones_menus", "Botones_menus.csv"),
    ("permisos_usuarios_botones", "Permisos_UsuariosBotones.csv"),
    ("tss_grupo", "Tss_Grupo.csv"),
    ("tss_departamento", "Tss_Departamento.csv"),
    ("tss_datos_del_contribuyente", "Tss_Datos_Del_Contribuyente.csv"),
    ("tss_producto", "Tss_Producto.csv"),
    ("tss_cliente", "Tss_Cliente.csv"),
    ("tss_generar_pedido", "Tss_Generar_Pedido.csv"),
    ("tss_generar_pedido_detalle", "Tss_Generar_Pedido_Detalle.csv"),
    ("tss_nota_remision", "Tss_Nota_Remision.csv"),
    ("tss_registro_pago_cliente", "Tss_Registro_Pago_Cliente.csv"),
    ("tss_registro_pago_cliente_detalle", "Tss_Registro_Pago_Cliente_Detalle.csv")
]

def parse_date_value(val_str):
    if not val_str:
        return None
    # Manejar formatos como 13/05/2016 04:36:01 p. m. o 2016-05-13
    cleaned = val_str.replace("p. m.", "PM").replace("a. m.", "AM").replace("p.m.", "PM").replace("a.m.", "AM").strip()
    
    # Intento 1: ISO directo
    if re.match(r'^\d{4}-\d{2}-\d{2}', cleaned):
        return cleaned

    # Intento 2: dd/mm/yyyy hh:mm:ss [AM/PM]
    match_12h = re.match(r'^(\d{1,2})/(\d{1,2})/(\d{4})\s+(\d{1,2}):(\d{2}):(\d{2})\s*(AM|PM)?', cleaned, re.IGNORECASE)
    if match_12h:
        d, m, y, hh, mm, ss, ampm = match_12h.groups()
        hour = int(hh)
        if ampm:
            if ampm.upper() == "PM" and hour < 12:
                hour += 12
            elif ampm.upper() == "AM" and hour == 12:
                hour = 0
        return f"{y}-{int(m):02d}-{int(d):02d}T{hour:02d}:{mm}:{ss}"

    # Intento 3: dd/mm/yyyy
    match_dmy = re.match(r'^(\d{1,2})/(\d{1,2})/(\d{4})', cleaned)
    if match_dmy:
        d, m, y = match_dmy.groups()
        return f"{y}-{int(m):02d}-{int(d):02d}"

    return cleaned

def clean_val(key, val):
    if val is None or val == "" or val == "NULL":
        return None
    val_str = str(val).strip()
    if val_str.lower() in ["true", "false"]:
        return val_str.lower() == "true"
    if "fecha" in key or "dtp" in key or "dtt" in key:
        return parse_date_value(val_str)
    return val_str

def upload_records(table_name, records):
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
            return True, len(records)
    except urllib.error.HTTPError as e:
        err_msg = e.read().decode("utf-8")
        return False, err_msg

def upload_table(table_name, csv_filename, csv_dir):
    file_path = os.path.join(csv_dir, csv_filename)
    if not os.path.exists(file_path):
        print(f"[SKIP] No existe archivo: {csv_filename}")
        return

    col_map = COLUMN_MAPS.get(table_name, {})
    print(f"\n---> Cargando {csv_filename} en '{table_name}'...")

    with open(file_path, mode="r", encoding="utf-8-sig") as f:
        reader = csv.reader(f)
        try:
            headers = next(reader)
        except StopIteration:
            return

        csv_headers = [h.strip().lower() for h in headers]
        
        records = []
        for row in reader:
            if not row or all(v.strip() == "" for v in row):
                continue
            rec = {}
            for h, v in zip(csv_headers, row):
                if h in col_map:
                    target_col = col_map[h]
                    rec[target_col] = clean_val(target_col, v)
            if rec:
                records.append(rec)

    total_uploaded = 0
    batch_size = 100
    for i in range(0, len(records), batch_size):
        chunk = records[i:i+batch_size]
        ok, res = upload_records(table_name, chunk)
        if ok:
            total_uploaded += len(chunk)
            print(f"  [OK] {total_uploaded}/{len(records)} filas...", end="\r")
        else:
            # Reintentar fila por fila si hay errores de llave o duplicados
            for single_rec in chunk:
                s_ok, s_res = upload_records(table_name, [single_rec])
                if s_ok:
                    total_uploaded += 1
            print(f"  [PARCIAL] {total_uploaded}/{len(records)} filas...", end="\r")

    print(f"  [COMPLETO] {total_uploaded}/{len(records)} filas en {table_name}.")

def main():
    csv_dir = os.path.join(os.path.dirname(os.path.abspath(__file__)), "csv")
    for tbl, csv_fn in TABLES_ORDER:
        upload_table(tbl, csv_fn, csv_dir)
    print("\n\n>>> CARGA TOTAL A SUPABASE FINALIZADA <<<")

if __name__ == "__main__":
    main()
