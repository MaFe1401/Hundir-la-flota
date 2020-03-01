using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    internal enum estado//Estados de la partida
    {
        Preparacion,//Colocando barcos
        Listo,      //No es tu turno
        Jugando     //Es tu turno
    }

    class PartidaManager
    {
        estado state = new estado();
        int barcosjugador=0;//Marcador
        int barcosrival = 0;
        public PartidaManager()
        {
            this.state = estado.Preparacion; //Por defecto el estado es Preparacion
        }
        public int GetBarcosJugador()//Retorna el barcos tirados por el usuario
        {
            return barcosjugador;
        }
        public void SumarBarcoaJugador()//Suma barco tirado por usuario
        {
            barcosjugador++;
        }
        public int GetBarcosRival()//Retorna barcos tirados por rival
        {
            return barcosrival;
        }
        public void SumarBarcoaRival()//Suma barco tirado por rival 
        {
            barcosrival++;
        }
        public void SetState(string s)//Establece el estado de la partida segun el string que recibe como parámetro
        {
            switch (s)
            {
                case ("preparacion"):
                    this.state = estado.Preparacion;
                    break;
                case ("listo"):
                    this.state = estado.Listo;
                    break;
                default:
                    this.state = estado.Jugando;
                    break;
            }
        }
      
        public estado GetState()//Retorna el estado de la partida
        {
            return this.state;
        }
    }
}
