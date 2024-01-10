using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_barbearia.models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Celular { get; set; }

        public Cliente(string nome, string sobrenome, string celular)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Celular = celular;
        }
    }
}