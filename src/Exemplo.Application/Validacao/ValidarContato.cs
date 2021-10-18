using System;
using System.Collections.Generic;
using System.Text;
using Exemplo.Application.ViewModel;

namespace Exemplo.Application.Validacao
{
    public class ValidarContato
    {
        public static string ValidarDados(ContatoViewModel obj)
        {
            if (obj.DataNascimento > DateTime.Now)
                return "Data de nascimento não pode ser maior que a data atual!";

            if (obj.Idade < 18)
                return "O contato precisa ter mais que 18 anos!" ;

            return "";
        }
    }
}
