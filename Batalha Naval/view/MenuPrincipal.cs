using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Batalha_Naval.view
{
    class MenuPrincipal
    {
        public const int NUMERO_MAXIMO_DE_ITENS = 3;

        private int selecionado;
        private Font fonte;
        private Text[] item = new Text[NUMERO_MAXIMO_DE_ITENS];

        public MenuPrincipal(float width, float height)
        {
            this.fonte = new Font("Font/arial.ttf");
         
            this.item[0] = new Text("Jogar", fonte);
            this.item[0].Color = Color.Green;
            this.item[0].Position = new Vector2f(width / 5, height / (NUMERO_MAXIMO_DE_ITENS + 1) * 1);

            this.item[1] = new Text(" ", fonte);
            this.item[1].Color = Color.Blue;
            this.item[1].Position = new Vector2f(width / 5, height / (NUMERO_MAXIMO_DE_ITENS + 1) * 2);

            this.item[2] = new Text("Sair", fonte);
            this.item[2].Color = Color.Blue;
            this.item[2].Position = new Vector2f(width / 5, height / (NUMERO_MAXIMO_DE_ITENS + 1) * 3);

            selecionado = 0;
        }

        public void criar(RenderWindow window)
        {
            for(int i = 0; i < NUMERO_MAXIMO_DE_ITENS; i++)
            {
                window.Draw(item[i]);
            }
        }

        public void moveCima()
        {
            if(selecionado - 1 >= 0)
            {
                item[selecionado].Color = Color.Blue;
                selecionado--;
                item[selecionado].Color = Color.Green;
            }
        }

        public void moverBaixo()
        {
            if (selecionado + 1 < NUMERO_MAXIMO_DE_ITENS)
            {               
                item[selecionado].Color = Color.Blue;
                selecionado++;
                item[selecionado].Color = Color.Green;
            }
        }
        
        public int getClick()
        {
            return selecionado;
        }
    }
}
