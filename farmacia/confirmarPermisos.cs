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
    public partial class confirmarPermisos : Form
    {
        public confirmarPermisos(string nombreusuario, string tipousuario, string permiso, string contraseñaUsuario)
        {
            InitializeComponent();
            textBox1.Text = nombreusuario;
            label6.Text = contraseñaUsuario;
            textBox2.Text = tipousuario;
            textBox3.Text = permiso;            
            string contra = contraseñaUsuario;
            verificarBloqueo();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label8.Visible=true)
            {
                string usuario="bloquear";
                string contrase=label6.Text;
                string tipo=textBox2.Text;
                Form2 f2 = new Form2(usuario,contrase,tipo);f2.Show();
            }
            this.Hide();
        }

        private void confirmarPermisos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cc = label6.Text;
            string permiso = textBox3.Text;
            procesar(cc,permiso);
        }


        /////////////////////////
        public void verificarBloqueo()
        {
            MessageBox.Show("verificando bloqueo...");
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
                String Consulta = "select estado from usuarios where contraseña='" + label6.Text + "' and usuario ='" + textBox1.Text + "' and tipo = '" + textBox2.Text + "';";
                conn.Open();               
                SqlCommand Comando = new SqlCommand(Consulta, conn);
                SqlDataReader LectorDatos;
                LectorDatos = Comando.ExecuteReader();
                if (LectorDatos.Read())
                {
                     label7.Text = Convert.ToString(LectorDatos["estado"]);
                    string cc = label6.Text;
                    string permiso = textBox3.Text;
                    if (label7.Text == "bloqueada") {tres(cc,permiso);}
                }

                conn.Close();
                //MessageBox.Show("La lista de usuarios se ha actualizado ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void procesar(String cc, string permiso)
        {            
            if (label9.Text == "0") { cero(cc, permiso); } else { if (label9.Text == "1") { uno(cc, permiso); } else { if (label9.Text == "2") { dos(cc, permiso); } else { if (label9.Text == "3") { tres(cc,permiso); } } } }
        
    }
            public void cero(string cc, string permiso) {
            if (textBox4.Text == cc)
            {
                verificarPermiso(permiso);
            }
            else
            {
                contador.Visible = true;
                contador.Text = "Contraseña incorrecta, 2 intentos restantes";
                label9.Text = "1";
                textBox4.Text = "";
                label10.Visible = false;
                button3.Enabled = false;
            }
        }
    
        public void uno(string cc, string permiso)
        {
            if (textBox4.Text == label6.Text)
            {
                verificarPermiso(permiso);
            }
            else
            {
                contador.Visible = true;
                contador.Text = "Contraseña incorrecta, 1 intentos restantes";
                label9.Text = "2";
                textBox4.Text = "";
                button2.Enabled = true;
            }
        }
        public void dos(String cc, string permiso)
        {
            if (textBox4.Text == label6.Text)
            {
                verificarPermiso(permiso);
            }
            else
            {
                contador.Visible = true;
                contador.Text = "Contraseña incorrecta, ultimo intento";
                label9.Text = "3";
                textBox4.Text = "";
               
            }
        }
        public void tres(String cc, string permiso)
        {
            if (textBox4.Text == label6.Text)
            {
                verificarPermiso(permiso);
            }
            else
            {
                MessageBox.Show("No has podido autentificar tu cuenta, por motivos de seguridad su cuenta ha sido bloqueada; Para reactivar su cuenta contacte a un administrador");
                contador.Text = "Cuenta bloqueada";
                contador.Visible = true;
                label1.Visible = false;
                label8.Visible = true;
                button1.Enabled = false;
                button2.Visible = true;
                button3.Visible = false;
                textBox4.Enabled = false;
                textBox4.Enabled = false;
                textBox4.PasswordChar = 'X';
                textBox4.Text = "Un saludo pa toa` mi gente querida de parte de Ronel";
                
                bloquear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        public void bloquear()
        {
           // MessageBox.Show("bloqueando...");

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
                              
                //if (comboBox1.Text == "F") { string sexo = "F"; } else if (comboBox1.Text == "M") { string sexo = "M"; }
                //String Consulta = "INSERT INTO USERS (bloqueada) VALUES('" + si + "')";
                String Consulta = "UPDATE usuarios SET estado = 'bloqueada' WHERE usuario = '" + textBox1.Text + "';";
                //"select contraseña,usuario,tipo from users where contraseña='" + textBox2.Text + "' and usuario ='" + textBox1.Text + "' and tipo = '" + comboBox1.Text + "';";
                SqlCommand Comando = new SqlCommand(Consulta, conn);
                SqlDataReader LectorDatos;
                LectorDatos = Comando.ExecuteReader();
                foreach (DataRow dtRow in dt.Rows) ;
                Boolean ExistenciaRegistros = LectorDatos.HasRows;
                conn.Close();
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
        private void verificarPermiso(string solicitud)
        {       
            
            //MessageBox.Show("Verificar peticion");
            string solicitud001 = ("Agregar un nuevo usuario al sistema; Tenga en cuenta que dependiendo el tipo de usuario que quiera crear, este tendra acceso a determinadas operaciones e informaciones del sistema").ToUpper(); 
            if (solicitud==solicitud001)
            {
                crearUsuario agreUsuar = new crearUsuario();
                agreUsuar.Show();
                this.Close();
            }


            string solicitud002 = "Eliminar un usuario; Parte de tu informacion quedara en el registro de eliminaciones, al permitir este proceso le das permiso al sistema de archivar tu informacion de manera privada y disponible para ciertos casos legales";
            if (solicitud == solicitud002)
            {
                eliminarUsuario EU = new eliminarUsuario();
                EU.Show();
                this.Close();
            }


            string solicitud003 = "Cambiar de manera definitiva tu contraseña, en caso de ser modificada sin la nueva contraseña no podràs acceder al sistema";
            if (solicitud == solicitud003)
            {
                cambiarContra cc = new cambiarContra();
                cc.Show();
                this.Close();
            }

            string solicitud004 = "mostrar tu informacion personal de manera completa";
            if (solicitud == solicitud004)
            {
                verInformacionPersonal vip = new verInformacionPersonal(textBox1.Text,label6.Text,textBox2.Text);
                vip.Show();
                this.Close();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
            verificarBloqueo();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            verificarBloqueo();
            this.Close();
        }
    }
        }
    

