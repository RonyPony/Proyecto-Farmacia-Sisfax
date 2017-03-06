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
    public partial class crearUsuario : Form
    {
        public crearUsuario()
        {
            InitializeComponent();
            asignarCodigoyFecha();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void label26_Click(object sender, EventArgs e)
        {

        }
        private void crearUsuario_Load(object sender, EventArgs e)
        {

        }
        public void asignarCodigoyFecha()
        {

            Random r = new Random(DateTime.Now.Millisecond);
            int codigo = r.Next(1000, 9999);
            string codigo2 = Convert.ToString(codigo);
            label20.Text = (codigo2);

            System.DateTime fecha = DateTime.Now;
            string fechaL = Convert.ToString(fecha);
            label22.Text = fechaL;
            
        }
        public void iniciarDatos()
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
                MessageBox.Show("conectado al servidor");
                string nombre = textBox1.Text;
                string apellido = textBox4.Text;
                string cedula = textBox3.Text;
                string sexo = comboBox1.Text;
                string nacionalidad = comboBox2.Text;
                string direccion = textBox2.Text ;
                string  numerocelular = textBox5.Text;
                string numerorecidencial = textBox6.Text;
                string  fechadenacimiento=(comboBox3.Text+"/"+comboBox4.Text+"/"+comboBox5.Text) ;
                string estadocivil = comboBox6.Text;
                string edad = comboBox7.Text;
                string correo = textBox7.Text;
                string comentarios = textBox11.Text;
                string usuario = textBox24.Text;                
                string contraseña = textBox23.Text;
                string tipocuenta = comboBox18.Text;
                string fechaYora = label22.Text;
                string codigodeusuario = label20.Text;
                //if (comboBox1.Text == "F") { string sexo = "F"; } else if (comboBox1.Text == "M") { string sexo = "M"; }
                String Consulta = "INSERT INTO informacionDelUsuario (usuario,nombre,apellidos,sexo,nacionalidad,direccion,telefono,celular,fechanacimiento,edad,estadoCivil,correo,comentarios,cedula,fechaingreso,codigo) VALUES('" + usuario + "','" + nombre + "','" + apellido + "','" + sexo + "','" + nacionalidad + "','" + direccion + "','" + numerorecidencial + "','" + numerocelular + "','" + fechadenacimiento + "','" + edad + "','" + estadocivil + "','" + correo + "','" + comentarios + "','" + cedula + "','" + fechaYora + "','" + codigodeusuario + "') INSERT INTO USUARIOS (usuario,contraseña,tipo,estado,codigo)VALUES('" + usuario + "','" + contraseña + "','" + tipocuenta + "','normal','" + codigodeusuario + "')" ;
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
                MessageBox.Show("Error al enviar los datos, verifique que los datos suministrados sean los que se le hayan solicitado y que estos contengan un correcto formato");//, tenga en cuenta que caracteres como numeral (#) no son soportados en la casilla de direcion a lo cual puede ulilizar 'NO.' para establecer el numero del domicilio");
            }
            finally
            {
                conn.Close();
            }
        }
       
        public void validar()
        {
            Boolean usuario = false;
            Boolean contra = false;
            Boolean repetircontra = false;

            

            if (textBox24.Text == "")
            { textBox24.BackColor = Color.Red; }else { textBox24.BackColor = Color.White; usuario = true; }
            if (textBox23.Text == "") { textBox23.BackColor = Color.Red; }else { textBox23.BackColor = Color.White; contra = true; }
            if (textBox23.Text != textBox22.Text) { MessageBox.Show("Contraseñas no coinciden"); textBox23.BackColor = Color.Red; textBox22.BackColor = Color.Red; }else { textBox23.BackColor = Color.White; textBox22.BackColor = Color.White; repetircontra = true; }
            if (textBox23.Text == "") { MessageBox.Show("Por motivos de seguridad no puedes crear un usuario sin contraseña, para casos especiales por favor contacte con el desarrollador"); }
            if (comboBox18.Text!="Administrador") { if (comboBox18.Text!="Usuario") { comboBox18.BackColor = Color.Red; } else { comboBox18.BackColor = Color.White; } } else { comboBox18.BackColor = Color.White; }
            
            if (usuario == true & contra == true & repetircontra == true) { iniciarDatos();} else { MessageBox.Show("Error en los datos del usuario"); }
        }
        //MessageBox.Show("usuario, contraseña y repetir estan correctas");
        private void button4_Click(object sender, EventArgs e)
        {
            validar();  
        }
        private void button3_Click(object sender, EventArgs e)
        {
            asignarCodigoyFecha();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            asignarCodigoyFecha();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            asignarCodigoyFecha();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quiere limpiar; Si limpia el formulario toda la informacion actual se perderà, desea limpiar ?", "Limpiar"+ textBox1.Text,
   MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
   == DialogResult.Yes)
            {
                limpiar();
            }
        }
        private void limpiar()
        {
            textBox1.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text= "";
            comboBox7.Text = "";
            textBox7.Text = "";
            textBox11.Text = "";
            textBox24.Text = "";
            textBox23.Text = "";
            comboBox18.Text = "";
            textBox22.Text = "";
            //string fechaYora = ;
            label20.Text = "";
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

