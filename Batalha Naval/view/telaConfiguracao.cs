using System;
using System.Collections.Generic;
using System.Text;
using SFML;
using SFML.Graphics;
using SFML.Window;


namespace Batalha_Naval.view
{
    class TelaConfiguracao
    {
        private TelaInicial tela;
        RenderWindow window;
        Texture bgTexture;
        Sprite bgSprite;

        public TelaConfiguracao()
        {
            this.window = new RenderWindow(new VideoMode(VideoMode.DesktopMode.Width, VideoMode.DesktopMode.Height), "Batalha Naval", Styles.Fullscreen);
            this.window.Closed += windowClosed;
            this.window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            this.bgTexture = new Texture("D:/UFAPE/PLP/Batalha-Naval/Batalha Naval/images/telaInicial.jpg");       
            this.bgSprite = new Sprite(bgTexture);
            //Codigo para redimensionar a Imagem através da Sprite.Scale
            float ScaleX = (float)VideoMode.DesktopMode.Width / bgTexture.Size.X;
            float ScaleY = (float)VideoMode.DesktopMode.Height / bgTexture.Size.Y;
            bgSprite.Scale = new SFML.System.Vector2f(ScaleX, ScaleY);
        }
        public void redenrizar()
        {
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.White);
                window.Draw(bgSprite);
                window.Display();                           
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
                case Keyboard.Key.Escape:
                    tela = new TelaInicial();
                    tela.redenrizar();
                    window.Close();
                    break;              
            }
        }
    }
}
