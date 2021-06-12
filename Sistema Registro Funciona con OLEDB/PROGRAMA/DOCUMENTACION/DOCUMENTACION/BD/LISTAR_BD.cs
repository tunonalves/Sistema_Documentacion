using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using CONTROLADORA = DOCUMENTACION.BD.Controladora;

namespace DOCUMENTACION.BD
{
    class LISTAR_BD
    {
        CONTROLADORA CONECT = new CONTROLADORA();

        public DataTable devolver_todo()
        {
            string CMD_TEXT = "Pro_Completo_Listar";
            OleDbParameter[] parametros = new OleDbParameter[0];

            return CONECT.ExecuteSQL_2(CMD_TEXT, parametros);
        }
    }
}
