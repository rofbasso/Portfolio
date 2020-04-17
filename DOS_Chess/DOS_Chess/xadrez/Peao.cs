using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez PartidaPeao { get; set; }

        public Peao(Tabuleiro tab, Cor cor, PartidaDeXadrez partidaPeao) : base(tab, cor) 
        {
            PartidaPeao = partidaPeao;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];

            Posicao pos = new Posicao(0, 0);

            if (CorPeca == Cor.Branca)
            {
                pos.DefiniValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //Caso primeiro movimento Ex
                pos.DefiniValores(PosicaoPeca.Linha - 2, PosicaoPeca.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //Diagonal caso seja inimigo
                //Esquerda
                pos.DefiniValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //Direita
                pos.DefiniValores(PosicaoPeca.Linha - 1, PosicaoPeca.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // #JogadaEspecial En Passant
                if(PosicaoPeca.Linha == 3)
                {
                    Posicao esquerda = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
                    if(Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.PecaTab(esquerda) == PartidaPeao.VulneravelenPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.PecaTab(direita) == PartidaPeao.VulneravelenPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }

            }
            else
            {
                pos.DefiniValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //Caso primeiro movimento Ex
                pos.DefiniValores(PosicaoPeca.Linha + 2, PosicaoPeca.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QteMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //Diagonal caso seja inimigo
                //Esquerda
                pos.DefiniValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                //Direita
                pos.DefiniValores(PosicaoPeca.Linha + 1, PosicaoPeca.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                // #JogadaEspecial En Passant
                if (PosicaoPeca.Linha == 4)
                {
                    Posicao esquerda = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.PecaTab(esquerda) == PartidaPeao.VulneravelenPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }
                    Posicao direita = new Posicao(PosicaoPeca.Linha, PosicaoPeca.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.PecaTab(direita) == PartidaPeao.VulneravelenPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
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

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.PecaTab(pos);
            return p != null && p.CorPeca != CorPeca;
        }

        private bool Livre(Posicao pos)
        {
            return Tab.PecaTab(pos) == null;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
