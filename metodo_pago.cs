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
	internal class Metodopago
	{
		private int metodo_pago;
		private string tipo;

		public void MostrarMPago()
		{
			conexiondb metodoP = new();
			metodoP.abrir();
			string cadena = "SELECT * FROM metodo_pago";
			try
			{
                
                  SqlCommand ComandoLV = new SqlCommand(cadena, metodoP.conectardb);
                  SqlDataReader lectorLV = ComandoLV.ExecuteReader();
				  while (lectorLV.Read())
				  {
					Console.WriteLine("ID: " + lectorLV.GetValue(0).ToString() +" " +  lectorLV.GetValue(1).ToString());
				  }

            }catch(Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}

		}
		

	}

}