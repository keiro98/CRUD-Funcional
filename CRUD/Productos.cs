using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CRUD
{
    public class Productos
    {
        public static string ConnectionString = "Data Source=DESKTOP-O3JM00N;Initial Catalog=Practica;Integrated Security =true";

        public static DataTable LeerDatos()
        {
            DataTable dt_ListaProductos = new DataTable();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand comm = new SqlCommand("Select * from Productos", conn);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(dt_ListaProductos);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt_ListaProductos;
        }

        public static bool Guarda_Registro(string Nombre, string Descripcion, string Marca, string Precio, string Stock)
        {
            bool Exito = false;

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand comm = new SqlCommand("INSERT INTO Productos(Nombre,Descripcion,Marca,Precio,Stock) VALUES(@nombre,@descripcion,@marca,@precio,@stock);", conn);
            comm.Parameters.AddWithValue("@nombre", Nombre);
            comm.Parameters.AddWithValue("@descripcion", Descripcion);
            comm.Parameters.AddWithValue("@marca", Marca);
            comm.Parameters.AddWithValue("@precio", Precio);
            comm.Parameters.AddWithValue("@stock", Stock);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                Exito = true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return Exito;
        }

        public static bool Actualiza_Registro(string Nombre, string Descripcion, string Marca, string Precio, string Stock, string ID)
        {
            bool Exito = false;

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand comm = new SqlCommand("UPDATE Productos set Nombre=@nombre,Descripcion=@descripcion,Marca=@marca,Precio=@precio,Stock=@stock  where id=@id;", conn);
            comm.Parameters.AddWithValue("@ID", ID);
            comm.Parameters.AddWithValue("@nombre", Nombre);
            comm.Parameters.AddWithValue("@descripcion", Descripcion);
            comm.Parameters.AddWithValue("@marca", Marca);
            comm.Parameters.AddWithValue("@precio", Precio);
            comm.Parameters.AddWithValue("@stock", Stock);
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                Exito = true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return Exito;
        }

        public static bool Elimina_Registro(string ID)
        {
            bool Exito = false;

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand comm = new SqlCommand("DELETE FROM Productos where id=@id;", conn);
            comm.Parameters.AddWithValue("@ID", ID);

            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                Exito = true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return Exito;
        }
    }
}

    
