using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_barbearia.models
{
    public class Agendamento
    {
        public DateTime Data { get; set; }
        public Cliente Cliente { get; set; }

        public Agendamento(DateTime data, Cliente cliente)
        {
            Data = data;
            Cliente = cliente;
        }
    }
    
}