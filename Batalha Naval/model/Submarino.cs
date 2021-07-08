using System;
using System.Collections.Generic;
using System.Text;

namespace Batalha_Naval.model
{
   public class Submarino :Peca
    {
        public Submarino(Boolean orientacao)
         : base(orientacao)
        {            
            setTamanho(1);
            setFoiAtingido(false);
        }


    }

}
