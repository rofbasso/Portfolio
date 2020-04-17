using exceptions;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        //Posicao atual da peça
        public Peca PecaTab(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        //Recebe a movimentacão da peça
        public Peca PecaTab(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        //Faz a verificação se existe peça
        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return PecaTab(pos) != null;
        }

        //Coloca a peça no tabuleiro
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.PosicaoPeca = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if(PecaTab(pos) == null)
            {
                return null;
            }
            Peca aux = PecaTab(pos);
            aux.PosicaoPeca = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        //Verifica se a posição é válida ou nao
        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha<0 || pos.Linha>=Linhas || pos.Coluna<0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        //Mensagem de erro se a posição for inválida
        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida");
            }
        }

    }
}
