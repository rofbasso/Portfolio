﻿namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao PosicaoPeca { get; set; }
        public Cor CorPeca { get;protected set; }
        public int QteMovimentos { get;protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            PosicaoPeca = null;
            CorPeca = cor;
            Tab = tab;
            QteMovimentos = 0;
        }

        public void IncrementarQteMovimentos()
        {
            QteMovimentos++;
        }

        public void DecrementarQteMovimentos()
        {
            QteMovimentos--;
        }


        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tab.Linhas; i++)
            {
                for(int j = 0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MovimentoPossivel(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }


        public abstract bool[,] MovimentosPossiveis();

    }
}