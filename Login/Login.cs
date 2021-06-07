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
using CRUD;

namespace Login
{
   
   
    public partial class Login : Form
    {
       
        
        public Login()
        {
            InitializeComponent();
        }
       

        public void Logear(string rut, string contraseña)
        {
            SqlConnection conn = new SqlConnection(Productos.ConnectionString);
            SqlCommand comm = new SqlCommand("Select nombre_completo,rutusuario,contraseña from usuario where rutusuario=@rutusuario and contraseña = @contraseña", conn);

            try
            {
                conn.Open();
                comm.Parameters.AddWithValue("@rutusuario", rut);
                comm.Parameters.AddWithValue("@contraseña", contraseña);
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("Exito, ha iniciado sesion correctamente");
                    this.Hide();
                    Crud c = new Crud();
                    c.Show();
                }
                else
                {
                    MessageBox.Show("Error, Rut y/o usuario incorrectos");
                    txtRutUsuario.Clear();
                    txtContraseña.Clear();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Logear(txtRutUsuario.Text, txtContraseña.Text);
        }

        private void cbVerPass_CheckedChanged(object sender, EventArgs e)
        {
            if(cbVerPass.Checked == true)
            {
                if(txtContraseña.PasswordChar == '*')
                {
                    txtContraseña.PasswordChar = '\0';
                }
            }
            else
            {
                txtContraseña.PasswordChar = '*';
            }
        }
    }
}
