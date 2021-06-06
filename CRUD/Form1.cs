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


namespace CRUD
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        string UID = "";

        private void Form1_Load(object sender, EventArgs e)
        {
           dg_Productos.DataSource = Productos.LeerDatos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (UID == "")
            {
                if (Productos.Guarda_Registro(txtNombre.Text,txtDescripcion.Text,txtMarca.Text,txtPrecio.Text,txtStock.Text))
                {
                    MessageBox.Show("Registro Guardado");
                    dg_Productos.DataSource = Productos.LeerDatos();
                }
                else
                {
                    MessageBox.Show("Registro no Guardado");
                }
                
            }
            else
            {
                if (Productos.Actualiza_Registro(txtNombre.Text,txtDescripcion.Text,txtMarca.Text,txtPrecio.Text,txtStock.Text,UID))
                {
                    MessageBox.Show("Registro actualizado");
                    dg_Productos.DataSource = Productos.LeerDatos();
                }
                else
                {
                    MessageBox.Show("Registro no actualizado");
                }
            }
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            UID = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            string ID = dg_Productos.CurrentRow.Cells["ID"].Value.ToString();
            string Nombre = dg_Productos.CurrentRow.Cells["Nombre"].Value.ToString();
            string Descripcion = dg_Productos.CurrentRow.Cells["Descripcion"].Value.ToString();
            string Marca = dg_Productos.CurrentRow.Cells["Marca"].Value.ToString();
            string Precio = dg_Productos.CurrentRow.Cells["Precio"].Value.ToString();
            string Stock = dg_Productos.CurrentRow.Cells["Stock"].Value.ToString();


            txtNombre.Text = Nombre;
            txtDescripcion.Text = Descripcion;
            txtMarca.Text = Marca;
            txtPrecio.Text = Precio;
            txtStock.Text = Stock;
            UID = ID;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string ID = dg_Productos.CurrentRow.Cells["ID"].Value.ToString();
            if (Productos.Elimina_Registro(ID))
            {
                MessageBox.Show("Registro eliminado");
                dg_Productos.DataSource = Productos.LeerDatos();
            }
            else
            {
                MessageBox.Show("Registro no eliminado");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-O3JM00N;Initial Catalog=practica;Integrated Security =true";
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand comm = new SqlCommand("Select * from Productos where " + cbBuscar.Text + " like '%" + txtBuscar.Text + "%'", conn);
            try
            {
                conn.Open();
                DataSet data = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(data, "Productos");
                dg_Productos.DataSource = data;
                dg_Productos.DataMember = "Productos";
                
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

        private void dg_Productos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

