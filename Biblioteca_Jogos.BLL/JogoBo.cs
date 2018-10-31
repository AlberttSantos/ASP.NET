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

        public Jogo CarregarJogoSelecionado(int id_jogo)
        {
            _jogoDao = new JogoDao();
            var jogo = _jogoDao.CarregarJogoSelecionado(id_jogo);

            if(jogo == null)
            {
                throw new JogoNaoEncontradoException();
            }

            return jogo;
        }

        public void InserirNovoJogo(Jogo jogo)
        {
            ValidarJogo(jogo);

            _jogoDao = new JogoDao();
            int linhasAfetadas = _jogoDao.InserirJogo(jogo);

            if (linhasAfetadas == 0)
            {
                throw new EdicaoNaoEfetuadaException();
            }
        }

        public void ValidarJogo(Jogo jogo)
        {
            if (string.IsNullOrWhiteSpace(jogo.Titulo)
                || jogo.Id_Editor == 0
                || jogo.Id_Genero == 0)
            {
                throw new UsuarioNaoCadastradoExceptions();
            }
        }

        public void EditarJogo(Jogo jogo)
        {
            ValidarJogo(jogo);

            _jogoDao = new JogoDao();
            var linhasAfetadas = _jogoDao.EditarJogo(jogo);

            if(linhasAfetadas == 0)
            {
                throw new EdicaoNaoEfetuadaException();
            }
        }
    }
}
