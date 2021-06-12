using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CONTROLADORA = DOCUMENTACION.BD.Controladora;

namespace DOCUMENTACION.BD
{
    class PROVINCIAS_BD
    {
        CONTROLADORA CONECT = new CONTROLADORA();

        public DataTable lista_provincia()
        {
            return CONECT.LeerDatos("Pro_Provincias_Listar");
        }

        public int get_idProvincia(string nombre)
        {
            string CMD_TEXT = "Pro_Provincias_Buscar";
            SqlParameter[] p = new SqlParameter[1];

            SqlParameter pNombre = new SqlParameter();
            pNombre.Direction = ParameterDirection.Input;
            pNombre.Value = nombre;
            pNombre.ParameterName = "@nombre";
            p[0] = pNombre;

            return Convert.ToInt32(CONECT.ExecuteSQL_4(CMD_TEXT, p));
        }
    }
}
