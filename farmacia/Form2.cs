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
    public partial class Form2 : Form
    {
        public Form2(string nombreusuario, string contraseñausuario, string tipousuario)
        {
            InitializeComponent();
            obtenerSexo(nombreusuario, contraseñausuario, tipousuario);
            label2.Text = nombreusuario.ToUpper();
            label3.Text = tipousuario.ToUpper();
            label4.Text = contraseñausuario;
            string usuario = nombreusuario;
            if (usuario=="bloquear") { notificacionBloqueo(); }
            verificarBloqueo();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarClientesEspecialesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clientesDeudoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
                button3.Text = "<";
                button3.Location = new Point(1340, 45);
                button1.Visible = false;
                button2.Visible = false;
            }
            else
            {
                panel1.Visible = true;
                button3.Text = ">";
                button3.Location = new Point(1039, 45);
                button1.Visible = true;
                button2.Visible = true;
            }
        }

        public void obtenerSexo(string nombreUsuario, string contraseña, string tipo)
        {
            System.Data.SqlClient.SqlConnection conexion =
            new System.Data.SqlClient.SqlConnection();
            conexion.ConnectionString =
            "integrated security=SSPI;data source=DESKTOP-5NFCGTG\\RONELCRUZ;" +
            "persist security info=False;initial catalog=sisfax";
            //MessageBox.Show("comienza proceso de extraccion de datos del sexo del usuario");
            conexion.Open();
           // MessageBox.Show("coneccion de base de datos establecida"); 
            String Consulta = "select sexo, codigo from informacionDelUsuario where usuario= '" + nombreUsuario + "';";
            SqlCommand Comando = new SqlCommand(Consulta, conexion);
            SqlDataReader LectorDatos;
            LectorDatos = Comando.ExecuteReader();
            if (LectorDatos.Read())
            {
                label1.Text = LectorDatos["sexo"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["sexo"]);
                label5.Text = LectorDatos["codigo"] == DBNull.Value ? "*ERROR*" : Convert.ToString(LectorDatos["codigo"]);
                conexion.Close();
            }
            darBienvenida();
        }

        public void darBienvenida()
        {

            //MessageBox.Show("Bienvenido al Sistema");
            seleccionarImagen();

        }
        public void seleccionarImagen()
        {
            if (label1.Text.Equals("F"))
            {
                F.Visible = true;
            }
            else{
                M.Visible = true;
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombre = label2.Text;
            string contraseña = label4.Text;
            string tipo = label3.Text;
            string estado;
            if (panel3.Visible == true) { estado = "bloqueada"; } else { estado = "normal"; }
            usuarios us = new usuarios(nombre,contraseña,tipo,estado);
            us.Show();
           
        }

        public void formularioAgregarUsuarios()
        {
            crearUsuario CU = new crearUsuario();
            CU.Show();
        }

        private void administracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuariosDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label3.Text=="USUARIO") { MessageBox.Show("No tienes permisos suficientes para manejar cierta informacion de los usuarios, por seguridad solo se mostrarà informacion limitada sobre los dueños de las cuentas; Para visualizar todos los datos contactese con un administrador"); consUsuarios cuU = new consUsuarios("Usuario"); cuU.Show(); }
            if (label3.Text == "ADMINISTRADOR") { consUsuarios cu = new consUsuarios("Administrador"); cu.Show(); }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (label3.Text == "ADMINISTRADOR")
            {
                string nombreUsuario = label2.Text.ToLower();
                string tipoUsuario = label3.Text.ToLower();
                string permiso = "Eliminar un usuario; Parte de tu informacion quedara en el registro de eliminaciones, al permitir este proceso le das permiso al sistema de archivar tu informacion de manera privada y disponible para ciertos casos legales";
                string contraseñaUsuario = label4.Text;
                confirmarPermisos CP = new confirmarPermisos(nombreUsuario, tipoUsuario, permiso, contraseñaUsuario);
                CP.Show();
            }
            else { MessageBox.Show("No tienes permiso suficiente para eliminar un usuario del sistema; Para proceder contacte con un administrador"); }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void editarInformacionDelUsuarioActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                string nombreusuario = label2.Text;
                string tipousuario = label3.Text;
                string permiso = "Cambiar de manera definitiva tu contraseña, en caso de ser modificada sin la nueva contraseña no podràs acceder al sistema";
                string contraseñaUsuario = label4.Text;
                confirmarPermisos cf = new confirmarPermisos(nombreusuario, tipousuario, permiso, contraseñaUsuario);
                cf.Show();
            }
            else { MessageBox.Show("No puedes cambiar tu contraeña mientras tu cuenta estè bloqueada, contacta a un administrador para solucionar el inconveniente               [ERROR-25]"); }
           
           
        }
        public void verificarBloqueo()
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
                String Consulta = "select estado from usuarios where contraseña='" + label4.Text + "' and usuario ='" + label2.Text + "' and tipo = '" + label3.Text + "' ";
                conn.Open();
                SqlCommand Comando = new SqlCommand(Consulta, conn);
                SqlDataReader LectorDatos;
                LectorDatos = Comando.ExecuteReader();
                if (LectorDatos.Read())
                {
                    label7.Text = Convert.ToString(LectorDatos["estado"]);
                    string cc = label6.Text;
                    if (label7.Text == "bloqueada") { notificacionBloqueo(); }
                }

                conn.Close();
               // MessageBox.Show("La lista de usuarios se ha actualizado ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void notificacionBloqueo()
        {
            panel3.Visible = true;
        }
        private void label11_Click(object sender, EventArgs e)
        {
            
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void desbloquearUnUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel3.Visible==false)
            {
                desbloquearUsuario du = new desbloquearUsuario();
                du.Show();
            }
            else { MessageBox.Show("No se puede desbloquear un usuario desde otro bloqueado"); }
           
        }

        private void verMiInformacionPersonalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string permiso = "mostrar tu informacion personal de manera completa";
            confirmarPermisos cp = new confirmarPermisos(label2.Text,label3.Text,permiso,label4.Text);
            cp.Show();
            //verInformacionPersonal vip = new verInformacionPersonal();
            //vip.Show();
        }

        private void operacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
