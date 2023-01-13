using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq.Expressions;


namespace tienda
{
    internal class Producto
    {
        private int id_producto; 
        private string nom_producto;
        private double precio_producto;
        private int stock_producto;
        private string codigo_barra;
        private int id_proveedor;
        private int id_bodega;
        private int id_tienda; 
         

   
        // funcion listar productos
        public void listarProductos()
        {
            conexiondb lP = new();
            lP.abrir();
            string cadenaLP = "SELECT * FROM productos";
            try
            {
                SqlCommand comandoLP = new(cadenaLP, lP.conectardb);
                SqlDataReader lectorLP = comandoLP.ExecuteReader();
                while (lectorLP.Read())
                {
                    Console.WriteLine(lectorLP.GetValue(0).ToString() + " " + lectorLP.GetValue(1).ToString() + " " + lectorLP.GetValue(2).ToString() + " " + lectorLP.GetValue(3).ToString()+ " " + lectorLP.GetValue(4).ToString()+ " " + lectorLP.GetValue(5).ToString()+ " " + lectorLP.GetValue(6).ToString()+ " " + lectorLP.GetValue(7).ToString());
                }

            }catch(Exception ex)
            {
                Console.WriteLine("error", ex); 
            }
        }
        //funcion registrar producto
        public void registrarProductos( string nom_producto, double precio_producto, int stock_producto, string codigo_barra, int id_proveedor, int id_bodega, int id_tienda)
        {
            conexiondb addProd = new();
            addProd.abrir();
            string cadena_addP = "INSERT INTO productos (nom_producto, precio_producto, stock_producto, codigo_barra, id_proveedor, id_bodega, id_tienda) VALUES (@nom_producto, @precio_producto, @stock_producto, @codigo_barra, @id_proveedor, @id_bodega, @id_tienda)";
            try
            {
                SqlCommand comandoAdd = new(cadena_addP, addProd.conectardb);
                comandoAdd.Parameters.AddWithValue("@nom_producto", nom_producto);
                comandoAdd.Parameters.AddWithValue("@precio_producto", precio_producto);
                comandoAdd.Parameters.AddWithValue("@stock_producto", stock_producto);
                comandoAdd.Parameters.AddWithValue("@codigo_barra", codigo_barra);
                comandoAdd.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                comandoAdd.Parameters.AddWithValue("@id_bodega", id_bodega);
                comandoAdd.Parameters.AddWithValue("@id_tienda", id_tienda);
                comandoAdd.ExecuteNonQuery();

            }
                catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        public void nomProducto (int id_producto)// Funcion Muestra el nombre del producto 
        {
            try
            {
                conexiondb nomProducto = new(); 
                nomProducto.abrir();
                string nomPro = " SELECT nom_producto FROM productos WHERE id_producto = '"+id_producto+"'"; 
                SqlCommand comandoNombre = new(nomPro, nomProducto.conectardb);
                SqlDataReader noPro = comandoNombre.ExecuteReader(); 
                while (noPro.Read())
                {

                    Console.WriteLine(noPro.GetValue(0));
                    
                    
                } 
            }
            catch(Exception ex)
            {

                Console.WriteLine("Error al acceder a la informacion:  " +  ex.Message);
            }
            
        }
        public void nPrecio(int id_producto)// muestra el precio del producto 
        {
            try 
            { 
                conexiondb conect = new();
                conect.abrir();
                string nP = "SELECT precio_producto FROM productos where id_producto ='"+id_producto+"'";
                SqlCommand comando = new(nP, conect.conectardb);
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {

                     
                    Console.WriteLine(dr.GetValue(0).ToString ());

                    
                    
                    
                }
            }catch(Exception ex)
            {
                Console.WriteLine ("Error: " + ex.Message);
            }

        
        }
        // Funcion elimiar registro producto
        public void EliminarReg(int id_producto)
        {
            try
            { 
        
                conexiondb conect = new();
                conect.abrir();
                string eP = "DELETE FROM Productos WHERE id_producto = '"+id_producto+"'";
                SqlCommand comandop = new(eP, conect.conectardb);
                SqlDataReader er = comandop.ExecuteReader();
                while (er.Read())
                {
                    
                }
                Console.WriteLine("Producto eliminado con exito");


            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); 
            }

            
        }
    }

}