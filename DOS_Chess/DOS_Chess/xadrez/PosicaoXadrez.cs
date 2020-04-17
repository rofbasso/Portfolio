using tabuleiro;

//Faz as posições do Xadrez sendo de A até H nas colunas e de 1 a 8 nas linhas
namespace xadrez
{
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linha { get; set; }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna = coluna;
            Linha = linha;
        }

        //Converte a posição do Xadrez para posição de matriz. Ex: A1 = 7;0
        public Posicao ToPosicao()
        {
            return new Posicao(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }

    }
}
