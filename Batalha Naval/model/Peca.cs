using System;
using System.Collections.Generic;
using System.Text;


namespace Batalha_Naval.model
{
    public abstract class Peca
    {
        private bool orientacao;
        private bool foiAtingido;
        private int tamanho;
        private int id;

        private int xInicial, yInicial;

        protected Peca(bool orientacao)
        {
            this.orientacao = orientacao;
        }

        public int getId()
        {
            return this.id;
        }

        public int getXInicial()
        {
            return this.xInicial;
        }

        public int getYInicial()
        {
            return this.yInicial;
        }

        public void setXInicial(int x)
        {
            this.xInicial = x;
        }

        public void setYInicial(int y)
        {
            this.yInicial = y;
        }

        public void setId(int id)
        {
            this.id = id;
        }
       

        public Boolean getOrientacao()
        {
            return this.orientacao;
        }

        public void setOrientacao(bool orientacao)
        {
            this.orientacao = orientacao;
        }

        public bool getFoiAtingido()
        {
            return this.foiAtingido;
        }
        public int getTamanho()
        {
            return this.tamanho;
        }
        public void setTamanho(int tamanho)
        {
            this.tamanho = tamanho;
        }
        
        public void setFoiAtingido(bool status)
        {
            this.foiAtingido=status;
        }

        public override string ToString()
        {
            return "Orientacao: " + this.orientacao+ "\nPeça que foi atacada:"+this.foiAtingido
                + "\ntamanho:"+this.tamanho;
        }
        

    }
}
