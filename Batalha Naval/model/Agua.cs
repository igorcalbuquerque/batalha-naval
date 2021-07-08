using System;
using System.Collections.Generic;
using System.Text;

namespace Batalha_Naval.model
{
    public class Agua : Peca
    {
        public Agua(bool orientacao)
            :base(orientacao)
        {
            setTamanho(1);
            setFoiAtingido(false);
        }
       

    }

}
