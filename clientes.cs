using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace tienda
{
    internal class clientes
    {
        private int id_cliente;
        private string? rut_cliente; 
        private string? nom_cliente;
        private string? ape_cliente; 
        private string? direccion_cliente;
        private string? fono_cliente;
        private string? email_cliente;

        public void listarCliente()
        {
            conexiondb lC = new();
            lC.abrir();
            string cadenalC = "SELECT * from CLIENTE";
            try
            {
                SqlCommand ComandolC = new(cadenalC, lC.conectardb);
                SqlDataReader lectorlC = ComandolC.ExecuteReader();
                while (lectorlC.Read())
                {
                    Console.WriteLine("Id Cliente: " + lectorlC.GetValue(0).ToString() + " Rut Cliente: " + lectorlC.GetValue(1).ToString() + " Nombre Cliente: " + lectorlC.GetValue(2).ToString() + " Apellido Cliente: " + lectorlC.GetValue(3).ToString() + " Direccion Cliente: " + lectorlC.GetValue(4).ToString() + " Telefono Cliente: " + lectorlC.GetValue(5).ToString() + " Correo Cliente: " + lectorlC.GetValue(6).ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: ", ex.Message);
            }
            {

            }
        } 
        //FUNCION REGISTRAR CLIENTES
        public void registrarCliente(string rut_cliente, string nom_cliente, string ape_cliente, string direccion_cliente, string fono_cliente, string email_cliente)
        {
            conexiondb regClient = new();
            regClient.abrir();
            string cadena_rc = "INSERT INTO cliente (rut_cliente, nom_cliente, ape_cliente, direccion_cliente, fono_cliente, email_cliente) VALUES (@rut_cliente, @nom_cliente, @ape_cliente, @direccion_cliente, @fono_cliente, @email_cliente)";
            try
            {
                SqlCommand comandoAdd = new(cadena_rc, regClient.conectardb);
                comandoAdd.Parameters.AddWithValue("@rut_cliente", rut_cliente);
                comandoAdd.Parameters.AddWithValue("@nom_cliente", nom_cliente);
                comandoAdd.Parameters.AddWithValue("@ape_cliente", ape_cliente);
                comandoAdd.Parameters.AddWithValue("@direccion_cliente", direccion_cliente);
                comandoAdd.Parameters.AddWithValue("@fono_cliente", fono_cliente);
                comandoAdd.Parameters.AddWithValue("@email_cliente", email_cliente);               
                comandoAdd.ExecuteNonQuery();
            
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: ", ex.Message);   
            }
        }

    }
}