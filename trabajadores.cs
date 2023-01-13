using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace tienda
{
    internal class Trabajadores
    {
        //private int id_trabajador;
        private int id_tienda;
        private string rut_trabajador;
        private string nom_trabajador;
        private string ape_trabajador; 
        private string cargo_trabajador;


        //Funcion Listar Trabajadores 
        public void listaTrabajadores()
        {
            conexiondb list_trab = new conexiondb();
            list_trab.abrir();
            string cadena = "SELECT * FROM Trabajadores";
            try
            {
                SqlCommand comando = new SqlCommand(cadena, list_trab.conectardb);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    Console.WriteLine(lector.GetValue(0).ToString() + " " + lector.GetValue(1).ToString() + " " + lector.GetValue(2).ToString() + " " + lector.GetValue(3).ToString() + " " + lector.GetValue(4).ToString() + " " + lector.GetValue(5).ToString());
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al ejecutar la consulta", ex.Message); 
            }
        }
        // Funcion Registrar Trabajador 
        public void agregarTrabajador(string rut_trabajador, string nom_trabajador, string ape_trabajador, int id_tienda, string cargo_trabajador)
        {
            conexiondb addTrab = new conexiondb();  
            addTrab.abrir(); 
            string cadena_addT = "INSERT INTO trabajadores (rut_trabajador, nom_trabajador, ape_trabajador, id_tienda, cargo) VALUES(@rut_trabajador, @nom_trabajador, @ape_trabajador, @id_tienda, @cargo)";
            try
            {
                SqlCommand comandoAdd = new SqlCommand(cadena_addT, addTrab.conectardb);
                //comandoAdd.Parameters.AddWithValue("@id_trabajador", id_trabajador); 
                comandoAdd.Parameters.AddWithValue("@rut_trabajador", rut_trabajador);
                comandoAdd.Parameters.AddWithValue("@nom_trabajador", nom_trabajador);
                comandoAdd.Parameters.AddWithValue("@ape_trabajador", ape_trabajador);
                comandoAdd.Parameters.AddWithValue("@id_tienda", id_tienda);
                comandoAdd.Parameters.AddWithValue("@cargo", cargo_trabajador);
                comandoAdd.ExecuteNonQuery(); 
            }   
                catch(Exception ex)
            {
                Console.WriteLine("Error; " + ex.Message); 
            }
            
        }

    }
}