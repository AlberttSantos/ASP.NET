using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Jogos.BLL.Exceptions
{
    public class JogoNaoEncontradoException : Exception
    {
        public JogoNaoEncontradoException() { }
        public JogoNaoEncontradoException(string mensagem) : base(mensagem) { }
    }
}
