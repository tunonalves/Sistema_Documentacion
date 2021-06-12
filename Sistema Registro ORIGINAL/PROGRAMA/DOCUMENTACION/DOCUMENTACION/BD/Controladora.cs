using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DOCUMENTACION.BD
{
    class Controladora
    {
        SqlConnection CONECT = new SqlConnection();

        public void conectar()
        {
            if (CONECT.State == System.Data.ConnectionState.Closed)
            {
                CONECT.ConnectionString = "Data Source=NOTEBOOK;Initial Catalog=Registro2;Integrated Security=True";

                //CONECT.ConnectionString = "File Name = d:\\conexion.udl";

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
            SqlCommand cmd = new SqlCommand(cmdText, CONECT);
            DataTable dt = new DataTable();
            conectar();
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            desconectar();
            return dt;
        }

        public void ExecuteSQL_nonquery(string cmdText)
        {
            SqlCommand cmd = new SqlCommand(cmdText, CONECT);
            conectar();
            cmd.ExecuteNonQuery();
            desconectar();
        }

        public object ExecuteSQL_Sc(string cmdText, SqlParameter[] p)
        {
            object result = null;
            SqlCommand cmd = new SqlCommand(cmdText, CONECT);
            cmd.Parameters.AddRange(p);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar();
            result = cmd.ExecuteScalar();
            desconectar();
            return result;
        }

        public void ExecuteSQL(string cmdText, SqlParameter[] p)
        {
            SqlCommand cmd = new SqlCommand(cmdText, CONECT);
            cmd.Parameters.AddRange(p);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar();
            cmd.ExecuteNonQuery();
            desconectar();
        }

        public DataTable ExecuteSQL_2(string cmdText, SqlParameter[] p)
        {
            SqlCommand cmd = new SqlCommand(cmdText, CONECT);
            DataTable dt = new DataTable();
            cmd.Parameters.AddRange(p);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar();
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            cmd.ExecuteNonQuery();
            desconectar();
            return dt;
        }

        public int ExecuteSQL_3(string cmdText, SqlParameter[] p)
        {
            SqlCommand cmd = new SqlCommand(cmdText, CONECT);
            cmd.Parameters.AddRange(p);
            cmd.CommandType = CommandType.StoredProcedure;
            conectar();
            int aux = cmd.ExecuteNonQuery();
            desconectar();
            return aux;
        }

        public object ExecuteSQL_4(string cmdText, SqlParameter[] p)
        {
            object aux = 0;
            SqlCommand cmd = new SqlCommand(cmdText, CONECT);
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
            SqlCommand cmd = new SqlCommand(cmdText, CONECT);
            conectar();
            resul = cmd.ExecuteScalar();
            desconectar();
            return resul;
        }
    }
}
