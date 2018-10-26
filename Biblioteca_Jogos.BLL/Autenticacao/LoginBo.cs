using Biblioteca_Jogos.BLL.Exceptions;
using Biblioteca_Jogos.DAL;
using Biblioteca_Jogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Jogos.BLL.Autenticacao
{
    public class LoginBo
    {
        private UsuarioDao _usuarioDao;
        public Usuario ObterUsuarioParaLogar(string nomeUsuario, string senha)
        {
            _usuarioDao = new UsuarioDao();
            var usuario = _usuarioDao.ObterUsuarioESenha(nomeUsuario, senha);
            
            if(usuario == null)
            {
                throw new UsuarioNaoCadastradoExceptions();
            }
            else
            {
                return usuario;
            }
        }
    }
}
