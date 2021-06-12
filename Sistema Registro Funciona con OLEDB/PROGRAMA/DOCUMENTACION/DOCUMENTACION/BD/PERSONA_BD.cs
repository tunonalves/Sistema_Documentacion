using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using CONTROLADORA = DOCUMENTACION.BD.Controladora;
using PERSONA = DOCUMENTACION.Clases.Persona;

namespace DOCUMENTACION.BD
{
    class PERSONA_BD
    {
        CONTROLADORA CONECT = new CONTROLADORA();

        //STORED PARA LISTAR PERSONAS EN LA BASE DE DATOS (FORM MODIFICA_PERSONA)

        public DataTable devolver_persona()
        {
            string CMD_TEXT = "Pro_Personas_Listar";
            OleDbParameter[] parametros = new OleDbParameter[0];

            return CONECT.ExecuteSQL_2(CMD_TEXT, parametros);
        }

        //STORED PARA BUSCAR PERSONAS EN LA BASE DE DATOS (FORM MODIFICA_PERSONA)

        public DataTable buscar(PERSONA PER)
        {
            string CMD_TEXT = "Pro_Personas_Buscar";
            OleDbParameter[] parametros = new OleDbParameter[7];

            OleDbParameter pDNI = new OleDbParameter();
            pDNI.ParameterName = "@DNI";
            pDNI.Direction = ParameterDirection.Input;
            pDNI.Value = PER.Matricula;
            parametros[0] = pDNI;

            OleDbParameter pNOMBRE = new OleDbParameter();
            pNOMBRE.ParameterName = "@NOMBRES";
            pNOMBRE.Direction = ParameterDirection.Input;
            pNOMBRE.Value = PER.Nombre;
            parametros[1] = pNOMBRE;

            OleDbParameter pAPELLIDO = new OleDbParameter();
            pAPELLIDO.ParameterName = "@APELLIDOS";
            pAPELLIDO.Direction = ParameterDirection.Input;
            pAPELLIDO.Value = PER.Apellido;
            parametros[2] = pAPELLIDO;

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
            pPROVINCIA.ParameterName = "@ID_PROVINCIA";
            pPROVINCIA.Direction = ParameterDirection.Input;
            pPROVINCIA.Value = PER.Provincia;
            parametros[5] = pPROVINCIA;

            OleDbParameter pTELEFONO = new OleDbParameter();
            pTELEFONO.ParameterName = "@TELEFONO";
            pTELEFONO.Direction = ParameterDirection.Input;
            pTELEFONO.Value = PER.Telefono;
            parametros[6] = pTELEFONO;

            return CONECT.ExecuteSQL_2(CMD_TEXT, parametros);
        }

        //STORED PARA ACTUALIZAR PERSONAS EN LA BASE DE DATOS (FORM MODIFICA_PERSONA)

        public void actualiza(PERSONA PER)
        {
            string CMD_TEXT = "Pro_Personas_Modificar";
            OleDbParameter[] parametros = new OleDbParameter[7];

            OleDbParameter pDNI = new OleDbParameter();
            pDNI.ParameterName = "@DNI";
            pDNI.Direction = ParameterDirection.Input;
            pDNI.Value = PER.Matricula;
            parametros[0] = pDNI;

            OleDbParameter pNOMBRE = new OleDbParameter();
            pNOMBRE.ParameterName = "@NOMBRES";
            pNOMBRE.Direction = ParameterDirection.Input;
            pNOMBRE.Value = PER.Nombre;
            parametros[1] = pNOMBRE;

            OleDbParameter pAPELLIDO = new OleDbParameter();
            pAPELLIDO.ParameterName = "@APELLIDOS";
            pAPELLIDO.Direction = ParameterDirection.Input;
            pAPELLIDO.Value = PER.Apellido;
            parametros[2] = pAPELLIDO;

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
            pPROVINCIA.ParameterName = "@ID_PROVINCIA";
            pPROVINCIA.Direction = ParameterDirection.Input;
            pPROVINCIA.Value = PER.Provincia;
            parametros[5] = pPROVINCIA;

            OleDbParameter pTELEFONO = new OleDbParameter();
            pTELEFONO.ParameterName = "@TELEFONO";
            pTELEFONO.Direction = ParameterDirection.Input;
            pTELEFONO.Value = PER.Telefono;
            parametros[6] = pTELEFONO;

            CONECT.ExecuteSQL(CMD_TEXT, parametros);
        }
    }
}
