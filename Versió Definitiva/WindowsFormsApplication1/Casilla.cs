using System;
using System.Collections.Generic;
using System.Text;

namespace CasillaCode
{
    public enum Propietario
    {
        nadie,//la casilla está próxima a un barco
        barco2,//La casilla ES del barco
        barco3,
        barco4,
        barco5,
        vacia//La casilla no está proxima a un barco ni ocupada por un barco
    }
    public enum CellState
    {
        __water,        //Si la celda es agua
        __boat,         //Si la celda es barco
        __floaded       //Si la celda ha sido hundida
    }

    public enum CheckedStatus
    {
        __unchecked,    //La casilla del rival no ha sido atacada aun
        __checked       //La casilla del rival ya ha sido atacada
    }

    class Casilla
    {
        private CellState state = new CellState();
        private CheckedStatus checkstatus = new CheckedStatus();
        private Propietario owner = new Propietario();
        private int coord_x, coord_y;
        
        public Casilla(int coord_x, int coord_y)
        {
            this.state = CellState.__water;                 //Por defecto las casillas son agua
            this.checkstatus = CheckedStatus.__unchecked;   //Por defecto las casillas estan unchecked
            this.owner = Propietario.vacia;                 //Por defecto estan vacias(sin propietario)
            //Coords
            this.coord_x = coord_x;
            this.coord_y = coord_y;
        }
        public void SetPropietario(string owner)//Segun la string que reciba como parámetro asigna propietario
        {
            if (owner == "barco2")
            {
                this.owner = Propietario.barco2;
            }
            else if (owner == "barco3")
            {
                this.owner = Propietario.barco3;
            }
            else if (owner == "barco4")
            {
                this.owner = Propietario.barco4;
            }
            else if (owner == "barco5")
            {
                this.owner = Propietario.barco5;
            }
            else if (owner == "nadie")
                this.owner = Propietario.nadie;
            else this.owner = Propietario.vacia;
        }
        public Propietario GetPropietario()//Retorna el propietario
        {
            return owner;
        }

       
        public void SetState(string state)//Establece el estado segun el string que recibe como parámetro
        {
            switch (state)
            {
                case "__water__":
                    this.state = CellState.__water;      //Se vuelve agua
                    break;
                case "__boat__":
                    this.state = CellState.__boat;       //Se vuelve barco
                    break;
                case "__floaded__":
                    this.state = CellState.__floaded;    //Se vuelve "hundida"
                    break;
                default:
                    this.state = CellState.__water;      //Por defecto son agua
                    break;
            }
        }

        //Retorna el estado de la celda
        public string GetState()
        {
            if (this.state == CellState.__water)        //Si es agua retorna water
                return "__water__";
            else if (this.state == CellState.__boat)    //Si es barco retorna boat
                return "__boat__";
            else if (this.state == CellState.__floaded) //Si está hundida, retorna floaded
                return "__floaded__";
            else
                return null;
        }

        //Saber si una casilla ha sido atacada
        public bool IsItChecked()
        {
            if (checkstatus == CheckedStatus.__checked) //Si ha sido atacada retorna false
                return false;
            else
                return true;                            //Si no ha sido atacada, retorna true
        }

        //Checkea la celda
        public void CheckCell()
        {
            this.checkstatus = CheckedStatus.__checked;
        }
    }
}
