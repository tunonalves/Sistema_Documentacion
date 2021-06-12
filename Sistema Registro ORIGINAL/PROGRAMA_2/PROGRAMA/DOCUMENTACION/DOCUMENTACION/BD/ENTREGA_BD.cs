using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CONTROLADORA = DOCUMENTACION.BD.Controladora;
using PERSONA = DOCUMENTACION.Clases.Persona;
using DOCUMENTOS = DOCUMENTACION.Clases.Documentos;

namespace DOCUMENTACION.BD
{
    class ENTREGA_BD
    {
        CONTROLADORA CONECT = new CONTROLADORA();

        //STORED PARA DEVOLVER ENTREGAS EN LA BASE DE DATOS (FORM LISTAR_ENTREGA)

        public DataTable listar_entrega()
        {
            string CMD_TEXT = "Pro_Historico_Listar";
            SqlParameter[] parametros = new SqlParameter[0];

            return CONECT.ExecuteSQL_2(CMD_TEXT, parametros);
        }

        //STORED PARA GRABAR ENTREGAS EN LA BASE DE DATOS (FORM ENTREGAR)

        public Int64 entregar(string codigo, PERSONA PER)
        {
            string CMD_TEXT = "Pro_Entregar";
            SqlParameter[] parametros = new SqlParameter[7];

            SqlParameter pCODIGO = new SqlParameter();
            pCODIGO.ParameterName = "@CODIGO";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = codigo;
            parametros[0] = pCODIGO;

            SqlParameter pMATRUCULA = new SqlParameter();
            pMATRUCULA.ParameterName = "@MATRICULA";
            pMATRUCULA.Direction = ParameterDirection.Input;
            pMATRUCULA.Value = PER.Matricula;
            parametros[1] = pMATRUCULA;

            SqlParameter pFECHA_ENTREGA = new SqlParameter();
            pFECHA_ENTREGA.ParameterName = "@FECHA";
            pFECHA_ENTREGA.Direction = ParameterDirection.Input;
            pFECHA_ENTREGA.Value = DateTime.Today.Date;
            parametros[2] = pFECHA_ENTREGA;

            SqlParameter pDIRECCION = new SqlParameter();
            pDIRECCION.ParameterName = "@DIRECCION";
            pDIRECCION.Direction = ParameterDirection.Input;
            pDIRECCION.Value = PER.Direccion;
            parametros[3] = pDIRECCION;

            SqlParameter pLOCALIDAD = new SqlParameter();
            pLOCALIDAD.ParameterName = "@LOCALIDAD";
            pLOCALIDAD.Direction = ParameterDirection.Input;
            pLOCALIDAD.Value = PER.Localidad;
            parametros[4] = pLOCALIDAD;

            SqlParameter pPROVINCIA = new SqlParameter();
            pPROVINCIA.ParameterName = "@PROVINCIA";
            pPROVINCIA.Direction = ParameterDirection.Input;
            pPROVINCIA.Value = PER.Provincia;
            parametros[5] = pPROVINCIA;

            SqlParameter pTELEFONO = new SqlParameter();
            pTELEFONO.ParameterName = "@TELEFONO";
            pTELEFONO.Direction = ParameterDirection.Input;
            pTELEFONO.Value = PER.Telefono;
            parametros[6] = pTELEFONO;

            return CONECT.ExecuteSQL_3(CMD_TEXT, parametros);
        }

        //STORED PARA CANCELAR ENTREGAS EN LA BASE DE DATOS (FORM CANCELAR_ENTREGA)

        public void cancelar_entrega(string codigo)
        {
            string CMD_TEXT = "Pro_Historico_Cancelar";
            SqlParameter[] parametros = new SqlParameter[1];

            SqlParameter pCODIGO = new SqlParameter();
            pCODIGO.ParameterName = "@CODIGO";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = codigo;
            parametros[0] = pCODIGO;

            CONECT.ExecuteSQL_3(CMD_TEXT, parametros);
        }

        //STORED PARA BUSCAR ENTREGAS EN LA BASE DE DATOS (FORM BUSCAR_ENTREGA)

        public DataTable buscar(DOCUMENTOS DOC)
        {
            string CMD_TEXT = "Pro_Historico_Buscar";
            SqlParameter[] parametros = new SqlParameter[9];

            SqlParameter pCODIGO = new SqlParameter();
            pCODIGO.ParameterName = "@CODIGO";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = DOC.Codigo;
            parametros[0] = pCODIGO;

            SqlParameter pMATRICULA = new SqlParameter();
            pMATRICULA.ParameterName = "@MATRICULA";
            pMATRICULA.Direction = ParameterDirection.Input;
            pMATRICULA.Value = DOC.Persona.Matricula;
            parametros[1] = pMATRICULA;

            SqlParameter pNOMBRE = new SqlParameter();
            pNOMBRE.ParameterName = "@NOMBRES";
            pNOMBRE.Direction = ParameterDirection.Input;
            pNOMBRE.Value = DOC.Persona.Nombre;
            parametros[2] = pNOMBRE;

            SqlParameter pAPELLIDO = new SqlParameter();
            pAPELLIDO.ParameterName = "@APELLIDOS";
            pAPELLIDO.Direction = ParameterDirection.Input;
            pAPELLIDO.Value = DOC.Persona.Apellido;
            parametros[3] = pAPELLIDO;

            SqlParameter pTIPO = new SqlParameter();
            pTIPO.ParameterName = "@ID_TIPO";
            pTIPO.Direction = ParameterDirection.Input;
            pTIPO.Value = DOC.Tipo;
            parametros[4] = pTIPO;

            SqlParameter pPROVINCIA = new SqlParameter();
            pPROVINCIA.ParameterName = "@ID_PROVINCIA";
            pPROVINCIA.Direction = ParameterDirection.Input;
            pPROVINCIA.Value = DOC.Persona.Provincia;
            parametros[5]= pPROVINCIA;

            SqlParameter pFECHA = new SqlParameter();
            pFECHA.ParameterName = "@FECHA";
            pFECHA.Direction = ParameterDirection.Input;
            pFECHA.Value = DOC.Fecha;
            parametros[6] = pFECHA;

            SqlParameter pFECHA_ENTREGA = new SqlParameter();
            pFECHA_ENTREGA.ParameterName = "@FECHA_ENTREGA";
            pFECHA_ENTREGA.Direction = ParameterDirection.Input;
            pFECHA_ENTREGA.Value = DOC.Fecha_entrega;
            parametros[7] = pFECHA_ENTREGA;

            SqlParameter pLOCALIDAD = new SqlParameter();
            pLOCALIDAD.ParameterName = "@LOCALIDAD";
            pLOCALIDAD.Direction = ParameterDirection.Input;
            pLOCALIDAD.Value = DOC.Persona.Localidad;
            parametros[8] = pLOCALIDAD;

            return CONECT.ExecuteSQL_2(CMD_TEXT, parametros);
        }

        //STORED PARA ACTUALIZAR LA INFORMACION EN LA BASE DE DATOS (FORM MODIFICAR_STOCK)

        public void actualiza(string codigo, int matricula, DateTime fecha)
        {
            string CMD_TEXT = "Pro_Historico_Modificar";
            SqlParameter[] parametros = new SqlParameter[3];

            SqlParameter pCODIGO = new SqlParameter();
            pCODIGO.ParameterName = "@CODIGO";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = codigo;
            parametros[0] = pCODIGO;

            SqlParameter pMATRICULA = new SqlParameter();
            pMATRICULA.ParameterName = "@MATRICULA";
            pMATRICULA.Direction = ParameterDirection.Input;
            pMATRICULA.Value = matricula;
            parametros[1] = pMATRICULA;

            SqlParameter pFECHA_LLEGADA = new SqlParameter();
            pFECHA_LLEGADA.ParameterName = "@FECHA";
            pFECHA_LLEGADA.Direction = ParameterDirection.Input;
            pFECHA_LLEGADA.Value = fecha;
            parametros[2] = pFECHA_LLEGADA;

            CONECT.ExecuteSQL(CMD_TEXT, parametros);
        }

        //STORED PARA BUSCAR INFORMACION EN LA BASE DE DATOS (FORM MODIFICAR_ENTREGA)

        public DataTable buscar_entrega_codigo(string codigo)
        {
            string CMD_TEXT = "Pro_Historico_Buscar";
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
