using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return _jogoDao.ObterTodosJogo();
        }
        
        
    }
}
