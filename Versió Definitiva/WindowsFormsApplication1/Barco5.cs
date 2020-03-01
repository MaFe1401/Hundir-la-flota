using System;
using System.Collections.Generic;
using System.Text;

namespace CasillaCode
{
    class Barco5
    {
        int vida = 5;//Vida del barco
        public int GetVida()//Retorna vida del barco
        {
            return vida;
        }
        public void RestarVida()//Resta vida al barco
        {
            this.vida--;
        }

    }
}
