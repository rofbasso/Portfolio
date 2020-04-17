using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez PartidaRei;

        public Rei(Tabuleiro tab, Cor cor, PartidaDeXadrez partidaRei) : base(tab, cor) 
        {
            PartidaRei = partidaRei;
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Tab.PecaTab(pos);
            return p != null && p is Torre && p.CorPeca == CorPeca && p.QteMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.DefiniValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna);
            if(Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Direita Cima
            pos.DefiniValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Direita
            pos.DefiniValores(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Direita baixo
            pos.DefiniValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Abaixo
            pos.DefiniValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Esquerda Baixo
            pos.DefiniValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Esquerda
            pos.DefiniValores(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            //Esquerda Cima
            pos.DefiniValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            // #jogadaEspecial ROQUE
            if(QteMovimentos == 0 && !PartidaRei.Xeque)
            {
                // #jogadaEspecial Roque Pequeno
                Posicao posT1 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 3);
                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
                    Posicao p2 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 2);
                    if(Tab.PecaTab(p1) == null && Tab.PecaTab(p2) == null)
                    {
                        mat[PosicaoPeca.Linha, PosicaoPeca.Coluna + 2] = true;
                    }
                }
                // #jogadaEspecial Roque Grande
                Posicao posT2 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 4);
                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
                    Posicao p2 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 2);
                    Posicao p3 = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 3);
                    if (Tab.PecaTab(p1) == null && Tab.PecaTab(p2) == null && Tab.PecaTab(p3) == null)
                    {
                        mat[PosicaoPeca.Linha, PosicaoPeca.Coluna - 2] = true;
                    }
                }

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
            return "R";
        }
    }
}
