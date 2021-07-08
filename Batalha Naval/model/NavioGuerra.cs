using System;
using System.Collections.Generic;
using System.Text;

namespace Batalha_Naval.model
{
    public class NavioGuerra :Peca
    {
        public NavioGuerra(bool orientacao)
          : base(orientacao)
        {
            //this.tamanho=4;
            this.setTamanho(4);
            //this.status = false;
            this.setFoiAtingido(false);
        }

    }
}
