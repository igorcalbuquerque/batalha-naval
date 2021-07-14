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
            
            bool validarPosicao = true; /* Inicia como True, caso não satisfaça as condições dentro do laço, permanece True */

            for (int i = 0; i < barco.getTamanho(); i++)
            {
                if (orientacao)
                {
                    /* Se o tamanho do barco no eixo X for maior do que o tamanho do tabuleiro, não é valido */
                    if ((x + barco.getTamanho()) > tabuleiro.getTabuleiroTamanho() ||
                    tabuleiro.getPecas()[x + i, y].GetType() != typeof(Agua))
                    {
                        validarPosicao = false;
                        break;
                    }
                }
                else
                {
                    /* Se o tamanho do barco no eixo Y for maior do que o tamanho do tabuleiro, não é valido */
                    if ((y + barco.getTamanho()) > tabuleiro.getTabuleiroTamanho() ||
                    tabuleiro.getPecas()[x, y + i].GetType() != typeof(Agua))
                    {
                        validarPosicao = false;
                        break;
                    }
                }
            }

            /* Sendo válida a posição, a embarcação é posicionada obedecendo os parametros de entrada do método */
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
               
            /* Seta a posicao da embarcacao */

            barco.setOrientacao(orientacao);
            barco.setXInicial(x);
            barco.setYInicial(y);

            return validarPosicao;
        }

        public void posicaoBarcos()
        {
            insereBarcosLista(); /* Embarcacoes inseridas no array */

            bool[] orientacao = new bool[2]; /* Vertical ou horizontal */
            orientacao[0] = true;
            orientacao[1] = false;

            int indexOrientacao;
            int xRandom;
            int yRandom;

            /* Posicionamento aleatório dos barcos fazendo uso do random */
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

        private (int, int) escolherEixo(Tabuleiro tabuleiroJogador)
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
                        if (eixoX + 1 < 10 && !tabuleiroJogador.getPecas()[eixoX + 1, eixoY].getFoiAtingido())
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
                        if (eixoX - 1 >= 0 && !tabuleiroJogador.getPecas()[eixoX - 1, eixoY].getFoiAtingido())
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
                        if (eixoY + 1 < 10 && !tabuleiroJogador.getPecas()[eixoX, eixoY + 1].getFoiAtingido())
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
                        if (eixoY - 1 >= 0 && !tabuleiroJogador.getPecas()[eixoX, eixoY - 1].getFoiAtingido())
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

                if (!tabuleiroJogador.getPecas()[eixoX, eixoY].getFoiAtingido() && checkPosicaoTiro)
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

        public bool atirar(Tabuleiro tabuleiroJogador)
        {
            bool acertou = false;
            var (eixoXVar, eixoYVar) = escolherEixo(tabuleiroJogador);

            int eixoX = eixoXVar;
            int eixoY = eixoYVar;

            Peca barco = tabuleiroJogador.getPecas()[eixoX, eixoY];
            int tamanhoBarco = barco.getTamanho();

            jogadasEixoX.Add(eixoX);
            jogadasEixoY.Add(eixoY);

            if (barco.GetType() != typeof(Agua))
            {
                tabuleiroJogador.getPecas()[eixoX, eixoY].setTamanho(tamanhoBarco - 1);
                tamanhoBarco = tabuleiroJogador.getPecas()[eixoX, eixoY].getTamanho();

                if (tamanhoBarco <= 0)
                {
                    tabuleiroJogador.getPecas()[eixoX, eixoY].setFoiAtingido(true);
                }

                tabuleiroJogador.getPecas()[eixoX, eixoY] = new TiroEmbarcacao(true);
                posicoesFinaisBarcoAtigindoEixoX.Add(eixoX); // Guarda as posições ao acertar
                posicoesFinaisBarcoAtigindoEixoY.Add(eixoY); // Guarda as posições ao acertar
                acertou = true;
            }
            else
            {
                tabuleiroJogador.getPecas()[eixoX, eixoY] = new TiroAgua(true);
                acertou = false;
            }

            if (tamanhoBarco <= 0)
            { // Ao atingir todas as casas ocupadas pela embarcacao, cai nesta condicao e irá zerar as listas com posicoes finais
                tabuleiroJogador.getPecas()[eixoX, eixoY] = new TiroEmbarcacao(true);
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