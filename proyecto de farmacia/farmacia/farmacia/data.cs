using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace farmacia
{
    class data
    {
        public string getUserName(int id)
        {
            return "nada";
        }

        public string getSex(int id)
        {
            System.Data.SqlClient.SqlConnection conexion =
            new System.Data.SqlClient.SqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.farmaciaConnectionString;
            //MessageBox.Show("comienza proceso de extraccion de datos del sexo del usuario");
            conexion.Open();
            // MessageBox.Show("coneccion de base de datos establecida"); 
            String Consulta = "select sexo, codigo from informacionDelUsuario where userId= '" + idUsuario + "';";
            SqlCommand Comando = new SqlCommand(Consulta, conexion);
            SqlDataReader LectorDatos;
            LectorDatos = Comando.ExecuteReader();
            if (LectorDatos.Read())
            {
                conexion.Close();
                return LectorDatos["sexo"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["sexo"]);
                
            }
            
        }

        internal string getUserType(int id)
        {
            System.Data.SqlClient.SqlConnection conexion =
           new System.Data.SqlClient.SqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.farmaciaConnectionString;
            //MessageBox.Show("comienza proceso de extraccion de datos del sexo del usuario");
            conexion.Open();
            // MessageBox.Show("coneccion de base de datos establecida"); 
            String Consulta = "select sexo, codigo from informacionDelUsuario where userId= '" + idUsuario + "';";
            SqlCommand Comando = new SqlCommand(Consulta, conexion);
            SqlDataReader LectorDatos;
            LectorDatos = Comando.ExecuteReader();
            if (LectorDatos.Read())
            {
                conexion.Close();
                return LectorDatos["codigo"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["codigo"]);

            }
        }

        public string getUserCode(int id)
        {
            System.Data.SqlClient.SqlConnection conexion =
            new System.Data.SqlClient.SqlConnection();
            conexion.ConnectionString = Properties.Settings.Default.farmaciaConnectionString;
            //MessageBox.Show("comienza proceso de extraccion de datos del sexo del usuario");
            conexion.Open();
            // MessageBox.Show("coneccion de base de datos establecida"); 
            String Consulta = "select sexo, codigo from informacionDelUsuario where userId= '" + idUsuario + "';";
            SqlCommand Comando = new SqlCommand(Consulta, conexion);
            SqlDataReader LectorDatos;
            LectorDatos = Comando.ExecuteReader();
            if (LectorDatos.Read())
            {
                conexion.Close();
                return LectorDatos["codigo"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["codigo"]);
                
            }
        }
    }
}
