using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CONTROLADORA = DOCUMENTACION.BD.Controladora;

namespace DOCUMENTACION.BD
{
    class TIPO_BD
    {
        CONTROLADORA CONECT = new CONTROLADORA();

        public DataTable listar()
        {
            return CONECT.LeerDatos("Pro_Tipos_Listar");
        }

        public DataTable listar_todo()
        {
            return CONECT.LeerDatos("Pro_Tipos_Todo");
        }

        public DataTable listar_bajas()
        {
            return CONECT.LeerDatos("Pro_Tipos_Bajas");
        }

        public void agregar_tipo(string tipo)
        {
            string CMD_Text = "Pro_Tipos_Carga";
            SqlParameter[] p = new SqlParameter[1];

            SqlParameter pTipo = new SqlParameter();
            pTipo.ParameterName = "@Tipo";
            pTipo.Direction = ParameterDirection.Input;
            pTipo.Value = tipo;
            p[0] = pTipo;

            CONECT.ExecuteSQL(CMD_Text, p);
        }

        public void deshabilitar_tipo(int id_tipo)
        {
            string CMD_Text = "Pro_Tipos_Deshab";
            SqlParameter[] p = new SqlParameter[1];

            SqlParameter pTipo = new SqlParameter();
            pTipo.ParameterName = "@Id_tipo";
            pTipo.Direction = ParameterDirection.Input;
            pTipo.Value = id_tipo;
            p[0] = pTipo;

            CONECT.ExecuteSQL(CMD_Text, p);
        }

        public void habilitar_tipo(int id_tipo)
        {
            string CMD_Text = "Pro_Tipos_Rehab";
            SqlParameter[] p = new SqlParameter[1];

            SqlParameter pTipo = new SqlParameter();
            pTipo.ParameterName = "@Id_tipo";
            pTipo.Direction = ParameterDirection.Input;
            pTipo.Value = id_tipo;
            p[0] = pTipo;

            CONECT.ExecuteSQL(CMD_Text, p);
        }

        public void modificar_tipo(int id_tipo, string tipo)
        {
            string CMD_Text = "Pro_Tipos_Modificar";
            SqlParameter[] p = new SqlParameter[2];

            SqlParameter pIdTipo = new SqlParameter();
            pIdTipo.ParameterName = "@Id_tipo";
            pIdTipo.Direction = ParameterDirection.Input;
            pIdTipo.Value = id_tipo;
            p[0] = pIdTipo;

            SqlParameter pTipo = new SqlParameter();
            pTipo.ParameterName = "@Tipo";
            pTipo.Direction = ParameterDirection.Input;
            pTipo.Value = tipo;
            p[1] = pTipo;

            CONECT.ExecuteSQL(CMD_Text, p);
        }

        public int verifica_tipo(string tipo)
        {
            string CMD_Text = "Pro_Tipos_Buscar";
            SqlParameter[] p = new SqlParameter[1];

            SqlParameter pTipo = new SqlParameter();
            pTipo.ParameterName = "@Tipo";
            pTipo.Direction = ParameterDirection.Input;
            pTipo.Value = tipo;
            p[0] = pTipo;

            return Convert.ToInt32(CONECT.ExecuteSQL_4(CMD_Text, p));
        }

        public int get_idTipos(string nombre)
        {
            string CMD_TEXT = "Pro_Tipos_Buscar_2";
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
