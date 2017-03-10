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
    public partial class verInformacionPersonal : Form
    {
        public verInformacionPersonal(string usuario, string contraseña, string tipo)
        {
            InitializeComponent();

            obtenerInformacion(usuario,contraseña,tipo);

        }

        private void verInformacionPersonal_Load(object sender, EventArgs e)
        {

        }


        public void obtenerInformacion(string nombreUsuario, string contraseña, string tipo)
        {
            System.Data.SqlClient.SqlConnection conexion =
            new System.Data.SqlClient.SqlConnection();
            conexion.ConnectionString =
            "integrated security=SSPI;data source=DESKTOP-5NFCGTG\\RONELCRUZ;" +
            "persist security info=False;initial catalog=sisfax";
            MessageBox.Show("comienza proceso de extraccion de datos del usuario");
            conexion.Open();
            MessageBox.Show("coneccion de base de datos establecida");
            String Consulta = "select usuario,nombre,apellidos,sexo,nacionalidad,direccion,celular,telefono,fechanacimiento,edad,fechaIngreso,correo,comentarios from informacionDelUsuario where usuario= '" + nombreUsuario + "';";
            SqlCommand Comando = new SqlCommand(Consulta, conexion);
            SqlDataReader LectorDatos;
            LectorDatos = Comando.ExecuteReader();
            if (LectorDatos.Read())
            {
                label1.Text = LectorDatos["usuario"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["usuario"]);
                label20.Text = LectorDatos["nombre"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["nombre"]);
                label21.Text = LectorDatos["apellidos"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["apellidos"]);

                label22.Text = LectorDatos["sexo"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["sexo"]);
                label23.Text = LectorDatos["nacionalidad"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["nacionalidad"]);
                label24.Text = LectorDatos["direccion"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["direccion"]);
                label25.Text = LectorDatos["celular"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["celular"]);
                label26.Text = LectorDatos["telefono"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["telefono"]);
                label27.Text = LectorDatos["fechanacimiento"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["fechanacimiento"]);
                label28.Text = LectorDatos["edad"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["edad"]);
                label29.Text = LectorDatos["fechaIngreso"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["fechaIngreso"]);
                label30.Text = LectorDatos["correo"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["correo"]);
                label31.Text = LectorDatos["comentarios"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["comentarios"]);
                verificarLongitudComentario();
                informacionLogin(nombreUsuario);
                conexion.Close();
            }
            
        }

        public void informacionLogin(string nombreUsuario)
        {
            MessageBox.Show("extraccion de informacion confidencial");
            System.Data.SqlClient.SqlConnection conexion =
            new System.Data.SqlClient.SqlConnection();
            conexion.ConnectionString =
            "integrated security=SSPI;data source=DESKTOP-5NFCGTG\\RONELCRUZ;" +
            "persist security info=False;initial catalog=sisfax";           
            conexion.Open();
            String Consulta = "select codigo,usuario,contraseña,estado,tipo from usuarios where usuario= '" + nombreUsuario + "';";
            SqlCommand Comando = new SqlCommand(Consulta, conexion);
            SqlDataReader LectorDatos;
            LectorDatos = Comando.ExecuteReader();
            if (LectorDatos.Read())
            {
                label2.Text = LectorDatos["contraseña"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["contraseña"]);
                label32.Text = LectorDatos["codigo"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["codigo"]);
                verificarLongitudComentario();
                conexion.Close();
            }

        }

        public void verificarLongitudComentario()
        {
            if (label31.Text.Length >= 45) { mas.Enabled = true; }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void mas_Click(object sender, EventArgs e)
        {

        }
    }
}
