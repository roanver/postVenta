using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace tienda
{

    class MainClass
    {

        public static void Main(String[] args)
        {

            bool iniciador = true;
            

            while (iniciador == true)
            {

                Console.WriteLine("********* Post de Venta *********");
                Console.WriteLine("[1] Venta.");
                Console.WriteLine("[2] Productos.");
                Console.WriteLine("[3] Proveedores.");
                Console.WriteLine("[4] Trabajadores.");
                Console.WriteLine("[5] Salir. ");
                //int opcion = Convert.ToInt32(Console.ReadLine());
                int opcion = Int32.Parse(Console.ReadLine());




                if (opcion == 1)//SuB Menu Venta
                {
                    Console.WriteLine("[1] Registrar Venta ");
                    Console.WriteLine("[2] Registro Cliente");
                    Console.WriteLine("[3] Ver Ventas ");
                    int rVent = Convert.ToInt32(Console.ReadLine());


                    if (rVent == 1)
                    {
                        //Registro de venta
                        Console.WriteLine("          VENTA ");
                        Producto prop = new();
                        boleta_cliente blc = new();
                        Metodopago mtp = new(); 

                        Console.WriteLine("ID Boleta: ");
                        int idBoleta = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ID Producto: ");
                        int idPro = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Producto: ");
                        prop.nomProducto(idPro);
                        Console.WriteLine("Precio: ");
                        prop.nPrecio(idPro);
                        Console.WriteLine("Cantidad: ");
                        int cant = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Metodo de Pago: ");
                        mtp.MostrarMPago();
                        int metPago = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ID Cliente: ");
                        int idClient = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ID Tienda: ");
                        int idTienda = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ID Trabajador");
                        int idTrab = Convert.ToInt32(Console.ReadLine());
                        blc.registrarVenta(idBoleta, idClient, idTienda, idTrab,  cant, idPro, metPago);
                        Console.WriteLine("Total Venta: ");
                        blc.totalBoleta(idBoleta);
                        blc.registroFinal(idBoleta);
                        blc.registroHora(idBoleta); 
                    }

                    else if (rVent == 2)// Registro Cliente 
                    {
                        Console.WriteLine("          Registrar Cliente ");
                        Console.WriteLine("Rut Cliente: ");
                        string? rut_cl = Console.ReadLine();
                        Console.WriteLine("Nombre Cliente: ");
                        string? nom_cl = Console.ReadLine();
                        Console.WriteLine("Apellido Cliente: ");
                        string? ape_cl = Console.ReadLine();
                        Console.WriteLine("Direccion Cliente: ");
                        string? direccion_cl = Console.ReadLine();
                        Console.WriteLine("Telefono Cliente: ");
                        string? fono_cl = Console.ReadLine();
                        Console.WriteLine("Correo Cliente: ");
                        string? email_cl = Console.ReadLine();

                        //Instanciamos la clase cliente, llamamos a la funcion registrarCliente. 
                        clientes reg_cl = new();
                        reg_cl.registrarCliente(rut_cl, nom_cl, ape_cl, direccion_cl, fono_cl, email_cl);
                        reg_cl.listarCliente();
                    }
                    else if (rVent == 3)
                    {
                        Console.WriteLine("Ventas: ");
                        boleta_cliente boleta = new();
                        boleta.ListarVentas(); 
                    }

                    
                }
               

                else if (opcion == 2)//Sub Menú Porductos
                {
                    Console.WriteLine("[1] Registrar Producto");
                    Console.WriteLine("[2] Ver Productos");
                    Console.WriteLine("[3] Eliminar Producto");
                    int prod = Convert.ToInt32(Console.ReadLine());

                    if (prod == 1)//Registro Productos
                    {
                        Console.WriteLine("          Registro de Productos");
                        Console.WriteLine("Nombre Producto: ");
                        string? nom_prod = Console.ReadLine();
                        Console.WriteLine("Precio Producto: ");
                        double precio_prod = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Stock Producto: ");
                        int stock_prod = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("codigo de barra: ");
                        string? cod_barra = Console.ReadLine();
                        Console.WriteLine("ID Proveedor: ");
                        int id_prov = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ID Bodega: ");
                        int id_bod = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("ID Tienda: ");
                        int id_tienda = Convert.ToInt32(Console.ReadLine());

                        Producto reg_prod = new();
                        reg_prod.registrarProductos(nom_prod, precio_prod, stock_prod, cod_barra, id_prov, id_bod, id_tienda);
                        //reg_prod.listarProductos();
                        
                    }
                    else if (prod == 2)//Lista Productos
                    { 
                        
                        Console.WriteLine("          Lista de Productos");
                        Producto lpPro = new();
                        lpPro.listarProductos();
                        
                        
                    }

                    else if (prod == 3)//Eliminar Producto 
                    {

                        Console.WriteLine("          Eliminar Producto");
                        Console.WriteLine("ID Producto: ");
                        int idProd = Convert.ToInt32(Console.ReadLine());

                        Producto eliminarReg = new();
                        eliminarReg.EliminarReg(idProd);
                    }
                }

                else if (opcion == 3) //Proveedores 
                {

                    //sub menu proveedores 
                    Console.WriteLine("[1] Registrar Proveedor");
                    Console.WriteLine("[2] Ver Proveedores");
                    Console.WriteLine("[3] Eliminar Proveedores");
                    int prov = Convert.ToInt32(Console.ReadLine());

                    if (prov == 1 )
                    { 
                        Console.WriteLine("          Registro de Proveedor");
                        Console.WriteLine("Ingrese el RUT del proveedor: ");
                        string rut_prov = Console.ReadLine();
                        Console.WriteLine("Nombre del proveedor: ");
                        string nom_prov = Console.ReadLine();
                        Console.WriteLine("Telefono del proveedor: ");
                        string fono_prov = Console.ReadLine();
                        Console.WriteLine("Email del proveedor: ");
                        string email_prov = Console.ReadLine();


                        Proveedores reg_prov = new Proveedores();
                        reg_prov.agregarProveedor(rut_prov, nom_prov, fono_prov, email_prov);
                        //reg_prov.listaProveedores();
                    }
                

                    else if (prov == 2)
                    {
                        Console.WriteLine("          Lista de Proveedores");
                        Proveedores lpProv = new Proveedores();
                        lpProv.listaProveedores();
                    }

                    else if (prov == 3)
                    {

                        Console.WriteLine("          Eliminar Proveedor");
                        Console.WriteLine("ID Proveedor: ");
                        int idProv = Convert.ToInt32(Console.ReadLine());

                        Proveedores eliminarProv = new Proveedores();
                        eliminarProv.EliminarProv(idProv);
                    }

                }
          
                else if (opcion == 4) //Registro de trabajadores y listado
                {
                    Console.WriteLine("[1] Registar Trabajador");
                    Console.WriteLine("[2] Lista Trabajadores");
                    //poner eliminar 
                    int trabj = Convert.ToInt32(Console.ReadLine()); 
                    
                   
                    if (trabj == 1)//registro trabajadores
                    {
                        Console.WriteLine("          Registro Trabajador");
                        Console.WriteLine("Rut: ");
                        string rut_trab = Console.ReadLine();
                        Console.WriteLine("Nombre: ");
                        string nom_trab = Console.ReadLine();
                        Console.WriteLine("Apellido: ");
                        string ape_trab = Console.ReadLine();
                        Console.WriteLine("Tienda: ");
                        int id_tien_trab = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Cargo: ");
                        string cargo_trab = Console.ReadLine();
                        
                        Trabajadores reg_trab = new Trabajadores();
                        reg_trab.agregarTrabajador(rut_trab,nom_trab,ape_trab,id_tien_trab,cargo_trab); 
                        reg_trab.listaTrabajadores(); 
                    }
                    else if (trabj == 2)//listado trabajadores
                    {
                        Console.WriteLine("          Lista de Trabajadores");
                        Trabajadores t = new Trabajadores();
                        t.listaTrabajadores(); 
                    }

                    //aqui else if 3 
                    
                
                }
                else
                {
                    iniciador = false; 
                }

            

            }
            Console.WriteLine("Grcaias por usar nuestro Sitema!!");
           
        }
        
    }
}
