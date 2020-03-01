using System;
using System.Collections.Generic;
using System.Text;

namespace CasillaCode
{
    class Barco3
    {
        int vida = 3;//Vida del barco (casillas)

        public int GetVida()//Retorna la vida del barco
        {
            return vida;
        }
        public void RestarVida()//Resta vida al barco
        {
            this.vida--;
        }

    }
}
