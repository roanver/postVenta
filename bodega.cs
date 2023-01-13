using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda
{
    internal class bodega
    {
        private int id_bodega;
        private string direccion_bodega;
        private string telefono_bodega;
        private string correo_bodega;

        public void setId_bodega(int id_bodega)
        {
            this.id_bodega = id_bodega;
        }
        public int getId_Bodega()
        {
            return this.id_bodega;
        }
        public void setDireccion(string direccion_bodega)
        {
            this.direccion_bodega = direccion_bodega;
        }
        public string getDireccion_bodega()
        {
            return this.direccion_bodega;
        }
        public void setTelefono_bodega(string telefono_bodega)
        {
            this.telefono_bodega = telefono_bodega;
        }
        public string getTelefono_bodega()
        {
            return this.telefono_bodega;
        }
        public void setCorreo_bodega(string correo_bodega)
        {
            this.correo_bodega = correo_bodega;
        }
        public string getCorreo_bodega()
        {
            return this.correo_bodega;
        }

    }
}