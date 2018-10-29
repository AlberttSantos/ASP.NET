using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Jogos.BLL.Exceptions
{
    class EdicaoNaoEfetuadaException : Exception
    {
        public EdicaoNaoEfetuadaException() { }
        public EdicaoNaoEfetuadaException(string mensagem) : base(mensagem) { }
    }
}
