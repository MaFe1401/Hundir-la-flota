using System;
using System.Collections.Generic;
using System.Text;

namespace CasillaCode
{
    class Barco4
    {
        int vida = 4;//Vida del barco (casillas)
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
