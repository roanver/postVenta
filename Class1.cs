using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;


namespace tienda
{
    internal class Venta
    {
        private int id_venta;
        private int id_producto;
        private string nom_producto;
        private int precio_producto;
        private int cantidad_producto;
        private int total_compra;

        public void ListarVentas()
        {
            conexiondb LV = new conexiondb();
            LV.abrir();
            string cadenaLV = "SELECT* from VENTAS";
            try
            {
                SqlCommand ComandoLV = new SqlCommand(cadenaLV, LV.conectardb);
                SqlDataReader lectorLV = ComandoLV.ExecuteReader();
                while (lectorLV.Read())
                {
                    Console.WriteLine("Id Venta: " + lectorLV.GetValue(0).ToString() + " Nombre Producto: " + lectorLV.GetValue(1).ToString() + " Nombre Cliente: " + lectorLV.GetValue(2).ToString() + " Precio Producto: " + lectorLV.GetValue(3).ToString() + " Cantidad Producto: " + lectorLV.GetValue(4).ToString() + " Total Venta: " + lectorLV.GetValue(5).ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error", ex);
            }
            {

            }
        }
        //funcion registrar clientes
        public void registrarVenta(int id_venta, int id_producto, string nom_producto, int precio_producto, int cantidad_producto,int total_compra)
        {
            conexiondb regVenta = new conexiondb();
            regVenta.abrir();
            string cadena_rv = "INSERTO INTO Ventas (id_venta, id_producto, nom_producto, precio_producto, cantidad_producto, total_compra) VALUES (@id_venta, @id_producto, @nom_producto, @precio_producto, @cantidad_producto, @total_compra)";
            try
            {
                SqlCommand comandoAdd = new SqlCommand(cadena_rv, regVenta.conectardb);
                comandoAdd.Parameters.AddWithValue("@id_venta", id_venta);
                comandoAdd.Parameters.AddWithValue("@id_producto", id_producto);
                comandoAdd.Parameters.AddWithValue("@nom_producto", nom_producto);
                comandoAdd.Parameters.AddWithValue("@precio_producto", precio_producto);
                comandoAdd.Parameters.AddWithValue("@cantidad_producto", cantidad_producto);
                comandoAdd.Parameters.AddWithValue("@total_compra", total_compra);
                comandoAdd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error", ex);
            }

            
        }
    }
}
