using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
using CONTROLADORA = DOCUMENTACION.BD.Controladora;

namespace DOCUMENTACION.BD
{
    class USUARIO_BD
    {
        Controladora CONECT = new Controladora();

        public int loguear_User(String user, String Pass)
        {
            int aux=0;
            string CMD_TEXT = "PRO_Usuarios_Logueo";
            OleDbParameter[] parametros = new OleDbParameter[2];

            OleDbParameter pUsuario = new OleDbParameter();
            pUsuario.ParameterName = "@Usuario";
            pUsuario.Direction = ParameterDirection.Input;
            pUsuario.Value = user;
            parametros[0] = pUsuario;

            OleDbParameter pPassword = new OleDbParameter();
            pPassword.ParameterName = "@Password";
            pPassword.Direction = ParameterDirection.Input;
            pPassword.Value = Pass;
            parametros[1] = pPassword;
            aux = Convert.ToInt32(CONECT.ExecuteSQL_Sc(CMD_TEXT, parametros));
            return aux;
        }
    }
}
