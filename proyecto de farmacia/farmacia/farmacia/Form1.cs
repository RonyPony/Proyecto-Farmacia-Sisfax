using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace farmacia
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {            
           
        }
        private void cargar()
        {
            pictureBox1.Visible = true;
            conectar();
        }

        private void acabo() {

        }

        private void iniciar()
        {
            
        }

        public void conectar()
        {
            string nombreusuario = textBox1.Text;
            string contraseñausuario = textBox2.Text;
            string tipousuario = comboBox1.Text;

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
               // MessageBox.Show("conectado al servidor x1");
                String Consulta = "select contraseña,usuario,tipo from usuarios where contraseña='" + textBox2.Text + "' and usuario ='" + textBox1.Text + "' and tipo = '" + comboBox1.Text + "';";
                SqlCommand Comando = new SqlCommand(Consulta, conn);
                SqlDataReader LectorDatos;
                LectorDatos = Comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean ExistenciaRegistros = LectorDatos.HasRows;
                verificarEliminado();
                if (ExistenciaRegistros)
                {
                    label6.Visible = false;
                    MessageBox.Show("Bienvenido al sistema " + textBox1.Text, "Usuario autorizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                    Form2 frm = new Form2(nombreusuario, contraseñausuario, tipousuario);
                    frm.Show();
                    this.Hide();
                }                  
                else
                {
                    // MessageBox.Show("contraseña o usuario incorrecto");
                    label6.Visible = true;
                    label6.Text = "Datos incorrectos";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.Text = "";
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al establecer la conexiòn con la base de datos; Por favor reinicie el sistema. [ERROR-157]");
                //conectar();
            }
            finally
            {
                conn.Close();
                pictureBox1.Visible = false;
            }
        }
 
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void verificarEliminado()
        {           
           // MessageBox.Show("verificando eliminacion...");
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
                String Consulta = "select estado from usuarios where contraseña='" + textBox2.Text + "' and usuario ='" + textBox1.Text + "' and tipo = '" + comboBox1.Text + "';";
                conn.Open();
                SqlCommand Comando = new SqlCommand(Consulta, conn);
                SqlDataReader LectorDatos;
                LectorDatos = Comando.ExecuteReader();
                if (LectorDatos.Read())
                {
                    label7.Text = Convert.ToString(LectorDatos["estado"]);
                   
                   
                    if (label7.Text == "eliminado") { MessageBox.Show("Este usuario ha sido eliminado, para restaurarlo contacte un administrador"); Application.Restart(); }
                }

                conn.Close();
                //MessageBox.Show("La lista de usuarios se ha actualizado ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        
    }


        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Text == "(●)")
            {
                checkBoxShowPassword.Text = "()";
                // textBox2.PasswordChar="*";

            }
            else
            {
                checkBoxShowPassword.Text = "(●)";
            }
            textBox2.PasswordChar = checkBoxShowPassword.Checked ? '\0' : '●';
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cargar();            
            //conectar();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==Convert.ToChar(Keys.Enter)) { cargar(); }
        }
    }
    }
    
    

