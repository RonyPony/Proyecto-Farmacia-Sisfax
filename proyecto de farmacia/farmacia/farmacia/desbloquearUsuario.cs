using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace farmacia
{
    public partial class desbloquearUsuario : Form
    {
        public desbloquearUsuario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            validarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void validarDatos()
        {
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();

            ds.Tables.Add(dt);
            System.Data.SqlClient.SqlConnection conn =
                new System.Data.SqlClient.SqlConnection();
            // TODO: Modify the connection string and include any
            // additional required properties for your database.
            conn.ConnectionString =
            "integrated security=SSPI;data source=DESKTOP-5NFCGTG\\RONELCRUZ;" +
            "persist security info=False;initial catalog=sisfax";
            try
            {
                conn.Open();
                // Insert code to process data.
                //MessageBox.Show("conectado al servidor");

                String Consulta = "select contraseña,usuario from usuarios where contraseña='" + textBox2.Text + "' and usuario ='" + textBox1.Text + "';";
                SqlCommand Comando = new SqlCommand(Consulta, conn);
                SqlDataReader LectorDatos;
                LectorDatos = Comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean ExistenciaRegistros = LectorDatos.HasRows;

                if (ExistenciaRegistros)
                {
                    string usuario = textBox1.Text.ToUpper();
                    MessageBox.Show("Datos correctos; " + usuario +" será desbloqueado" , "Desbloqueo de usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    desbloquear();
                }
                else
                {
                    MessageBox.Show("contraseña o usuario incorrecto");
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al establecer la conexiòn con la base de datos; Por favor reinicie el sistema");
                //conectar();
            }
            finally
            {
                conn.Close();
            }
        }

        public void desbloquear()
        {
           
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            System.Data.SqlClient.SqlConnection conn =
                new System.Data.SqlClient.SqlConnection();
            // TODO: Modify the connection string and include any
            // additional required properties for your database.
            conn.ConnectionString =
            "integrated security=SSPI;data source=DESKTOP-5NFCGTG\\RONELCRUZ;" +
            "persist security info=False;initial catalog=sisfax";
            try
            {
                conn.Open();
                // Insert code to process data.
                //MessageBox.Show("conectado al servidor");

                string si = "";

                //if (comboBox1.Text == "F") { string sexo = "F"; } else if (comboBox1.Text == "M") { string sexo = "M"; }
                //String Consulta = "INSERT INTO USERS (bloqueada) VALUES('" + si + "')";
                String Consulta = "UPDATE usuarios SET estado = 'normal' WHERE usuario = '" + textBox1.Text + "';";
                //"select contraseña,usuario,tipo from users where contraseña='" + textBox2.Text + "' and usuario ='" + textBox1.Text + "' and tipo = '" + comboBox1.Text + "';";
                SqlCommand Comando = new SqlCommand(Consulta, conn);
                SqlDataReader LectorDatos;
                LectorDatos = Comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean ExistenciaRegistros = LectorDatos.HasRows;
                conn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }
        }
}
