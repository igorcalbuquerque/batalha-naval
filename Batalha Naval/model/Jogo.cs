using System;
using System.Collections.Generic;
using Batalha_Naval.model;

namespace Batalha_Naval
{
    public class Jogo
    {
        private List<int> jogadasJogadorEixoX = new List<int>();
        private List<int> jogadasJogadorEixoY = new List<int>();

        private int[] embarcacoes;

        private IA computador;

        private int contadorBarcosIA = 5;
        private int contadorBarcosJogador = 5;

        private Tabuleiro tabuleiroJogador;

        private Submarino submarino = new Submarino(true);
        private Encouracado encouracado1 = new Encouracado(true);
        private Encouracado encouracado2 = new Encouracado(true);
        private NavioGuerra navioGuerra = new NavioGuerra(true);
        private PortaAviao portaAviao = new PortaAviao(true);

        public Jogo(Tabuleiro tabuleiroJogador)
        {
            this.embarcacoes = new int[5];
            this.tabuleiroJogador = tabuleiroJogador;
            this.computador = new IA(contadorBarcosJogador, this.tabuleiroJogador.getTabuleiroTamanho());
            for (int i = 0; i < 5; i++)
            {
                embarcacoes[i] = 1;
            }
        }

        public bool posicaoBarcos(int barco, bool orientacao, int x, int y)
        {

            bool validarPosicao = true;
            Peca tipoEmbarcacao;

            if (barco == 0)
            {
                tipoEmbarcacao = submarino;
            }
            else if (barco == 1)
            {
                tipoEmbarcacao = encouracado1;
            }
            else if (barco == 2)
            {
                tipoEmbarcacao = encouracado2;
            }
            else if (barco == 3)
            {
                tipoEmbarcacao = navioGuerra;
            }
            else
            {
                tipoEmbarcacao = portaAviao;
            }

            for (int i = 0; i < tipoEmbarcacao.getTamanho(); i++)
            {
                if (orientacao)
                {
                    if ((x + tipoEmbarcacao.getTamanho()) > tabuleiroJogador.getTabuleiroTamanho() ||
                    tabuleiroJogador.getPecas()[x + i, y].GetType() != typeof(Agua))
                    {
                        validarPosicao = false;
                        break;
                    }
                }
                else
                {
                    if ((y + tipoEmbarcacao.getTamanho()) > tabuleiroJogador.getTabuleiroTamanho() ||
                    tabuleiroJogador.getPecas()[x, y + i].GetType() != typeof(Agua))
                    {
                        validarPosicao = false;
                        break;
                    }
                }
            }

            if (validarPosicao)
            {
                for (int i = 0; i < tipoEmbarcacao.getTamanho(); i++)
                {
                    if (orientacao)
                    {
                        tabuleiroJogador.getPecas()[x + i, y] = tipoEmbarcacao;
                    }
                    else
                    {
                        tabuleiroJogador.getPecas()[x, y + i] = tipoEmbarcacao;
                    }
                }
            }

            tipoEmbarcacao.setOrientacao(orientacao);
            tipoEmbarcacao.setXInicial(x);
            tipoEmbarcacao.setYInicial(y);
            return validarPosicao;
        }

        public bool jogador(int x, int y)
        {
            bool acertou = false;

            Peca barco = getTabuleiroComputador().getPecas()[x, y];
            int tamanhoBarco = barco.getTamanho();

            jogadasJogadorEixoX.Add(x);
            jogadasJogadorEixoY.Add(y);

            if (barco.GetType() != typeof(Agua) && !barco.getFoiAtingido())
            {
                getTabuleiroComputador().getPecas()[x, y].setTamanho(tamanhoBarco - 1);

                tamanhoBarco = getTabuleiroComputador().getPecas()[x, y].getTamanho();

                if (tamanhoBarco <= 0)
                {
                    getTabuleiroComputador().getPecas()[x, y].setFoiAtingido(true);
                }

                getTabuleiroComputador().getPecas()[x, y] = new TiroEmbarcacao(true);
                acertou = true;
            }
            else if (barco.getFoiAtingido())
            {
                acertou = true;
            }
            else
            {
                getTabuleiroComputador().getPecas()[x, y] = new TiroAgua(true);
                acertou = false;
            }

            if (tamanhoBarco <= 0)
            {
                getTabuleiroComputador().getPecas()[x, y] = new TiroEmbarcacao(true);
                contadorBarcosIA -= 1;
            }
            return acertou;
        }

        public bool computadorIA()
        {
            return computador.atirar(tabuleiroJogador);
        }

        public IA getComputadorIA()
        {
            return this.computador;
        }

        public Tabuleiro getTabuleiroComputador()
        {
            return this.computador.getTabuleiro();
        }

        public Tabuleiro getTabuleiroJogador()
        {
            return this.tabuleiroJogador;
        }

        public int getContadorBarcosIA()
        {
            return this.contadorBarcosIA;
        }

        public int getContadorBarcosJogador()
        {
            return getComputadorIA().getContadorBarcos();
        }

        public int[] getEmbarcacoes()
        {
            return this.embarcacoes;
        }
    }
}