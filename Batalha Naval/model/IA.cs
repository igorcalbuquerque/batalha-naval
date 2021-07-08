using System;
using System.Collections.Generic;
using System.Text;

namespace Batalha_Naval.model
{
    public class IA
    {

        private Random random = new Random();

        private List<int> posicoesFinaisBarcoAtigindoEixoX = new List<int>();
        private List<int> posicoesFinaisBarcoAtigindoEixoY = new List<int>();
        private List<int> jogadasEixoX = new List<int>();
        private List<int> jogadasEixoY = new List<int>();

        private int contadorBarcos;
        private int tamanhoTabuleiro;

        private Tabuleiro tabuleiro;

        private List<Peca> barcos = new List<Peca>();

        private Submarino submarino = new Submarino(true);
        private Encouracado encouracado1 = new Encouracado(true);
        private Encouracado encouracado2 = new Encouracado(true);
        private NavioGuerra navioGuerra = new NavioGuerra(true);
        private PortaAviao portaAviao = new PortaAviao(true);

        enum direcaoCorreta { nada, x_Plus, x_Minus, y_Plus, y_Minus }
        direcaoCorreta ultimaDirecao = direcaoCorreta.x_Plus;

        public IA(int contadorBarcosPlayer, int tamanhoTabuleiro)
        {
            this.contadorBarcos = contadorBarcosPlayer;
            this.tamanhoTabuleiro = tamanhoTabuleiro;
            tabuleiro = new Tabuleiro(this.tamanhoTabuleiro);
        }

        private void insereBarcosLista()
        {
            barcos.Add(submarino);
            barcos.Add(encouracado1);
            barcos.Add(encouracado2);
            barcos.Add(navioGuerra);
            barcos.Add(portaAviao);
        }

        private bool validarPosicaoBarco(Peca barco, bool orientacao, int x, int y)
        {

            bool validarPosicao = true;

            for (int i = 0; i < barco.getTamanho(); i++)
            {
                if (orientacao)
                {
                    if ((x + barco.getTamanho()) > tabuleiro.getTabuleiroTamanho() ||
                    tabuleiro.getPecas()[x + i, y].GetType() != typeof(Agua))
                    {
                        validarPosicao = false;
                        break;
                    }
                }
                else
                {
                    if ((y + barco.getTamanho()) > tabuleiro.getTabuleiroTamanho() ||
                    tabuleiro.getPecas()[x, y + i].GetType() != typeof(Agua))
                    {
                        validarPosicao = false;
                        break;
                    }
                }
            }

            if (validarPosicao)
            {
                for (int i = 0; i < barco.getTamanho(); i++)
                {
                    if (orientacao)
                    {
                        tabuleiro.getPecas()[x + i, y] = barco;                        
                    }
                    else
                    {
                        tabuleiro.getPecas()[x, y + i] = barco;                        
                    }
                }
            }

            barco.setOrientacao(orientacao);
            barco.setXInicial(x);
            barco.setYInicial(y);

            return validarPosicao;
        }

        public void posicaoBarcos()
        {
            insereBarcosLista();

            bool[] orientacao = new bool[2];
            orientacao[0] = true;
            orientacao[1] = false;

            int indexOrientacao;
            int xRandom;
            int yRandom;

            for (int i = 0; i < barcos.Count; i++)
            {
                while (true)
                {
                    bool check = false;

                    indexOrientacao = random.Next(0, 2);
                    xRandom = random.Next(0, tamanhoTabuleiro - 1);
                    yRandom = random.Next(0, tamanhoTabuleiro - 1);

                    check = validarPosicaoBarco(barcos[i], orientacao[indexOrientacao], xRandom, yRandom);

                    if (check)
                    {
                        Console.WriteLine("Inicia em x" + xRandom + " - y:" + yRandom + " bool " + orientacao[indexOrientacao]);
                        break;
                    }
                }
            }
        }

        private (int, int) escolherEixo(Tabuleiro tabPlayer)
        {
            int eixoX = 0;
            int eixoY = 0;

            while (true)
            {
                if (jogadasEixoX.Count == 0)
                {
                    eixoX = random.Next(2, 8);
                    eixoY = random.Next(2, 7);
                }
                else
                {
                    eixoX = random.Next(0, 10);
                    eixoY = random.Next(0, 10);
                }

                if (posicoesFinaisBarcoAtigindoEixoX.Count > 0)
                {
                    eixoX = posicoesFinaisBarcoAtigindoEixoX[posicoesFinaisBarcoAtigindoEixoX.Count - 1];
                    eixoY = posicoesFinaisBarcoAtigindoEixoY[posicoesFinaisBarcoAtigindoEixoY.Count - 1];

                    if (ultimaDirecao.Equals(direcaoCorreta.x_Plus))
                    {
                        if (eixoX + 1 < 10 && !tabPlayer.getPecas()[eixoX + 1, eixoY].getFoiAtingido())
                        {
                            eixoX++;
                        }
                        else
                        {
                            ultimaDirecao = direcaoCorreta.x_Minus;
                        }
                    }
                    if (ultimaDirecao.Equals(direcaoCorreta.x_Minus))
                    {
                        if (eixoX - 1 >= 0 && !tabPlayer.getPecas()[eixoX - 1, eixoY].getFoiAtingido())
                        {
                            eixoX--;
                        }
                        else
                        {
                            ultimaDirecao = direcaoCorreta.y_Plus;
                        }
                    }
                    if (ultimaDirecao.Equals(direcaoCorreta.y_Plus))
                    {
                        if (eixoY + 1 < 10 && !tabPlayer.getPecas()[eixoX, eixoY + 1].getFoiAtingido())
                        {
                            eixoY++;
                        }
                        else
                        {
                            ultimaDirecao = direcaoCorreta.y_Minus;
                        }
                    }
                    if (ultimaDirecao.Equals(direcaoCorreta.y_Minus))
                    {
                        if (eixoY - 1 >= 0 && !tabPlayer.getPecas()[eixoX, eixoY - 1].getFoiAtingido())
                        {
                            eixoY--;
                        }
                    }
                    if (ultimaDirecao.Equals(direcaoCorreta.nada))
                    {
                        posicoesFinaisBarcoAtigindoEixoX.RemoveRange(1, posicoesFinaisBarcoAtigindoEixoX.Count - 1);
                        posicoesFinaisBarcoAtigindoEixoY.RemoveRange(1, posicoesFinaisBarcoAtigindoEixoY.Count - 1);
                    }
                }

                bool checkPosicaoTiro = true;
                for (int i = 0; i < jogadasEixoX.Count; i++)
                {
                    if (jogadasEixoX[i] == eixoX && jogadasEixoY[i] == eixoY)
                    {
                        checkPosicaoTiro = false;
                        break;
                    }
                }

                if (!tabPlayer.getPecas()[eixoX, eixoY].getFoiAtingido() && checkPosicaoTiro)
                {
                    break;
                }
                else
                {
                    if (ultimaDirecao.Equals(direcaoCorreta.y_Minus))
                    {
                        ultimaDirecao = direcaoCorreta.nada;
                    }
                    else
                    {
                        ultimaDirecao++;
                    }
                }
            }
            return (eixoX, eixoY);
        }

        public bool atirar(Tabuleiro tbJogador)
        {
            bool acertou = false;
            var (eixoXVar, eixoYVar) = escolherEixo(tbJogador);

            int eixoX = eixoXVar;
            int eixoY = eixoYVar;

            Peca barco = tbJogador.getPecas()[eixoX, eixoY];
            int tamanhoBarco = barco.getTamanho();

            jogadasEixoX.Add(eixoX);
            jogadasEixoY.Add(eixoY);

            if (barco.GetType() != typeof(Agua))
            {
                tbJogador.getPecas()[eixoX, eixoY].setTamanho(tamanhoBarco - 1);
                tamanhoBarco = tbJogador.getPecas()[eixoX, eixoY].getTamanho();

                if (tamanhoBarco <= 0)
                {
                    tbJogador.getPecas()[eixoX, eixoY].setFoiAtingido(true);
                }

                tbJogador.getPecas()[eixoX, eixoY] = new TiroEmbarcacao(true);
                posicoesFinaisBarcoAtigindoEixoX.Add(eixoX);
                posicoesFinaisBarcoAtigindoEixoY.Add(eixoY);
                acertou = true;
            }
            else
            {
                tbJogador.getPecas()[eixoX, eixoY] = new TiroAgua(true);
                acertou = false;
            }

            if (tamanhoBarco <= 0)
            {
                tbJogador.getPecas()[eixoX, eixoY] = new TiroEmbarcacao(true);
                contadorBarcos -= 1;
                posicoesFinaisBarcoAtigindoEixoX.Clear();
                posicoesFinaisBarcoAtigindoEixoY.Clear();
                ultimaDirecao = direcaoCorreta.x_Plus;
            }
            return acertou;
        }

        public int getContadorBarcos()
        {
            return this.contadorBarcos;
        }

        public Tabuleiro getTabuleiro()
        {
            return this.tabuleiro;
        }
    }
}