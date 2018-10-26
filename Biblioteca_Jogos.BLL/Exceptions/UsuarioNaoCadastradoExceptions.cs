using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Jogos.BLL.Exceptions
{
    public class UsuarioNaoCadastradoExceptions : Exception
    {
        public UsuarioNaoCadastradoExceptions() { }
        public UsuarioNaoCadastradoExceptions(string mensagem) : base(mensagem) { }        
    }
}
