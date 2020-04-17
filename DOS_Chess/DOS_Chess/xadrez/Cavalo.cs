using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            pos.DefiniValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna - 2);
            if(Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefiniValores(PosicaoPeca.Linha - 2, PosicaoPeca.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefiniValores(PosicaoPeca.Linha - 2, PosicaoPeca.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefiniValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefiniValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna + 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefiniValores(PosicaoPeca.Linha + 2, PosicaoPeca.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefiniValores(PosicaoPeca.Linha + 2, PosicaoPeca.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefiniValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna - 2);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }

        //Verifica se há alguma peça na posição
        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.PecaTab(pos);

            return p == null || p.CorPeca != this.CorPeca;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
