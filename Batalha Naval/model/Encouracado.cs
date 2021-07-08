using System;
using System.Collections.Generic;
using System.Text;

namespace Batalha_Naval.model
{
    public class Encouracado :Peca
    {
        public Encouracado(bool orientacao)
            : base(orientacao)
        {
            setTamanho(3);
            setFoiAtingido(false);
        }


    }

}
