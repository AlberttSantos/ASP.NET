using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca_Jogos.BLL.Exceptions;
using Biblioteca_Jogos.DAL;
using Biblioteca_Jogos.Entities;

namespace Biblioteca_Jogos.BLL
{
    public class JogoBo
    {
        private JogoDao _jogoDao;

        public List<Jogo> ObterTodosJogos()
        {
            _jogoDao = new JogoDao();
            return _jogoDao.ObterTodosJogos();
        }

        public void EditarJogos(Jogo jogo)
        {
            _jogoDao = new JogoDao();            

            var linhasAfetadas = _jogoDao.EditarJogos(jogo);

            if (linhasAfetadas == 0)
            {
                throw new EdicaoNaoEfetuadaException();
            }

        }
    }
}
