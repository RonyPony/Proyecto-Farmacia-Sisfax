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
    public partial class consUsuarios : Form
    {
        public consUsuarios(string tipoUsuario)
        {
            InitializeComponent();
            label3.Text = tipoUsuario + " ]";
            obtenerDatos(tipoUsuario);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        
        public void obtenerDatos(string tipoUsuario)
        {
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (tipoUsuario == "Administrador")
            {
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
                    SqlCommand cmd = new SqlCommand("Select nombre, apellidos, sexo, nacionalidad, direccion, celular, telefono, fechanacimiento, edad, estadoCivil, correo, comentarios, cedula, fechaingreso from informacionDelUsuario", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al establecer la conexiòn con la base de datos");
                }
                finally
                {
                    conn.Close();
                }
            }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            

            if (tipoUsuario=="Usuario")
            {                
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
                   // MessageBox.Show("conectado al servidor");
                    SqlCommand cmd = new SqlCommand("Select usuario, tipo, correo, fechaingreso, codigo from informacionDelUsuario", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al establecer la conexiòn con la base de datos");
                }
                finally
                {
                    conn.Close();
                }

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            }
        }
        private void consUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }

