using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;


namespace Batalha_Naval.view
{
    class TelaInicial
    {
        private Interface jogo;
        private TelaConfiguracao configuracao;
        RenderWindow renderwindow;
        MenuPrincipal menu;
        Texture texture;
        Sprite sprite;

        public TelaInicial()
        {
            this.renderwindow = new RenderWindow(new VideoMode(VideoMode.DesktopMode.Width, VideoMode.DesktopMode.Height), "Batalha Naval");
            this.renderwindow.Closed += windowClosed;
            this.renderwindow.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            this.texture = new Texture("D:/UFAPE/PLP/Batalha-Naval/Batalha Naval/images/marinha.jpg");       
            this.sprite = new Sprite(texture);
            //Codigo para redimensionar a Imagem através da Sprite.Scale
            float ScaleX = (float)VideoMode.DesktopMode.Width / texture.Size.X;
            float ScaleY = (float)VideoMode.DesktopMode.Height / texture.Size.Y;
            sprite.Scale = new SFML.System.Vector2f(ScaleX, ScaleY);

            this.menu = new MenuPrincipal(renderwindow.Size.X, renderwindow.Size.Y);
        }
        public void redenrizar()
        {
            while (renderwindow.IsOpen)
            {
                renderwindow.DispatchEvents();
                renderwindow.Clear(Color.White);
                renderwindow.Draw(sprite);
                menu.criar(renderwindow);
                renderwindow.Display();                           
            }

        }
       private void windowClosed(object sender, EventArgs e)
        {
            ((Window)sender).Close();
        }

        private void OnKeyPressed(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;
            switch(e.Code)
            {
                case Keyboard.Key.Up:
                    menu.moveCima();
                    break;
                case Keyboard.Key.Down:
                    menu.moverBaixo();
                    break;
                case Keyboard.Key.Return:
                    switch (menu.getClick())
                    {
                        case 0:
                            jogo = new Interface();
                            window.Close();
                            jogo.Partida();                                                                                  
                            break;
                        case 1:
                            configuracao = new TelaConfiguracao();
                            configuracao.redenrizar();
                            window.Close();
                            break;
                        case 2:
                            window.Close();
                            break;

                    }                    
                    break;
            }
        }
    }
}
