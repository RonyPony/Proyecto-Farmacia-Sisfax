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
    public partial class usuarios : Form
    {
        public usuarios(string nombre, string contraseña, string tipo, string estado)
        {
            InitializeComponent();
            //MessageBox.Show(tipo);
            label5.Text = nombre;
            label4.Text = tipo;
            label6.Text = contraseña;
            string estadoAnotificar;
            if (estado == "normal")
            {
                estadoAnotificar = "";
                mostrarUsuarios();
            }
            else
            {
                estadoAnotificar = "   (Cuenta Bloqueada)";
                neutralizar();
            }
            if (tipo == "USUARIO") { limitarInformacion(); }

            this.Text = "Administracion de usuarios       [" + nombre.ToUpper() + "]" + estadoAnotificar;
        }

        private void usuarios_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void mostrarUsuarios()
        {
            // MessageBox.Show("verificando eliminacion...");


            System.Data.SqlClient.SqlConnection conn =
                new System.Data.SqlClient.SqlConnection();
            // TODO: Modify the connection string and include any
            // additional required properties for your database.
            conn.ConnectionString =
             "integrated security=SSPI;data source=DESKTOP-5NFCGTG\\RONELCRUZ;" +
             "persist security info=False;initial catalog=sisfax";

            string query = "SELECT codigo,usuario,estado,tipo FROM usuarios";
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            // dataGridView1.DataBind();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label4.Text == "ADMINISTRADOR")
            {
                string nombreUsuario = label5.Text.ToLower();
                string tipoCuenta = label4.Text.ToLower();
                string permiso = ("Agregar un nuevo usuario al sistema; Tenga en cuenta que dependiendo el tipo de usuario que quiera crear, este tendra acceso a determinadas operaciones e informaciones del sistema").ToUpper();
                string contraseñaUsuario = label6.Text;
                confirmarPermisos cp = new confirmarPermisos(nombreUsuario, tipoCuenta, permiso, contraseñaUsuario);
                cp.Show();
            }
            else if (label3.Text == "USUARIO")
            {
                MessageBox.Show("No tienes permisos suficientes para agregar nuevos usuarios, para agregar usuarios contacta con un administrador");
            }
            else { MessageBox.Show("No se ha encontrado sus permisos o su cuenta ha sido bloqueada, por lo que crear un nuevo usuario no le es permitido"); }

        }
        private void limitarInformacion()
        {
            label3.Visible = true;
            label2.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;

            System.Data.SqlClient.SqlConnection conn =
    new System.Data.SqlClient.SqlConnection();
            // TODO: Modify the connection string and include any
            // additional required properties for your database.
            conn.ConnectionString =
             "integrated security=SSPI;data source=DESKTOP-5NFCGTG\\RONELCRUZ;" +
             "persist security info=False;initial catalog=sisfax";

            string query = "SELECT usuario,tipo FROM usuarios";
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
            // dataGridView1.DataBind();
        }
        private void neutralizar()
        {
            MessageBox.Show("Su cuenta esta actualmente bloqueada por lo que no podrá acceder a cierto tipo de datos en el sistema.");
            label1.Visible = true;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
