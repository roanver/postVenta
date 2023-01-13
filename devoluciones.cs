using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda
{
    internal class Devoluciones
    {
        private int id_devolucion;
        private int id_boleta;
        private string estado_producto;
        private string estado_devolucion;

        public void registrarDevolucion( string estado_producto, string estado_devolucion, int id_boleta)
        {
            conexiondb regDev = new conexiondb();
            regDev.abrir();
            string cadenaRegDev = "insert into devoluciones (estado_producto, estado_devolucion, id_boleta) values (@estado_producto, @estado_devolucion, @id_boleta)";
            try
            {
                SqlCommand comandoRegDev = new SqlCommand(cadenaRegDev, regDev.conectardb);
                comandoRegDev.Parameters.AddWithValue("@estado_producto", estado_producto); 
                comandoRegDev.Parameters.AddWithValue("@estado_devolucion", estado_devolucion); 
                comandoRegDev.Parameters.AddWithValue("@id_boleta", id_boleta); 
                comandoRegDev.ExecuteNonQuery();

            }catch(Exception ex)
            {

            }


        }                             
    }
}