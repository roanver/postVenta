using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace tienda
{
    internal class Proveedores
    {
        private int id_proveedor;
        private string rut_proveedor;
        private string nom_proveedor;
        private string fono_proveedor;
        private string email_proveedor;

        public void listaProveedores()
        {
            conexiondb list_prov = new conexiondb();
            list_prov.abrir(); 
            string cadena = "SELECT * FROM proveedores";
            try
            {
                SqlCommand comando = new SqlCommand(cadena, list_prov.conectardb);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Console.WriteLine(lector.GetValue(0).ToString() + " " + lector.GetValue(1).ToString() + " " + lector.GetValue(2).ToString() + " " + lector.GetValue(3).ToString() + " " + lector.GetValue(4).ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta", ex);
            }
        }


        public void agregarProveedor(string rut_proveedor, string nom_proveedor, string fono_proveedor, string email_proveedor)
        {

            conexiondb addProv = new conexiondb();
            addProv.abrir();
            string cadena_addP = "INSERT INTO proveedores (rut_trabajador, nom_proveedor, fono_proveedor, email_proveedor) VALUES (@rut_trabajador, @nom_proveedor, @fono_proveedor, @email_proveedor)";
            try
            {
                SqlCommand comandoAdd = new SqlCommand(cadena_addP, addProv.conectardb);
                comandoAdd.Parameters.AddWithValue("@rut_trabajador", rut_proveedor);
                comandoAdd.Parameters.AddWithValue("@nom_proveedor", nom_proveedor);
                comandoAdd.Parameters.AddWithValue("@fono_proveedor", fono_proveedor);
                comandoAdd.Parameters.AddWithValue("@email_proveedor", email_proveedor);
                comandoAdd.ExecuteNonQuery();
            }
                catch (Exception ex)
            {

                Console.WriteLine("Error: "+ ex.Message);
            }
        }
        public void EliminarProv(int id_proveedor)
        {
            try
            {

                conexiondb conect = new conexiondb();
                conect.abrir();
                string eP = "DELETE FROM proveedores WHERE id_proveedor = '" + id_proveedor + "'";
                SqlCommand comandop = new SqlCommand(eP, conect.conectardb);
                SqlDataReader er = comandop.ExecuteReader();
                while (er.Read())
                {
                    Console.WriteLine("Proveedor eliminado con exito");
                }
                

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        

    }
}