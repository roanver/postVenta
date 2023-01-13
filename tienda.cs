using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda
{
    internal class delivery
    {
        private int id_delivery;
        private string horario_entrega;
        private string estado;

        public void setId_delivery(int id_delivery)
        {
            this.id_delivery = id_delivery;
        }
        public int getId_delivery()
        {
            return this.id_delivery;
        }
        public void setHorario_entrega(string horario_entrega)
        {
            this.horario_entrega = horario_entrega;
        }
        public string getHorario_entrega()
        {
            return this.horario_entrega;
        }
        public void setEstado(string estado)
        {
            this.estado = estado;
        }
        public string getEstado()
        {
            return this.estado;
        }
    }
}