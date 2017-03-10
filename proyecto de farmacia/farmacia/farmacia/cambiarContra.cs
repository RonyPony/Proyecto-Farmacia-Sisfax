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
    public partial class cambiarContra : Form
    {
        public cambiarContra(string usuario, string contraseña)
        {
            InitializeComponent();
            label6.Text = contraseña;
            label3.Text = usuario;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cambiarContra_Load(object sender, EventArgs e)
        {

        }

        private void conectar(string nuevaContraseña, string nombreUsuario)
        {
            string viejaContraseña = label6.Text;
            System.Data.SqlClient.SqlConnection conexion =
           new System.Data.SqlClient.SqlConnection();
            conexion.ConnectionString =
            "integrated security=SSPI;data source=DESKTOP-5NFCGTG\\RONELCRUZ;" +
            "persist security info=False;initial catalog=sisfax";
            //MessageBox.Show("comienza proceso de extraccion de datos del sexo del usuario");
            conexion.Open();
            // MessageBox.Show("coneccion de base de datos establecida");             
            String Consulta = "UPDATE USUARIOS SET CONTRASEÑA = '" + nuevaContraseña + "' where usuario= '" + nombreUsuario + "' and contraseña = '" + viejaContraseña + "';";
            SqlCommand Comando = new SqlCommand(Consulta, conexion);
            SqlDataReader LectorDatos;
            LectorDatos = Comando.ExecuteReader();
            MessageBox.Show("Contraseña actualizada");
            this.Close();
            Application.Restart();
            Form1 f1 = new Form1();
            f1.Show();

        }
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string nuevaContraseña;
                if (textBox1.Text == textBox2.Text)
            {
                nuevaContraseña = textBox1.Text;
                string usuario = label3.Text;
                conectar(nuevaContraseña,usuario);
            }
            else
            {
                MessageBox.Show("Las contraseñas no son iguales, intentelo nuevamente");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
