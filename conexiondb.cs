using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; 

namespace tienda
{
    class conexiondb
    {
        string cadena = "Data Source=LAPTOP-AJ84S247;Initial Catalog=bavechi; Integrated Security=True";
        public SqlConnection conectardb = new();
        
        public conexiondb()
        {
            conectardb.ConnectionString = cadena; 
        }

        public void abrir()
        {
            try
            {
                conectardb.Open();
                //Console.WriteLine("Conexion abierta");
            }
            catch (Exception ex)
            {

                Console.WriteLine("error al abrir " + ex.Message);
            }
        }
        public void cerrar()
        {
          conectardb.Close(); 
        }

   
    }
} 

