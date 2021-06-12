using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CONTROLADORA = DOCUMENTACION.BD.Controladora;
using DOCUMENTO = DOCUMENTACION.Clases.Documentos;

namespace DOCUMENTACION.BD
{
    class STOCK_BD
    {
        CONTROLADORA CONECT = new CONTROLADORA();

        //STORED PARA DEVOLVER STOCK EN LA BASE DE DATOS (FORM MODIFICAR_STOCK Y LISTAR_STOCK)

        public DataTable devolver_todo()
        {
            string CMD_TEXT = "Pro_Pendiente_Listar";
            SqlParameter[] parametros = new SqlParameter[0];

            return CONECT.ExecuteSQL_2(CMD_TEXT, parametros);
        }

        //STORED PARA BUSCAR STOCK EN LA BASE DE DATOS (FORM BUSCAR_STOCK)

        public DataTable buscar(DOCUMENTO DOC)
        {
            string CMD_TEXT = "Pro_Pendiente_Buscar";
            SqlParameter[] parametros = new SqlParameter[5];

            SqlParameter pCODIGO = new SqlParameter();
            pCODIGO.ParameterName = "@CODIGO";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = DOC.Codigo;
            parametros[0] = pCODIGO;

            SqlParameter pNOMBRES = new SqlParameter();
            pNOMBRES.ParameterName = "@NOMBRES";
            pNOMBRES.Direction = ParameterDirection.Input;
            pNOMBRES.Value = DOC.Persona.Nombre;
            parametros[1] = pNOMBRES;

            SqlParameter pAPELLIDOS = new SqlParameter();
            pAPELLIDOS.ParameterName = "@APELLIDOS";
            pAPELLIDOS.Direction = ParameterDirection.Input;
            pAPELLIDOS.Value = DOC.Persona.Apellido;
            pAPELLIDOS.Value = " ";
            parametros[2] = pAPELLIDOS;

            SqlParameter pTIPO = new SqlParameter();
            pTIPO.ParameterName = "@ID_TIPO";
            pTIPO.Direction = ParameterDirection.Input;
            pTIPO.Value = DOC.Tipo;
            parametros[3] = pTIPO;

            SqlParameter pFECHA = new SqlParameter();
            pFECHA.ParameterName = "@FECHA";
            pFECHA.Direction = ParameterDirection.Input;
            pFECHA.Value = DOC.Fecha;;
            parametros[4] = pFECHA;

            return CONECT.ExecuteSQL_2(CMD_TEXT, parametros);
        }

        //STORED PARA ACTUALIZAR LA INFORMACION EN LA BASE DE DATOS (FORM MODIFICAR_STOCK)

        public void actualiza(DOCUMENTO DOC)
        {
            string CMD_TEXT = "Pro_Pendiente_Modificar";
            SqlParameter[] parametros = new SqlParameter[5];

            SqlParameter pCODIGO = new SqlParameter();
            pCODIGO.ParameterName = "@CODIGO";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = DOC.Codigo;
            parametros[0] = pCODIGO;

            SqlParameter pNOMBRES = new SqlParameter();
            pNOMBRES.ParameterName = "@NOMBRES";
            pNOMBRES.Direction = ParameterDirection.Input;
            pNOMBRES.Value = DOC.Persona.Nombre;
            parametros[1] = pNOMBRES;


            SqlParameter pAPELLIDOS = new SqlParameter();
            pAPELLIDOS.ParameterName = "@APELLIDOS";
            pAPELLIDOS.Direction = ParameterDirection.Input;
            pAPELLIDOS.Value = DOC.Persona.Apellido;
            parametros[2] = pAPELLIDOS;

            SqlParameter pFECHA_LLEGADA = new SqlParameter();
            pFECHA_LLEGADA.ParameterName = "@FECHA";
            pFECHA_LLEGADA.Direction = ParameterDirection.Input;
            pFECHA_LLEGADA.Value = DOC.Fecha;
            parametros[3] = pFECHA_LLEGADA;

            SqlParameter pTIPO = new SqlParameter();
            pTIPO.ParameterName = "@ID_TIPO";
            pTIPO.Direction = ParameterDirection.Input;
            pTIPO.Value = DOC.Tipo;
            parametros[4] = pTIPO;

            CONECT.ExecuteSQL(CMD_TEXT, parametros);
        }

        //STORED PARA GRABAR LA INFORMACION EN LA BASE DE DATOS (FORM CARGAR)

        public void grabar_informacion(DOCUMENTO DOC)
        {
            string CMD_TEXT = "Pro_Pendiente_Carga";
            SqlParameter[] parametros = new SqlParameter[5];

            SqlParameter pCODIGO = new SqlParameter();
            pCODIGO.ParameterName = "@CODIGO";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = DOC.Codigo;
            parametros[0] = pCODIGO;

            SqlParameter pNOMBRES = new SqlParameter();
            pNOMBRES.ParameterName = "@NOMBRES";
            pNOMBRES.Direction = ParameterDirection.Input;
            pNOMBRES.Value = DOC.Persona.Nombre;
            parametros[1] = pNOMBRES;

            SqlParameter pAPELLIDOS = new SqlParameter();
            pAPELLIDOS.ParameterName = "@APELLIDOS";
            pAPELLIDOS.Direction = ParameterDirection.Input;
            pAPELLIDOS.Value = DOC.Persona.Apellido;
            parametros[2] = pAPELLIDOS;

            if (DateTime.Today.Date >= DOC.Fecha.Date)
            {
                SqlParameter pFECHA_LLEGADA = new SqlParameter();
                pFECHA_LLEGADA.ParameterName = "@FECHA";
                pFECHA_LLEGADA.Direction = ParameterDirection.Input;
                pFECHA_LLEGADA.Value = DOC.Fecha;
                parametros[3] = pFECHA_LLEGADA;
            }
            else
                throw new ArgumentException("FECHA INCORRECTA");

            SqlParameter pTIPO = new SqlParameter();
            pTIPO.ParameterName = "@ID_TIPO";
            pTIPO.Direction = ParameterDirection.Input;
            pTIPO.Value = DOC.Tipo;
            parametros[4] = pTIPO;

            CONECT.ExecuteSQL(CMD_TEXT, parametros);
        }

        //STORED PARA VERIFICAR LOS CODIGOS (FORM CARGAR)

        public Int16 verifica_codigo(string codigo)
        {
            String CMD_TEXT = "Pro_Codigos_Buscar";
            SqlParameter[] parametros = new SqlParameter[1];

            SqlParameter pCODIGO = new SqlParameter();
            pCODIGO.ParameterName = "@Codigo";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = codigo;
            parametros[0] = pCODIGO;

            return Convert.ToInt16(CONECT.ExecuteSQL_4(CMD_TEXT, parametros));
        }

        //STORED PARA BUSCAR INFORMACION EN LA BASE DE DATOS (FORM ENTREGAR)

        public DataTable buscar_entrega_codigo(string codigo)
        {
            string CMD_TEXT = "Pro_Pendiente_Buscar";
            SqlParameter[] parametros = new SqlParameter[1];

            SqlParameter pCODIGO = new SqlParameter();
            pCODIGO.ParameterName = "@CODIGO";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = codigo;
            parametros[0] = pCODIGO;

            return CONECT.ExecuteSQL_2(CMD_TEXT, parametros);
        }
    }
}
