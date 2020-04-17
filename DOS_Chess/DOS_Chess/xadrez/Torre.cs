using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.DefiniValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if(Tab.PecaTab(pos) != null && Tab.PecaTab(pos).CorPeca != CorPeca)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }
            //Abaixo
            pos.DefiniValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.PecaTab(pos) != null && Tab.PecaTab(pos).CorPeca != CorPeca)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            //Direita
            pos.DefiniValores(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.PecaTab(pos) != null && Tab.PecaTab(pos).CorPeca != CorPeca)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }
            //Esquerda
            pos.DefiniValores(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.PecaTab(pos) != null && Tab.PecaTab(pos).CorPeca != CorPeca)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
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
            return "T";
        }
    }
}
