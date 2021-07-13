using System;
using System.Collections.Generic;
using Batalha_Naval.model;

namespace Batalha_Naval
{
    public class Controller
    {
        Jogo jogo;

        public Controller(Tabuleiro player)
        {
            jogo = new Jogo(player);
        }

        public bool jogador(int x, int y)
        {
            return jogo.jogador(x, y);
        }

        public bool computadorIA()
        {
            return jogo.computadorIA();
        }

        public bool posicaoBarcosJogador(String infos)
        {
            int barco, x, y;
            bool orientacao;
            String[] separadas = infos.Split(',');
            barco = Int32.Parse(separadas[0]);
            orientacao = bool.Parse(separadas[1]);
            x = Int32.Parse(separadas[2]);
            y = Int32.Parse(separadas[3]);
            return jogo.posicaoBarcos(barco, orientacao, y, x);
        }

        public void posicaoBarcosComputadorIA()
        {
            jogo.getComputadorIA().posicaoBarcos();
        }

        public IA getComputadorIA()
        {
            return jogo.getComputadorIA();
        }

        public Tabuleiro tabuleiroJogador()
        {
            return jogo.getTabuleiroJogador();
        }

        public Tabuleiro tabuleiroComputador()
        {
            return jogo.getTabuleiroComputador();
        }

        public int contadorBarcosComputador()
        {
            return jogo.getContadorBarcosJogador();
        }

        public int contadorBarcosJogador()
        {
            return jogo.getContadorBarcosIA();
        }

        public bool posicionarBarcosIA(Tabuleiro tabIA)
        {
            return true;
        }

        public int[] getBarcosSelecionaveis()
        {
            return jogo.getEmbarcacoes();
        }

    }
}