using System;
using System.Collections.Generic;
using System.Text;

namespace Batalha_Naval.model
{
    class TiroAgua : Peca
    {
        public TiroAgua(bool orientacao) : base(orientacao)
        {
            this.setTamanho(1);
            this.setFoiAtingido(true);
        }
    }
}
