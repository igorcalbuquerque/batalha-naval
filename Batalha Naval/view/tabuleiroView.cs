using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;
using Batalha_Naval.model;

namespace Batalha_Naval.view
{
    public class tabuleiroView
    {        

        Tabuleiro tabuleiro = new Tabuleiro();
        private int tamanhoTabuleiro;
        private int embarcacao = -1;
        private bool setup = true;
        private bool orientacao = true;
        /*true => horizontal false => vertical*/

        public Texture aguaTextura = new Texture("Assets/quadrado.png");
        public Texture submarinoTextura = new Texture("Assets/submarino.png");
        public Texture encouracadoTextura = new Texture("Assets/encouracado.png");
        public Texture navioGuerraTextura = new Texture("Assets/navioguerra.png");
        public Texture portaAvioesTextura = new Texture("Assets/portaavioes.png");
        public Texture tiroNaAguaTextura = new Texture("Assets/tironaagua.png");
        public Texture tiroNoBarcoTextura = new Texture("Assets/tironobarco.png");
        
        Font arial = new Font("Font/arial.ttf");

        public void desenharTabuleiroJogador(RenderWindow janela, int posX, int posY)
        {
            for (int i = 0; i < tabuleiro.getTabuleiroTamanho(); i++)
            {                
                char caracter = Convert.ToChar('A' + i);
                Text letrasColuna = new Text(caracter.ToString(), arial);
                letrasColuna.Position = new SFML.System.Vector2f((posX + 10) + i * 40, posY-40);
                letrasColuna.Color = Color.Red;
                janela.Draw(letrasColuna);
                for (int j = 0; j < tabuleiro.getTabuleiroTamanho(); j++)
                {
                    Text numerosLinha = new Text((j+1).ToString(), arial);
                    numerosLinha.Position = new SFML.System.Vector2f(posX - 40, (posY) + j * 40);
                    numerosLinha.Color = Color.Red;
                    janela.Draw(numerosLinha);
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(Agua));
                    {
                        Sprite agua = new Sprite(aguaTextura, new IntRect(0, 0, 40, 40));
                        agua.Position = new SFML.System.Vector2f(posX + i * 40, posY + j * 40);
                        janela.Draw(agua);
                    }

                    //TiroNaAgua 1x1
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(TiroAgua) && tabuleiro.getPecas()[i, j].getOrientacao() == true)
                    {
                        Sprite tiroNaAgua = new Sprite(tiroNaAguaTextura, new IntRect(0, 0, 40, 40));
                        tiroNaAgua.Position = new SFML.System.Vector2f(posX + i * 40, posY + j * 40);
                        janela.Draw(tiroNaAgua);
                    }

                    //TiroNoBarco 1x1
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(TiroEmbarcacao) && tabuleiro.getPecas()[i, j].getOrientacao() == true)
                    {
                        Sprite tiroNaEmbarcacao = new Sprite(tiroNoBarcoTextura, new IntRect(0, 0, 40, 40));
                        tiroNaEmbarcacao.Position = new SFML.System.Vector2f(posX + i * 40, posY + j * 40);
                        janela.Draw(tiroNaEmbarcacao);
                    }

                    //Submarino 1x1
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(Submarino) && tabuleiro.getPecas()[i,j].getOrientacao() == true)
                    {
                        Sprite submarino = new Sprite(submarinoTextura, new IntRect(0, 0, 40, 40));
                        submarino.Position = new SFML.System.Vector2f(posX + i * 40, posY + j * 40);
                        janela.Draw(submarino);
                    } else if(tabuleiro.getPecas()[i, j].GetType() == typeof(Submarino) && tabuleiro.getPecas()[i, j].getOrientacao() == false)
                    {
                        Sprite submarinoSpt = new Sprite(submarinoTextura, new IntRect(0, 0, 40, 40));
                        submarinoSpt.Position = new SFML.System.Vector2f(posX + i * 40 + 40, posY + j * 40);
                        submarinoSpt.Rotation = 90;
                        janela.Draw(submarinoSpt);
                    }                    

                    //Encouraçado 1x3                    
                    if (tabuleiro.getPecas()[i,j].GetType() == typeof(Encouracado) && tabuleiro.getPecas()[i, j].getOrientacao() == true)
                    {
                        Sprite encouracado = new Sprite(encouracadoTextura, new IntRect(0, 0, 120, 40));
                        encouracado.Position = new SFML.System.Vector2f(posX + tabuleiro.getPecas()[i,j].getXInicial() * 40, posY + j * 40);
                        janela.Draw(encouracado);

                    } else if(tabuleiro.getPecas()[i, j].GetType() == typeof(Encouracado) && tabuleiro.getPecas()[i, j].getOrientacao() == false)
                    {                      
                        Sprite encouracadoSpt = new Sprite(encouracadoTextura, new IntRect(0, 0, 120, 40));
                        encouracadoSpt.Position = new SFML.System.Vector2f(posX + tabuleiro.getPecas()[i, j].getXInicial() * 40 + 40, posY + tabuleiro.getPecas()[i, j].getYInicial() * 40);
                        encouracadoSpt.Rotation = 90;
                        janela.Draw(encouracadoSpt);                        
                    }

                    //Navio de Guerra
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(NavioGuerra) && tabuleiro.getPecas()[i, j].getOrientacao() == true)
                    {                        
                        Sprite navioGuerra = new Sprite(navioGuerraTextura, new IntRect(0, 0, 160, 40));
                        navioGuerra.Position = new SFML.System.Vector2f(posX + tabuleiro.getPecas()[i, j].getXInicial() * 40, posY + j * 40);
                        janela.Draw(navioGuerra);                        
                    }
                    else if (tabuleiro.getPecas()[i, j].GetType() == typeof(NavioGuerra) && tabuleiro.getPecas()[i, j].getOrientacao() == false)
                    {                        
                        Sprite navioGuerraSpt = new Sprite(navioGuerraTextura, new IntRect(0, 0, 160, 40));
                        navioGuerraSpt.Position = new SFML.System.Vector2f(posX + tabuleiro.getPecas()[i, j].getXInicial() * 40 + 40, posY + tabuleiro.getPecas()[i, j].getYInicial() * 40);
                        navioGuerraSpt.Rotation = 90;
                        janela.Draw(navioGuerraSpt);                        
                    }

                    //Porta Aviões
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(PortaAviao) && tabuleiro.getPecas()[i, j].getOrientacao() == true)
                    {
                        Sprite portaAvioes = new Sprite(portaAvioesTextura, new IntRect(0, 0, 240, 40));
                        portaAvioes.Position = new SFML.System.Vector2f(posX + tabuleiro.getPecas()[i, j].getXInicial() * 40, posY + j * 40);
                        janela.Draw(portaAvioes);                            
                    }
                    else if (tabuleiro.getPecas()[i, j].GetType() == typeof(PortaAviao) && tabuleiro.getPecas()[i, j].getOrientacao() == false)
                    {                           
                        Sprite portaAvioesSpt = new Sprite(portaAvioesTextura, new IntRect(0, 0, 240, 40));
                        portaAvioesSpt.Position = new SFML.System.Vector2f(posX + tabuleiro.getPecas()[i, j].getXInicial() * 40 + 40, posY + tabuleiro.getPecas()[i, j].getYInicial() * 40);
                        portaAvioesSpt.Rotation = 90;
                        janela.Draw(portaAvioesSpt);                    
                    }                    
                }
            }                    
        }

        public void desenharTabuleiroComputador(RenderWindow janela, int posX, int posY)
        {
            for (int i = 0; i < tabuleiro.getTabuleiroTamanho(); i++)
            {
                char caracter = Convert.ToChar('A' + i);
                Text letraColuna = new Text(caracter.ToString(), arial);
                letraColuna.Position = new SFML.System.Vector2f((posX + 10) + i * 40, posY - 40);
                letraColuna.Color = Color.Red;
                janela.Draw(letraColuna);
                for (int j = 0; j < tabuleiro.getTabuleiroTamanho(); j++)
                {
                    Text numeroLinha = new Text((j + 1).ToString(), arial);
                    numeroLinha.Position = new SFML.System.Vector2f(posX - 40, (posY) + j * 40);
                    numeroLinha.Color = Color.Red;
                    janela.Draw(numeroLinha);
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(Agua)) ;
                    {
                        Sprite aguaSprite = new Sprite(aguaTextura, new IntRect(0, 0, 40, 40));
                        aguaSprite.Position = new SFML.System.Vector2f(posX + i * 40, posY + j * 40);
                        janela.Draw(aguaSprite);
                    }

                    //TiroNaAgua 1x1
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(TiroAgua) && tabuleiro.getPecas()[i, j].getOrientacao() == true)
                    {
                        Sprite tiroNaAguaSprite = new Sprite(tiroNaAguaTextura, new IntRect(0, 0, 40, 40));
                        tiroNaAguaSprite.Position = new SFML.System.Vector2f(posX + i * 40, posY + j * 40);
                        janela.Draw(tiroNaAguaSprite);
                    }

                    //TiroNoBarco 1x1
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(TiroEmbarcacao) && tabuleiro.getPecas()[i, j].getOrientacao() == true)
                    {
                        Sprite tiroNoBarcoSprite = new Sprite(tiroNoBarcoTextura, new IntRect(0, 0, 40, 40));
                        tiroNoBarcoSprite.Position = new SFML.System.Vector2f(posX + i * 40, posY + j * 40);
                        janela.Draw(tiroNoBarcoSprite);
                    }

                    //Submarino 1x1
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(Submarino) && tabuleiro.getPecas()[i, j].getOrientacao() == true
                        && tabuleiro.getPecas()[i, j].getFoiAtingido().Equals(true))
                    {
                        Sprite submarinoSprite = new Sprite(submarinoTextura, new IntRect(0, 0, 40, 40));
                        submarinoSprite.Position = new SFML.System.Vector2f(posX + i * 40, posY + j * 40);
                        janela.Draw(submarinoSprite);
                    }
                    else if (tabuleiro.getPecas()[i, j].GetType() == typeof(Submarino) && tabuleiro.getPecas()[i, j].getOrientacao() == false
                        && tabuleiro.getPecas()[i, j].getFoiAtingido().Equals(true))
                    {
                        Sprite submarinoSprite = new Sprite(submarinoTextura, new IntRect(0, 0, 40, 40));
                        submarinoSprite.Position = new SFML.System.Vector2f(posX + i * 40 + 40, posY + j * 40);
                        submarinoSprite.Rotation = 90;
                        janela.Draw(submarinoSprite);
                    }
                    //Encouraçado 1x3                    
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(Encouracado) && tabuleiro.getPecas()[i, j].getOrientacao() == true
                        && tabuleiro.getPecas()[i, j].getFoiAtingido().Equals(true))
                    {
                        Sprite encouracadoSprite = new Sprite(encouracadoTextura, new IntRect(0, 0, 120, 40));
                        encouracadoSprite.Position = new SFML.System.Vector2f(posX + tabuleiro.getPecas()[i, j].getXInicial() * 40, posY + j * 40);
                        janela.Draw(encouracadoSprite);

                    }
                    else if (tabuleiro.getPecas()[i, j].GetType() == typeof(Encouracado) && tabuleiro.getPecas()[i, j].getOrientacao() == false
                        && tabuleiro.getPecas()[i, j].getFoiAtingido().Equals(true))
                    {
                        Sprite encouracadoSprite = new Sprite(encouracadoTextura, new IntRect(0, 0, 120, 40));
                        encouracadoSprite.Position = new SFML.System.Vector2f(posX + tabuleiro.getPecas()[i, j].getXInicial() * 40 + 40, posY + tabuleiro.getPecas()[i, j].getYInicial() * 40);
                        encouracadoSprite.Rotation = 90;
                        janela.Draw(encouracadoSprite);
                    }

                    //Navio de Guerra
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(NavioGuerra) && tabuleiro.getPecas()[i, j].getOrientacao() == true
                        && tabuleiro.getPecas()[i, j].getFoiAtingido().Equals(true))
                    {
                        Sprite navioGuerraSprite = new Sprite(navioGuerraTextura, new IntRect(0, 0, 160, 40));
                        navioGuerraSprite.Position = new SFML.System.Vector2f(posX + tabuleiro.getPecas()[i, j].getXInicial() * 40, posY + j * 40);
                        janela.Draw(navioGuerraSprite);
                    }
                    else if (tabuleiro.getPecas()[i, j].GetType() == typeof(NavioGuerra) && tabuleiro.getPecas()[i, j].getOrientacao() == false
                        && tabuleiro.getPecas()[i, j].getFoiAtingido().Equals(true))
                    {
                        Sprite navioGuerraSprite = new Sprite(navioGuerraTextura, new IntRect(0, 0, 160, 40));
                        navioGuerraSprite.Position = new SFML.System.Vector2f(posX + tabuleiro.getPecas()[i, j].getXInicial() * 40 + 40, posY + tabuleiro.getPecas()[i, j].getYInicial() * 40);
                        navioGuerraSprite.Rotation = 90;
                        janela.Draw(navioGuerraSprite);
                    }

                    //Porta Aviões
                    if (tabuleiro.getPecas()[i, j].GetType() == typeof(PortaAviao) && tabuleiro.getPecas()[i, j].getOrientacao() == true
                        && tabuleiro.getPecas()[i, j].getFoiAtingido().Equals(true))
                    {
                        Sprite portaAvioesSprite = new Sprite(portaAvioesTextura, new IntRect(0, 0, 240, 40));
                        portaAvioesSprite.Position = new SFML.System.Vector2f(posX + tabuleiro.getPecas()[i, j].getXInicial() * 40, posY + j * 40);
                        janela.Draw(portaAvioesSprite);
                    }
                    else if (tabuleiro.getPecas()[i, j].GetType() == typeof(PortaAviao) && tabuleiro.getPecas()[i, j].getOrientacao() == false
                        && tabuleiro.getPecas()[i, j].getFoiAtingido().Equals(true))
                    {
                        Sprite portaAvioesSprite = new Sprite(portaAvioesTextura, new IntRect(0, 0, 240, 40));
                        portaAvioesSprite.Position = new SFML.System.Vector2f(posX + tabuleiro.getPecas()[i, j].getXInicial() * 40 + 40, posY + tabuleiro.getPecas()[i, j].getYInicial() * 40);
                        portaAvioesSprite.Rotation = 90;
                        janela.Draw(portaAvioesSprite);

                    }
                }
            }
        }

        public void desenharBarraBarcos(RenderWindow janela, int posX, int posY)
        {
            Sprite submarinoSprite = new Sprite(submarinoTextura, new IntRect(0, 0, 40, 40));
            submarinoSprite.Position = new SFML.System.Vector2f(posX, posY);
            janela.Draw(submarinoSprite);

            Sprite encouracadoSprite = new Sprite(encouracadoTextura, new IntRect(0, 0, 120, 40));
            encouracadoSprite.Position = new SFML.System.Vector2f(posX, posY + 50);
            janela.Draw(encouracadoSprite);

            Sprite encouracado1Sprite = new Sprite(navioGuerraTextura, new IntRect(0, 0, 120, 40));
            encouracadoSprite.Position = new SFML.System.Vector2f(posX, posY + 100);
            janela.Draw(encouracadoSprite);

            Sprite navioGuerraSprite = new Sprite(navioGuerraTextura, new IntRect(0, 0, 160, 40));
            navioGuerraSprite.Position = new SFML.System.Vector2f(posX, posY + 150);
            janela.Draw(navioGuerraSprite);

            Sprite portaAvioesSprite = new Sprite(portaAvioesTextura, new IntRect(0, 0, 240, 40));
            portaAvioesSprite.Position = new SFML.System.Vector2f(posX, posY + 200);
            janela.Draw(portaAvioesSprite);

            Text orientacao = new Text("Horizontal", arial);
            if (this.orientacao.Equals(true))
            {
                orientacao = new Text("Horizontal", arial);
            } else
            {
                orientacao = new Text("Vertical", arial);
            }
            
            orientacao.Position = new SFML.System.Vector2f(posX, posY + 250);
            orientacao.Color = Color.Red;
            janela.Draw(orientacao);

        }

        public bool getSetup()
        {
            return this.setup;
        }

        public void changeSetup()
        {
            this.setup = !(setup);
        }

        public int getTamanhoTabuleiro()
        {
            return this.tamanhoTabuleiro = tabuleiro.getTabuleiroTamanho();
        }

        public void mudarOrientacao()
        {
            this.orientacao = !(orientacao);
        }

        public bool getOrientacao()
        {
            return this.orientacao;
        }

        public Tabuleiro getTabuleiro()
        {
            return this.tabuleiro;
        }

        public void setTabuleiro(Tabuleiro tab)
        {
            this.tabuleiro = tab;
        }

        public void setEmbarcacao(int barco)
        {
            this.embarcacao = barco;
        }
        public int getEmbarcacao()
        {
            return this.embarcacao;
        }
    }
}
