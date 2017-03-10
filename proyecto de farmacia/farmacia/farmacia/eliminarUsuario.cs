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
    public partial class eliminarUsuario : Form
    {
        public eliminarUsuario()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void eliminarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void conectar()
        {

            //string nombreusuario = textBox1.Text;
            //string contraseñausuario = textBox2.Text;
            //string tipousuario = comboBox1.Text;
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
           // try
            {
                conn.Open();
                // Insert code to process data.
                //MessageBox.Show("conectado al servidor");

                String Consulta = "select contraseña,usuario,tipo, codigo from usuarios where contraseña='" + textBox2.Text + "' and usuario ='" + textBox1.Text + "' and tipo = '" + comboBox1.Text + "'  and codigo = '" + textBox3.Text + "';";

                SqlCommand Comando = new SqlCommand(Consulta, conn);
                SqlDataReader LectorDatos;
                LectorDatos = Comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean ExistenciaRegistros = LectorDatos.HasRows;

                if (ExistenciaRegistros)
                {
                    MessageBox.Show("Informacion correcta; ahora eliminaremos a " + textBox1.Text );
                    eliminar();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Los datos del usuario son incorrectos");
                    conn.Close();
                }
                                       
            }
            //catch (Exception ex)
            {
                MessageBox.Show("Error al establecer la conexiòn con la base de datos; Por favor intentelo luego (X483)");
                //conectar();
            }
            //finally
            {
                conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void eliminar()
        {
            System.Data.SqlClient.SqlConnection conn =
                    new System.Data.SqlClient.SqlConnection();
            try
            {
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                // TODO: Modify the connection string and include any
                // additional required properties for your database.
                conn.ConnectionString =
            "integrated security=SSPI;data source=DESKTOP-5NFCGTG\\RONELCRUZ;" +
            "persist security info=False;initial catalog=sisfax";
                conn.Open();
                // String Consulta = "delete from users where contraseña='"+textBox2.Text+"' and usuario ='"+textBox1.Text+"' and tipo = '"+comboBox1.Text+"';";
                String Consulta = "update usuarios set estado = 'eliminado' where contraseña='" + textBox2.Text + "' and usuario ='" + textBox1.Text + "' and tipo = '" + comboBox1.Text + "';";
                SqlCommand Comando = new SqlCommand(Consulta, conn);
                Comando.ExecuteNonQuery();
                MessageBox.Show("eliminado");
                this.Close();
                conn.Close();
            

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al establecer la conexiòn con la base de datos; Por favor intentelo luego (X0493)");
                //conectar();
            }
            finally
            {
                conn.Close();
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            conectar();
        }
    }
}
