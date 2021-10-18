using System;
using System.Collections.Generic;
using System.Text;

namespace Exemplo.Application.ViewModel
{
    public class ContatoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
        public bool IsAtivo { get; set; }
        public string Erro { get; set; }
    }
}