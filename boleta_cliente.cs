using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;
using System.Data;
using System.Globalization;

namespace tienda
{
    internal class boleta_cliente
    {
        private int id_boleta;
        private int id_producto;
        private double cantidad_producto;
        private double total_compra;
        private DateTime hora_fecha;
        private int id_cliente;
        private int id_tienda;
        private int id_trabajador;
        private int metodo_pago; 

        public void ListarVentas() // Funcion listar ventas
        {
            
            conexiondb LV = new conexiondb();
            LV.abrir();
            string cadenaLV = "Select nom_cliente, ape_cliente, nom_producto, precio_producto, cantidad, tipo_medioP, total_boleta from cliente, productos, boleta_cliente, metodo_pago where cliente.id_cliente = boleta_cliente.id_cliente  and productos.id_producto = boleta_cliente.id_producto\r\nand boleta_cliente.id_metodoPago = metodo_pago.id_metodoPago";
            try
            {
                SqlCommand ComandoLV = new SqlCommand(cadenaLV, LV.conectardb);
                SqlDataReader lectorLV = ComandoLV.ExecuteReader();
                while (lectorLV.Read())
                {
                    Console.WriteLine("\t Cliente: " + lectorLV.GetValue(0).ToString() + " " + lectorLV.GetValue(1).ToString() +
                        "\n Nombre Producto: " + lectorLV.GetValue(2).ToString() +
                        " \n Precio Producto: " + lectorLV.GetValue(3).ToString() +
                        " \n Cantidad Producto: " + lectorLV.GetValue(4).ToString() +
                        " \n Medio de Pago: " + lectorLV.GetValue(5).ToString() +
                        " \n Total Venta: " + lectorLV.GetValue(6).ToString());

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        //funcion registrar venta 
        public void registrarVenta(int id_boleta, int id_cliente, int id_tienda, int id_trabajador, int cantidad_producto, int id_producto, int metodo_pago)
        {
            conexiondb regVenta = new ();
            regVenta.abrir();

            string cadena_rv = "INSERT INTO boleta_cliente (id_boleta, id_cliente, id_tienda, id_trabajador, cantidad, id_producto, id_metodoPago) VALUES (@id_boleta, @id_cliente, @id_tienda, @id_trabajador, @cantidad, @id_producto, @id_metodoPago)";
            try
            {
                SqlCommand comandoAdd = new SqlCommand(cadena_rv, regVenta.conectardb);
                comandoAdd.Parameters.AddWithValue("@id_boleta", id_boleta); 
                comandoAdd.Parameters.AddWithValue("@id_cliente", id_cliente);
                comandoAdd.Parameters.AddWithValue("@id_tienda", id_tienda);
                comandoAdd.Parameters.AddWithValue("@id_trabajador", id_trabajador); 
                comandoAdd.Parameters.AddWithValue("@cantidad", cantidad_producto);
                comandoAdd.Parameters.AddWithValue("@id_producto", id_producto);
                comandoAdd.Parameters.AddWithValue("@id_metodoPago", metodo_pago);
                comandoAdd.ExecuteNonQuery();
                
            }
            catch(Exception ex)
            {
               Console.WriteLine("Error: " +  ex.Message);
            }

            
        }

        public void totalBoleta(int id_boleta) //Funcion total boleta, entrega el total de la compra 
        {
            conexiondb totalBole = new();
            totalBole.abrir();
            string cadenaTB = "select productos.precio_producto * boleta_cliente.cantidad from productos, boleta_cliente where boleta_cliente.id_producto = productos.id_producto and boleta_cliente.id_boleta = '"+id_boleta+"'";  
            try
            {
                SqlCommand ComandoTB = new SqlCommand(cadenaTB, totalBole.conectardb);
                SqlDataReader lectortB = ComandoTB.ExecuteReader();
                while (lectortB.Read())
                {
                    Console.WriteLine(lectortB.GetValue(0)); 
                     
                }

            }catch(Exception ex)
            {
                Console.WriteLine ("Error: ", ex.Message);
                
            }
        }
        public void registroFinal(int id_boleta)//Funcion hace el update del total_boleta en la tabla boleta_cliente en sql server 
        {
           conexiondb regFinal = new conexiondb();
           regFinal.abrir();
           string rFinal = " update boleta_cliente set total_boleta = productos.precio_producto * boleta_cliente.cantidad from productos, boleta_cliente where boleta_cliente.id_producto = productos.id_producto and boleta_cliente.id_boleta = '"+id_boleta+"'";
           try
           {   
               SqlCommand comandoAdd = new SqlCommand(rFinal, regFinal.conectardb);
               SqlDataReader comandoDel = comandoAdd.ExecuteReader();
               while (comandoDel.Read()) 
               { 


               }
                Console.WriteLine("Venta Realizada Exitosamente!"); 
            
           }catch(Exception ex)
           {
               Console.WriteLine("Error: " + ex.Message);
                 
           }
        }

        public void registroHora(int id_boleta)//registra fecha y hora de venta 
        {
            conexiondb regH = new();
            regH.abrir();
            string cadena = "update boleta_cliente set hora_fecha = GETDATE() from productos, boleta_cliente where boleta_cliente.id_producto = productos.id_producto and boleta_cliente.id_boleta = '"+id_boleta+"'";
            try
            {
                SqlCommand commandoRh = new SqlCommand(cadena, regH.conectardb);
                SqlDataReader lectorRH = commandoRh.ExecuteReader();
                while (lectorRH.Read())
                {

                }
            }catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message); 
            }
        
        }

    }
}