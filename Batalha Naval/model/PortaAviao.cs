using System;
using System.Collections.Generic;
using System.Text;

namespace Batalha_Naval.model
{
    public class PortaAviao : Peca
    {
        public PortaAviao(bool orientacao)
           : base(orientacao)
        {
            setTamanho(6);
            setFoiAtingido(false);
        }
    }
}
