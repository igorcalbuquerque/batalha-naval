using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Window;
using SFML.Graphics;
using Batalha_Naval;

namespace Batalha_Naval.view
{
    class Interface
    {
        TelaInicial telaInicial;

        static tabuleiroView tabuleiroComputador = new tabuleiroView();
        static tabuleiroView tabuleiroJogador = new tabuleiroView();

        private Controller controlador = new Controller(tabuleiroJogador.getTabuleiro());

        private bool jogadaJogador = true;
        private bool jogadaComputador = false;

        private bool jogo = true;

        private String vencedor;
        
        static uint largura = VideoMode.DesktopMode.Width;
        static uint altura = VideoMode.DesktopMode.Height;
        static RenderWindow janela = new RenderWindow(new VideoMode(largura, altura), "Batalha Naval PLP", Styles.Fullscreen);
        
        public void Partida()
        {
            janela.Closed += Janela_Closed;
            Texture bgTexture = new Texture("D:/UFAPE/PLP/Batalha-Naval/Batalha Naval/images/water.jpg");
            Sprite bgSpt = new Sprite(bgTexture);
            Sprite submarinoSpt = new Sprite(tabuleiroJogador.submarinoTextura);
            Sprite encouracadoSpt = new Sprite(tabuleiroJogador.encouracadoTextura);
            Sprite navioGuerraSpt = new Sprite(tabuleiroJogador.navioGuerraTextura);
            Sprite portaAvioesSpt = new Sprite(tabuleiroJogador.portaAvioesTextura);

            Font arial = new Font("Font/arial.ttf");

            while (janela.IsOpen && jogo)
            {
                
                while (tabuleiroJogador.getSetup().Equals(true))
                {
                    janela.DispatchEvents();
                    janela.Draw(bgSpt);
                    tabuleiroJogador.desenharTabuleiroJogador(janela, 80, 160);
                    tabuleiroJogador.desenharBarraBarcos(janela, (int)largura / 2, 160);
                    changeOrientacao();
                    janela.Display();
                    getBarcoPlayer();
                    
                    while (tabuleiroJogador.getEmbarcacao() != -1)
                    {
                        janela.DispatchEvents();
                        janela.Draw(bgSpt);
                        tabuleiroJogador.desenharTabuleiroJogador(janela, 80, 160);
                        tabuleiroJogador.desenharBarraBarcos(janela, (int)largura / 2, 160);
                        changeOrientacao();
                        if (tabuleiroJogador.getEmbarcacao() == 0)
                        {
                            if (tabuleiroJogador.getOrientacao().Equals(true))
                            {
                                submarinoSpt.Position = new SFML.System.Vector2f(Mouse.GetPosition().X - 20, Mouse.GetPosition().Y - 20);
                                submarinoSpt.Rotation = 0;
                            }
                            if (tabuleiroJogador.getOrientacao().Equals(false))
                            {
                                submarinoSpt.Rotation = 90;
                                submarinoSpt.Position = new SFML.System.Vector2f(Mouse.GetPosition().X + 20, Mouse.GetPosition().Y - 20);
                            }
                            janela.Draw(submarinoSpt);
                        }
                        else if (tabuleiroJogador.getEmbarcacao() == 1)
                        {

                            if (tabuleiroJogador.getOrientacao().Equals(true))
                            {
                                encouracadoSpt.Position = new SFML.System.Vector2f(Mouse.GetPosition().X - 20, Mouse.GetPosition().Y - 20);
                                encouracadoSpt.Rotation = 0;
                            }
                            if (tabuleiroJogador.getOrientacao().Equals(false))
                            {
                                encouracadoSpt.Rotation = 90;
                                encouracadoSpt.Position = new SFML.System.Vector2f(Mouse.GetPosition().X + 20, Mouse.GetPosition().Y - 20);
                            }
                            janela.Draw(encouracadoSpt);
                        }
                        else if (tabuleiroJogador.getEmbarcacao() == 2)
                        {

                            if (tabuleiroJogador.getOrientacao().Equals(true))
                            {
                                encouracadoSpt.Position = new SFML.System.Vector2f(Mouse.GetPosition().X - 20, Mouse.GetPosition().Y - 20);
                                encouracadoSpt.Rotation = 0;
                            }
                            if (tabuleiroJogador.getOrientacao().Equals(false))
                            {
                                encouracadoSpt.Rotation = 90;
                                encouracadoSpt.Position = new SFML.System.Vector2f(Mouse.GetPosition().X + 20, Mouse.GetPosition().Y - 20);
                            }
                            janela.Draw(encouracadoSpt);
                        }
                        else if (tabuleiroJogador.getEmbarcacao() == 3)
                        {

                            if (tabuleiroJogador.getOrientacao().Equals(true))
                            {
                                navioGuerraSpt.Position = new SFML.System.Vector2f(Mouse.GetPosition().X - 20, Mouse.GetPosition().Y - 20);
                                navioGuerraSpt.Rotation = 0;
                            }
                            if (tabuleiroJogador.getOrientacao().Equals(false))
                            {
                                navioGuerraSpt.Rotation = 90;
                                navioGuerraSpt.Position = new SFML.System.Vector2f(Mouse.GetPosition().X + 20, Mouse.GetPosition().Y - 20);
                            }
                            janela.Draw(navioGuerraSpt);
                        }
                        else if (tabuleiroJogador.getEmbarcacao() == 4)
                        {

                            if (tabuleiroJogador.getOrientacao().Equals(true))
                            {
                                portaAvioesSpt.Position = new SFML.System.Vector2f(Mouse.GetPosition().X - 20, Mouse.GetPosition().Y - 20);
                                portaAvioesSpt.Rotation = 0;
                            }
                            if (tabuleiroJogador.getOrientacao().Equals(false))
                            {
                                portaAvioesSpt.Rotation = 90;
                                portaAvioesSpt.Position = new SFML.System.Vector2f(Mouse.GetPosition().X + 20, Mouse.GetPosition().Y - 20);
                            }
                            janela.Draw(portaAvioesSpt);
                        }
                        janela.Display();
                        int linha = getLinhaPlayer();
                        int coluna = getColunaPlayer();
                        if (linha >= 0 && linha <= 9 && coluna >= 0 && coluna <= 9)
                        {
                            if (controlador.posicaoBarcosJogador(getPosicaoBarco(tabuleiroJogador.getEmbarcacao(), tabuleiroJogador.getOrientacao(), linha, coluna)))
                            {
                                controlador.getBarcosSelecionaveis()[tabuleiroJogador.getEmbarcacao()] -= 1;
                                tabuleiroJogador.setTabuleiro(controlador.tabuleiroJogador());
                            }
                            tabuleiroJogador.setEmbarcacao(-1);
                        }
                        if (controlador.getBarcosSelecionaveis()[0] == 0
                            && controlador.getBarcosSelecionaveis()[1] == 0
                            && controlador.getBarcosSelecionaveis()[2] == 0
                            && controlador.getBarcosSelecionaveis()[3] == 0
                            && controlador.getBarcosSelecionaveis()[4] == 0)
                        {
                            controlador.getComputadorIA().posicaoBarcos();
                            tabuleiroComputador.setTabuleiro(controlador.tabuleiroComputador());
                            tabuleiroJogador.changeSetup();
                        }
                    }
                }
                janela.DispatchEvents();
                janela.Draw(bgSpt);

                if (jogadaJogador)
                {
                    int linhaIa = getLinhaIA();
                    int colunaIa = getColunaIA();
                    if (linhaIa >= 0 && linhaIa <= 9 && colunaIa >= 0 && colunaIa <= 9)
                    {
                        bool jogada = controlador.jogador(colunaIa, linhaIa);
                        if (jogada)
                        {
                            tabuleiroComputador.setTabuleiro(controlador.tabuleiroComputador());
                        }
                        else
                        {
                            tabuleiroComputador.setTabuleiro(controlador.tabuleiroComputador());
                            jogadaComputador = true;
                            jogadaJogador = false;
                        }
                        if (controlador.contadorBarcosComputador() == 0)
                        {
                            vencedor = "Player";
                            jogo = false;
                        }
                    }
                }
                else if (jogadaComputador)
                {
                    bool jogada = controlador.computadorIA();
                    if (jogada)
                    {
                        tabuleiroJogador.setTabuleiro(controlador.tabuleiroJogador());

                    }
                    else
                    {
                        tabuleiroJogador.setTabuleiro(controlador.tabuleiroJogador());
                        jogadaJogador = true;
                        jogadaComputador = false;
                    }
                    if (controlador.contadorBarcosJogador() == 0)
                    {
                        vencedor = "Computador";
                        jogo = false;
                    }
                }
                tabuleiroJogador.desenharTabuleiroJogador(janela, 80, 160);
                tabuleiroComputador.desenharTabuleiroComputador(janela, (int)largura / 2 + 80, 160);
                janela.Display();
            }

            for (int x = 0; x < 1000; x++)
            {
                Text fimDeJogo;
                janela.DispatchEvents();
                janela.Draw(bgSpt);
                if (vencedor.Equals("Player"))
                {
                    fimDeJogo = new Text("O Vencedor Foi: " + vencedor + "\n\n Voltando Para Tela Inicial!", arial);
                    fimDeJogo.Position = new SFML.System.Vector2f((int)largura / 2 - 250, (int)altura - 200);
                    fimDeJogo.Color = Color.Magenta;
                }
                else
                {
                    fimDeJogo = new Text("O Vencedor Foi: " + vencedor + "\n\n  Voltando Para Tela Inicial!", arial);
                    fimDeJogo.Position = new SFML.System.Vector2f((int)largura / 2 - 250, (int)altura - 200);
                    fimDeJogo.Color = Color.Black;
                }

                tabuleiroJogador.desenharTabuleiroJogador(janela, 80, 160);
                tabuleiroComputador.desenharTabuleiroComputador(janela, (int)largura / 2 + 80, 160);
                janela.Draw(fimDeJogo);
                janela.Display();
            }
            telaInicial = new TelaInicial();
            telaInicial.redenrizar();
            janela.Close();

        }

        private static SFML.System.Vector2i getClickPosition()
        {
            SFML.System.Vector2i posi = new SFML.System.Vector2i(-1, -1);
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                posi = Mouse.GetPosition(janela);

            }
            System.Threading.Thread.Sleep(10);
            return posi;
        }

        public int getColunaIA()
        {
            if (getClickPosition().X > (int)largura / 2 + 80 && getClickPosition().X < (int)largura / 2 + (tabuleiroJogador.getTamanhoTabuleiro() * 40 + 80)
                && getClickPosition().Y > 160 && getClickPosition().Y < (tabuleiroJogador.getTamanhoTabuleiro() * 40 + 160))
            {
                float posMatriz = (getClickPosition().X - ((int)largura / 2) - 80) / 40;
                int posicao = -1;
                
                String a = posMatriz.ToString();
                
                try
                {
                    posicao = Int32.Parse(a[0].ToString());
                }
                catch (Exception e)
                {
                    return -1;
                }
                return posicao;
            }
            else
            {
                return -1;
            }
        }

        public int getLinhaIA()
        {
            if (getClickPosition().X > (int)largura / 2 + 80 && getClickPosition().X < (int)largura / 2 + (tabuleiroJogador.getTamanhoTabuleiro() * 40 + 80)
                && getClickPosition().Y > 160 && getClickPosition().Y < (tabuleiroJogador.getTamanhoTabuleiro() * 40 + 160))
            {
                float posMatriz = (getClickPosition().Y - 160) / 40;
                int posicao = -1;
                
                String a = posMatriz.ToString();
                
                try
                {
                    posicao = Int32.Parse(a[0].ToString());
                }
                catch (Exception e)
                {
                    return -1;
                }
                return posicao;
            }
            else
            {
                return -1;
            }
        }

        public int getColunaPlayer()
        {
            if (getClickPosition().X > 80 && getClickPosition().X < (tabuleiroJogador.getTamanhoTabuleiro() * 40 + 80)
                && getClickPosition().Y > 160 && getClickPosition().Y < (tabuleiroJogador.getTamanhoTabuleiro() * 40 + 160))
            {
                float posMatriz = (getClickPosition().X - 80) / 40;
                int posicao = -1;
                
                String a = posMatriz.ToString();
                
                try
                {
                    posicao = Int32.Parse(a[0].ToString());
                }
                catch (Exception e)
                {
                    return -1;
                }
                return posicao;
            }
            else
            {
                return -1;
            }
        }

        public int getLinhaPlayer()
        {
            if (getClickPosition().X > 80 && getClickPosition().X < (tabuleiroJogador.getTamanhoTabuleiro() * 40 + 80)
                && getClickPosition().Y > 160 && getClickPosition().Y < (tabuleiroJogador.getTamanhoTabuleiro() * 40 + 160))
            {
                float posMatriz = (getClickPosition().Y - 160) / 40;
                int posicao = -1;
                
                String a = posMatriz.ToString();
                
                try
                {
                    posicao = Int32.Parse(a[0].ToString());
                }
                catch (Exception e)
                {
                    return -1;
                }
                return posicao;
            }
            else
            {
                return -1;
            }
        }

        
        public String getPosicaoBarco(int barco, bool orientacao, int x, int y)
        {

            return barco + "," + orientacao.ToString() + "," + x + "," + y;
        }

        
        public void getBarcoPlayer()
        {
            if (getClickPosition().X > (int)largura / 2 && getClickPosition().X < ((int)largura / 2 + 240)
                && getClickPosition().Y > 160 && getClickPosition().Y < 400 && tabuleiroJogador.getSetup().Equals(true))
            {
                if (getClickPosition().Y > 160 && getClickPosition().Y < 200
                    && getClickPosition().X > (int)largura / 2 && getClickPosition().X < (int)largura / 2 + 40
                    && controlador.getBarcosSelecionaveis()[0] > 0)
                {
                    tabuleiroJogador.setEmbarcacao(0); //Submarino
                }
                else if (getClickPosition().Y > 210 && getClickPosition().Y < 250
                    && getClickPosition().X > (int)largura / 2 && getClickPosition().X < (int)largura / 2 + 120
                    && controlador.getBarcosSelecionaveis()[1] > 0)
                {
                    tabuleiroJogador.setEmbarcacao(1); //Encouracado
                }
                else if (getClickPosition().Y > 260 && getClickPosition().Y < 300
                    && getClickPosition().X > (int)largura / 2 && getClickPosition().X < (int)largura / 2 + 120
                    && controlador.getBarcosSelecionaveis()[2] > 0)
                {
                    tabuleiroJogador.setEmbarcacao(2);//Encouracado1
                }
                else if (getClickPosition().Y > 310 && getClickPosition().Y < 350
                    && getClickPosition().X > (int)largura / 2 && getClickPosition().X < (int)largura / 2 + 160
                    && controlador.getBarcosSelecionaveis()[3] > 0)
                {
                    tabuleiroJogador.setEmbarcacao(3);//NavioDeGuerra
                }
                else if (getClickPosition().Y > 360 && getClickPosition().Y < 400
                    && getClickPosition().X > (int)largura / 2 && getClickPosition().X < (int)largura / 2 + 240
                    && controlador.getBarcosSelecionaveis()[4] > 0)
                {
                    tabuleiroJogador.setEmbarcacao(4); //PortaAvioes
                }
            }
            else
            {
                tabuleiroJogador.setEmbarcacao(-1);
            }
        }

        public void changeOrientacao()
        {
            if (getClickPosition().X > (int)largura / 2 && getClickPosition().X < ((int)largura / 2 + 134)
                && getClickPosition().Y > 410 && getClickPosition().Y < 432 && tabuleiroJogador.getSetup().Equals(true))
            {
                tabuleiroJogador.mudarOrientacao();
            }
        }

        private static void Janela_Closed(object sender, EventArgs e)
        {
            ((Window)sender).Close();
        }

    }
}