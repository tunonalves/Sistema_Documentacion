using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
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
            OleDbParameter[] parametros = new OleDbParameter[0];

            return CONECT.ExecuteSQL_2(CMD_TEXT, parametros);
        }

        //STORED PARA GRABAR ENTREGAS EN LA BASE DE DATOS (FORM ENTREGAR)

        public Int64 entregar(string codigo, PERSONA PER)
        {
            string CMD_TEXT = "Pro_Entregar";
            OleDbParameter[] parametros = new OleDbParameter[7];

            OleDbParameter pCODIGO = new OleDbParameter();
            pCODIGO.ParameterName = "@CODIGO";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = codigo;
            parametros[0] = pCODIGO;

            OleDbParameter pMATRUCULA = new OleDbParameter();
            pMATRUCULA.ParameterName = "@MATRICULA";
            pMATRUCULA.Direction = ParameterDirection.Input;
            pMATRUCULA.Value = PER.Matricula;
            parametros[1] = pMATRUCULA;

            OleDbParameter pFECHA_ENTREGA = new OleDbParameter();
            pFECHA_ENTREGA.ParameterName = "@FECHA";
            pFECHA_ENTREGA.Direction = ParameterDirection.Input;
            pFECHA_ENTREGA.Value = DateTime.Today.Date;
            parametros[2] = pFECHA_ENTREGA;

            OleDbParameter pDIRECCION = new OleDbParameter();
            pDIRECCION.ParameterName = "@DIRECCION";
            pDIRECCION.Direction = ParameterDirection.Input;
            pDIRECCION.Value = PER.Direccion;
            parametros[3] = pDIRECCION;

            OleDbParameter pLOCALIDAD = new OleDbParameter();
            pLOCALIDAD.ParameterName = "@LOCALIDAD";
            pLOCALIDAD.Direction = ParameterDirection.Input;
            pLOCALIDAD.Value = PER.Localidad;
            parametros[4] = pLOCALIDAD;

            OleDbParameter pPROVINCIA = new OleDbParameter();
            pPROVINCIA.ParameterName = "@PROVINCIA";
            pPROVINCIA.Direction = ParameterDirection.Input;
            pPROVINCIA.Value = PER.Provincia;
            parametros[5] = pPROVINCIA;

            OleDbParameter pTELEFONO = new OleDbParameter();
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
            OleDbParameter[] parametros = new OleDbParameter[1];

            OleDbParameter pCODIGO = new OleDbParameter();
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
            OleDbParameter[] parametros = new OleDbParameter[9];

            OleDbParameter pCODIGO = new OleDbParameter();
            pCODIGO.ParameterName = "@CODIGO";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = DOC.Codigo;
            parametros[0] = pCODIGO;

            OleDbParameter pMATRICULA = new OleDbParameter();
            pMATRICULA.ParameterName = "@MATRICULA";
            pMATRICULA.Direction = ParameterDirection.Input;
            pMATRICULA.Value = DOC.Persona.Matricula;
            parametros[1] = pMATRICULA;

            OleDbParameter pNOMBRE = new OleDbParameter();
            pNOMBRE.ParameterName = "@NOMBRES";
            pNOMBRE.Direction = ParameterDirection.Input;
            pNOMBRE.Value = DOC.Persona.Nombre;
            parametros[2] = pNOMBRE;

            OleDbParameter pAPELLIDO = new OleDbParameter();
            pAPELLIDO.ParameterName = "@APELLIDOS";
            pAPELLIDO.Direction = ParameterDirection.Input;
            pAPELLIDO.Value = DOC.Persona.Apellido;
            parametros[3] = pAPELLIDO;

            OleDbParameter pTIPO = new OleDbParameter();
            pTIPO.ParameterName = "@ID_TIPO";
            pTIPO.Direction = ParameterDirection.Input;
            pTIPO.Value = DOC.Tipo;
            parametros[4] = pTIPO;

            OleDbParameter pPROVINCIA = new OleDbParameter();
            pPROVINCIA.ParameterName = "@ID_PROVINCIA";
            pPROVINCIA.Direction = ParameterDirection.Input;
            pPROVINCIA.Value = DOC.Persona.Provincia;
            parametros[5]= pPROVINCIA;

            OleDbParameter pFECHA = new OleDbParameter();
            pFECHA.ParameterName = "@FECHA";
            pFECHA.Direction = ParameterDirection.Input;
            pFECHA.Value = DOC.Fecha;
            parametros[6] = pFECHA;

            OleDbParameter pFECHA_ENTREGA = new OleDbParameter();
            pFECHA_ENTREGA.ParameterName = "@FECHA_ENTREGA";
            pFECHA_ENTREGA.Direction = ParameterDirection.Input;
            pFECHA_ENTREGA.Value = DOC.Fecha_entrega;
            parametros[7] = pFECHA_ENTREGA;

            OleDbParameter pLOCALIDAD = new OleDbParameter();
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
            OleDbParameter[] parametros = new OleDbParameter[3];

            OleDbParameter pCODIGO = new OleDbParameter();
            pCODIGO.ParameterName = "@CODIGO";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = codigo;
            parametros[0] = pCODIGO;

            OleDbParameter pMATRICULA = new OleDbParameter();
            pMATRICULA.ParameterName = "@MATRICULA";
            pMATRICULA.Direction = ParameterDirection.Input;
            pMATRICULA.Value = matricula;
            parametros[1] = pMATRICULA;

            OleDbParameter pFECHA_LLEGADA = new OleDbParameter();
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
            OleDbParameter[] parametros = new OleDbParameter[1];

            OleDbParameter pCODIGO = new OleDbParameter();
            pCODIGO.ParameterName = "@CODIGO";
            pCODIGO.Direction = ParameterDirection.Input;
            pCODIGO.Value = codigo;
            parametros[0] = pCODIGO;

            return CONECT.ExecuteSQL_2(CMD_TEXT, parametros);
        }
    }
}
