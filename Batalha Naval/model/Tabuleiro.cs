using System;
using System.Collections.Generic;
using System.Text;

namespace Batalha_Naval.model
{
    public  class Tabuleiro
    {
        
        private int tabuleiroTamanho;
        private Peca[,] pecas;

        public Tabuleiro(int tabTamanho = 10)
        {
            this.tabuleiroTamanho = tabTamanho;
            this.pecas = geraMatriz();
        }

        public int getTabuleiroTamanho()
        {
            return this.tabuleiroTamanho;
        }

        public void setTamanhoTabuleiro(int tamanhoTab)
        {
            this.tabuleiroTamanho = tamanhoTab;
        }

        public Peca[,] getPecas()
        {
            return this.pecas;
        }

        public void setPecas(Peca[,] pecas)
        {
            this.pecas = pecas;
        }

        public Peca[,] geraMatriz()
        {
            this.pecas = new Peca[this.tabuleiroTamanho, this.tabuleiroTamanho];
            for (int i = 0; i < tabuleiroTamanho; i++)
            {
                for (int j = 0; j < tabuleiroTamanho; j++)
                {
                    Peca agua = new Agua(true);
                    pecas[i, j] = agua;
                }
            }            
            return pecas;
        }
    
    public override string ToString()
        {
            return "Tamnho: " + this.tabuleiroTamanho+ "\nTabuleiro:" + this.pecas;
        }
    }

}
