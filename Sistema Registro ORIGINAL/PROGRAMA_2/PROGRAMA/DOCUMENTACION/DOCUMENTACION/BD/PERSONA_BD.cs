using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
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
            SqlParameter[] parametros = new SqlParameter[0];

            return CONECT.ExecuteSQL_2(CMD_TEXT, parametros);
        }

        //STORED PARA BUSCAR PERSONAS EN LA BASE DE DATOS (FORM MODIFICA_PERSONA)

        public DataTable buscar(PERSONA PER)
        {
            string CMD_TEXT = "Pro_Personas_Buscar";
            SqlParameter[] parametros = new SqlParameter[7];

            SqlParameter pDNI = new SqlParameter();
            pDNI.ParameterName = "@DNI";
            pDNI.Direction = ParameterDirection.Input;
            pDNI.Value = PER.Matricula;
            parametros[0] = pDNI;

            SqlParameter pNOMBRE = new SqlParameter();
            pNOMBRE.ParameterName = "@NOMBRES";
            pNOMBRE.Direction = ParameterDirection.Input;
            pNOMBRE.Value = PER.Nombre;
            parametros[1] = pNOMBRE;

            SqlParameter pAPELLIDO = new SqlParameter();
            pAPELLIDO.ParameterName = "@APELLIDOS";
            pAPELLIDO.Direction = ParameterDirection.Input;
            pAPELLIDO.Value = PER.Apellido;
            parametros[2] = pAPELLIDO;

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
            pPROVINCIA.ParameterName = "@ID_PROVINCIA";
            pPROVINCIA.Direction = ParameterDirection.Input;
            pPROVINCIA.Value = PER.Provincia;
            parametros[5] = pPROVINCIA;

            SqlParameter pTELEFONO = new SqlParameter();
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
            SqlParameter[] parametros = new SqlParameter[7];

            SqlParameter pDNI = new SqlParameter();
            pDNI.ParameterName = "@DNI";
            pDNI.Direction = ParameterDirection.Input;
            pDNI.Value = PER.Matricula;
            parametros[0] = pDNI;

            SqlParameter pNOMBRE = new SqlParameter();
            pNOMBRE.ParameterName = "@NOMBRES";
            pNOMBRE.Direction = ParameterDirection.Input;
            pNOMBRE.Value = PER.Nombre;
            parametros[1] = pNOMBRE;

            SqlParameter pAPELLIDO = new SqlParameter();
            pAPELLIDO.ParameterName = "@APELLIDOS";
            pAPELLIDO.Direction = ParameterDirection.Input;
            pAPELLIDO.Value = PER.Apellido;
            parametros[2] = pAPELLIDO;

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
            pPROVINCIA.ParameterName = "@ID_PROVINCIA";
            pPROVINCIA.Direction = ParameterDirection.Input;
            pPROVINCIA.Value = PER.Provincia;
            parametros[5] = pPROVINCIA;

            SqlParameter pTELEFONO = new SqlParameter();
            pTELEFONO.ParameterName = "@TELEFONO";
            pTELEFONO.Direction = ParameterDirection.Input;
            pTELEFONO.Value = PER.Telefono;
            parametros[6] = pTELEFONO;

            CONECT.ExecuteSQL(CMD_TEXT, parametros);
        }
    }
}
