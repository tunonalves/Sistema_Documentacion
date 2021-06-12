using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace DOCUMENTACION.BD
{
    class Controladora
    {
        OleDbConnection CONECT = new OleDbConnection();

        public void conectar()
        {
            if (CONECT.State == System.Data.ConnectionState.Closed)
            {

                //CONECT.ConnectionString = "Data Source=127.0.0.1;Initial Catalog=Registro2;Integrated Security=True"; Funciona con SqlConection

                //CONECT.ConnectionString = "Server=172.16.1.35\\SQLEXPRESS; database=Registro2;User= metodologia2012;PassWord= 654321;"; Funciona con SqlConection

                //CONECT.ConnectionString = "File Name = C:\\Program Files (x86)\\Documentación Setup\\Documentación Setup\\conexion.udl"; // Funciona con OleDbConnection

                CONECT.ConnectionString = "File Name = C:\\conexion.udl";

                //string aux = System.IO.Directory.GetCurrentDirectory();
                //CONECT.ConnectionString = "File Name =" + aux + "/conexion.udl";

                CONECT.Open();
            }
            else
            {
                throw new Exception("Error en la Conexión");
            }
        }
        public void desconectar()
        {
            if (CONECT.State == System.Data.ConnectionState.Open)
            {
                CONECT.Close();
            }
        }
        public DataTable LeerDatos(string cmdText)
        {
            OleDbCommand cmd = new OleDbCommand(cmdText, CONECT);
            DataTable dt = new DataTable();
            conectar();
            OleDbDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            desconectar();
            return dt;
        }

        public void ExecuteSQL_nonquery(string cmdText)
        {
            OleDbCommand cmd = new OleDbCommand(cmdText, CONECT);
            conectar();
            cmd.ExecuteNonQuery();
            desconectar();
        }

        public object ExecuteSQL_Sc(string cmdText, OleDbParameter[] p)
        {
            object result = null;
            OleDbCommand cmd = new OleDbCommand(cmdText, CONECT);
            cmd.Parameters.AddRange(p);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar();
            result = cmd.ExecuteScalar();
            desconectar();
            return result;
        }

        public void ExecuteSQL(string cmdText, OleDbParameter[] p)
        {
            OleDbCommand cmd = new OleDbCommand(cmdText, CONECT);
            cmd.Parameters.AddRange(p);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar();
            cmd.ExecuteNonQuery();
            desconectar();
        }

        public DataTable ExecuteSQL_2(string cmdText, OleDbParameter[] p)
        {
            OleDbCommand cmd = new OleDbCommand(cmdText, CONECT);
            DataTable dt = new DataTable();
            cmd.Parameters.AddRange(p);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar();
            OleDbDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            cmd.ExecuteNonQuery();
            desconectar();
            return dt;
        }

        public int ExecuteSQL_3(string cmdText, OleDbParameter[] p)
        {
            OleDbCommand cmd = new OleDbCommand(cmdText, CONECT);
            cmd.Parameters.AddRange(p);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar();
            int aux = cmd.ExecuteNonQuery();
            desconectar();
            return aux;
        }

        public object ExecuteSQL_4(string cmdText, OleDbParameter[] p)
        {
            object aux = 0;
            OleDbCommand cmd = new OleDbCommand(cmdText, CONECT);
            cmd.Parameters.AddRange(p);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar();
            aux = cmd.ExecuteScalar();
            desconectar();
            return aux;
        }

        public object DevolverObjeto(string cmdText)
        {
            object resul = null;
            OleDbCommand cmd = new OleDbCommand(cmdText, CONECT);
            conectar();
            resul = cmd.ExecuteScalar();
            desconectar();
            return resul;
        }
    }
}
