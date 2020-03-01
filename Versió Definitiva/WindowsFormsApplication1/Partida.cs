using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CasillaCode;
using System.Media;


namespace WindowsFormsApplication1
{
    public partial class Partida : Form
    {
        Casilla[,] MatrizCasillaUser = new Casilla[10, 10];     //Matriz de casillas para el usuario
        Casilla[,] MatrizCasillaEnemy = new Casilla[10, 10];    //Matriz de casillas para el enemigo
        PartidaManager p = new PartidaManager();                //Partida Manager (Estados, etc.)
        Connectivity server;                                    //Server/Socket.
        delegate void delegate_write_lbl(string text);          //delegado para escribir en labels
        delegate void efectos_especiales(string quien, int x, int y);//delegado para colocar fuego, agua
        delegate void Disable();
        bool cerrar = false;
        List<PictureBox> pb = new List<PictureBox>();           //Lista de PictureBox para imagenes
        int cont2 = 0, cont3 = 0, cont4 = 0, cont5 = 0;         //barcos colocados
        Barco2 barco2;                                           //objetos barco
        Barco3 barco3;
        Barco4 barco4;
        Barco5 barco5;
        bool hundido2 = false, hundido3 = false, hundido4 = false, hundido5 = false;//han sido hundidos?
        bool SoyInvitado; //Soy el invitado?
        bool colocados = false;//han sido colocados?
        int herecibidomoneda = 0;//he recibido el resultado de la moneda del primer turno?
        int moneda;//resultado moneda
        string user;//quien soy?
        public void SetUser(string usuario)//Establecer user(quien soy)
        {
            user = usuario;
        }
        public void SetSoyInvitado(bool t)//establecer si soy invitado o no
        {
            if (t == true)
                SoyInvitado = true;
            else SoyInvitado = false;
        }
        public Partida(Connectivity server)
        {
            InitializeComponent();
            this.server = server;

        }
        public void SetFire(string quien, int x, int y)//Colocar picturebox fuego.Se coloca en el datagrid del usuario si recibe "jugador" como parámetro, si no, en la del rival
        {
            if (quien=="jugador")
            {
                dataGridJugador.CurrentCell = dataGridJugador.Rows[y].Cells[x];
                PictureBox q = new PictureBox();
                q.Image = Image.FromFile("fuego.png");
                q.Size = new Size(49, 49);
                q.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                q.Location = new Point(y * 51, x * 51);
                dataGridJugador.Controls.Add(q);
                pb.Add(q);
            }
            else
            {
                dataGridRival.CurrentCell = dataGridRival.Rows[y].Cells[x];
                PictureBox q = new PictureBox();
                q.Image = Image.FromFile("fuego.png");
                q.Size = new Size(49, 49);
                q.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                q.Location = new Point(y * 51, x * 51);
                dataGridRival.Controls.Add(q);
                pb.Add(q);
            }
           
        }
        public void Agua(string quien, int x, int y)//Colocar picturebox agua.Se coloca en el datagrid del usuario si recibe "jugador" como parámetro, si no, en la del rival
        {
            if(quien=="jugador")
            {
                dataGridJugador.CurrentCell = dataGridJugador.Rows[y].Cells[x];
                PictureBox q = new PictureBox();
                q.Image = Image.FromFile("water.jpg");
                q.Size = new Size(49, 49);
                q.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                q.Location = new Point(y * 51, x * 51);
                dataGridJugador.Controls.Add(q);
                pb.Add(q);
            }
            else
            {
                dataGridRival.CurrentCell = dataGridRival.Rows[y].Cells[x];
                PictureBox q = new PictureBox();
                q.Image = Image.FromFile("water.jpg");
                q.Size = new Size(49, 49);
                q.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                q.Location = new Point(y * 51, x * 51);
                dataGridRival.Controls.Add(q);
                pb.Add(q);
            }
           
        }
        public void Caso16(string msg)//Se ejecuta si form1 recibe 16/x y. Si el estado de la casilla es "boat", busca el propietario, resta vida y coloca fuego. Envia 18/2 si le hundió alguno, 18/1 si le tocó, o 18/0 si agua (o si es boat y no pertenece a nadie(casillas azules))
        {
            string[] coord = msg.Split(' ');
            int x = Convert.ToInt32(coord[0]);
            int y = Convert.ToInt32(coord[1]);

            if (MatrizCasillaUser[x, y].GetState() == "__boat__")
            {
                if (MatrizCasillaUser[x, y].GetPropietario() == Propietario.barco2)
                {
                    barco2.RestarVida();
                    if (barco2.GetVida() == 0)
                        hundido2 = true;
                    efectos_especiales fuego = new efectos_especiales(SetFire);
                    dataGridJugador.Invoke(fuego, new object[] { "jugador", x, y });
                    SonidoExplosion();
                }
                else if (MatrizCasillaUser[x, y].GetPropietario() == Propietario.barco3)
                {
                    barco3.RestarVida();
                    if (barco3.GetVida() == 0)
                        hundido3 = true;
                    efectos_especiales fuego = new efectos_especiales(SetFire);
                    dataGridJugador.Invoke(fuego, new object[] { "jugador", x, y });
                    SonidoExplosion();
                }
                else if (MatrizCasillaUser[x, y].GetPropietario() == Propietario.barco4)
                {
                    barco4.RestarVida();
                    if (barco4.GetVida() == 0)
                        hundido4 = true;
                    efectos_especiales fuego = new efectos_especiales(SetFire);
                    dataGridJugador.Invoke(fuego, new object[] { "jugador", x, y });
                    SonidoExplosion();
                }
                else if (MatrizCasillaUser[x, y].GetPropietario() == Propietario.barco5)
                { 
                    barco5.RestarVida();
                    if (barco5.GetVida() == 0)
                        hundido5 = true;
                    efectos_especiales fuego = new efectos_especiales(SetFire);
                    dataGridJugador.Invoke(fuego, new object[] { "jugador", x, y });
                    SonidoExplosion();
                }
               else
                {
                    efectos_especiales agua = new efectos_especiales(Agua);
                    dataGridJugador.Invoke(agua, new object[] { "jugador", x, y });
                    SonidoSplash();
                }
                if (hundido2)
                {
                    delegate_write_lbl del1 = new delegate_write_lbl(EscribirLabel3);
                    label3.Invoke(del1, new object[] { "¡TU BARCO HA SIDO HUNDIDO!" });
                    p.SumarBarcoaRival();//Para llevar la cuenta del marcador
                    server.SendToServer(18, "2");
                    hundido2 = false;
                }
                else if (hundido3)
                {
                    delegate_write_lbl del1 = new delegate_write_lbl(EscribirLabel3);
                    label3.Invoke(del1, new object[] { "¡TU BARCO HA SIDO HUNDIDO!" });
                    p.SumarBarcoaRival();
                    server.SendToServer(18, "2");
                    hundido3 = false;
                }
                else if (hundido4)
                {
                    delegate_write_lbl del1 = new delegate_write_lbl(EscribirLabel3);
                    label3.Invoke(del1, new object[] { "¡TU BARCO HA SIDO HUNDIDO!" });
                    p.SumarBarcoaRival();
                    server.SendToServer(18, "2");
                    hundido4 = false;
                }
                else if (hundido5)
                {
                    delegate_write_lbl del1 = new delegate_write_lbl(EscribirLabel3);
                    label3.Invoke(del1, new object[] { "¡TU BARCO HA SIDO HUNDIDO!" });
                    p.SumarBarcoaRival();
                    server.SendToServer(18, "2");
                    hundido5 = false;
                }
                else
                {
                    if((MatrizCasillaUser[x, y].GetPropietario() == Propietario.nadie)|| (MatrizCasillaUser[x, y].GetPropietario() == Propietario.vacia)) 
                      server.SendToServer(18, "0");
                    else server.SendToServer(18, "1");
                }
                if ((barco2.GetVida()==0)&&(barco3.GetVida()==0)&&(barco4.GetVida()==0)&&(barco5.GetVida()==0))
                {
                    cerrar = true;
                    MessageBox.Show("Has perdido...");//Si todos tus barcos tienen vida=0, has perdido.
                }
                p.SetState("jugando");
                delegate_write_lbl del = new delegate_write_lbl(EscribirLabel1);
                label1.Invoke(del, new object[] { "¡TU TURNO!" });
            }
            if (MatrizCasillaUser[x, y].GetState() == "__water__")
            {
                efectos_especiales agua = new efectos_especiales(Agua);
                dataGridJugador.Invoke(agua, new object[] { "jugador", x, y });
                SonidoSplash();
                server.SendToServer(18, "0");
                p.SetState("jugando");
                delegate_write_lbl del = new delegate_write_lbl(EscribirLabel1);
                label1.Invoke(del, new object[] { "¡TU TURNO!" });
            }

        }
        public void Caso17(int res)//Al recibir el resultado de la moneda. Si recibe el res y aun no ha colocado los barcos, almacena el resultado. Si los ha colocado actualiza el estado.
        {
            if (colocados==false)
            {
                if (res == 1)
                {
                    herecibidomoneda = 1;
                    moneda = 0;
                }
                else
                {
                    herecibidomoneda = 1;
                    moneda = 1;
                }
            }
           else
            {
                if (res == 1)
                {
                    p.SetState("listo");
                    delegate_write_lbl del = new delegate_write_lbl(EscribirLabel1);
                    label1.Invoke(del, new object[] { "¡LISTO!" });
                }
                else
                {
                    p.SetState("jugando");
                    delegate_write_lbl del = new delegate_write_lbl(EscribirLabel1);
                    label1.Invoke(del, new object[] { "¡TU TURNO!" });
                } 
            }
        }
        public void Caso18(int res)//Recibe 18/0 si tocó agua (coloca agua en datagrid rival), 18/1 si tocó barco (coloca fuego), 18/2 si tiró barco
        {
            server.SetCodigo();
            int ledí = Convert.ToInt32(res);
            if (ledí == 0)
            {
                efectos_especiales agua = new efectos_especiales(Agua);
                dataGridJugador.Invoke(agua, new object[] { "rival", dataGridRival.CurrentCell.RowIndex, dataGridRival.CurrentCell.ColumnIndex });
                SonidoSplash();
                MatrizCasillaEnemy[dataGridRival.CurrentCell.RowIndex, dataGridRival.CurrentCell.ColumnIndex].SetState("__water__");
                delegate_write_lbl del = new delegate_write_lbl(EscribirLabel3);
                label3.Invoke(del, new object[] { "Agua..." });
            }
            if (ledí == 1)
            {
                efectos_especiales fuego = new efectos_especiales(SetFire);
                dataGridRival.Invoke(fuego, new object[] { "rival", dataGridRival.CurrentCell.RowIndex, dataGridRival.CurrentCell.ColumnIndex });
                SonidoExplosion();
                MatrizCasillaEnemy[dataGridRival.CurrentCell.RowIndex, dataGridRival.CurrentCell.ColumnIndex].SetState("__floaded__");
                delegate_write_lbl del = new delegate_write_lbl(EscribirLabel3);
                label3.Invoke(del, new object[] { "¡Le has dado!" });
            }
            if (ledí == 2)
            {
                int casillashundidas = 0;
                efectos_especiales fuego = new efectos_especiales(SetFire);
                dataGridRival.Invoke(fuego, new object[] { "rival", dataGridRival.CurrentCell.RowIndex, dataGridRival.CurrentCell.ColumnIndex });
                SonidoExplosion();
                MatrizCasillaEnemy[dataGridRival.CurrentCell.RowIndex, dataGridRival.CurrentCell.ColumnIndex].SetState("__floaded__");
                delegate_write_lbl del = new delegate_write_lbl(EscribirLabel3);
                label3.Invoke(del, new object[] { "Has derribado un barco enemigo" });
                p.SumarBarcoaJugador();
                for (int xc = 0; xc < 10; xc++)//Comprueba cuantas casillas hundidas hay
                {
                    for (int yc = 0; yc < 10; yc++)
                    {
                        if (MatrizCasillaEnemy[xc, yc].GetState() == "__floaded__")
                            casillashundidas++;
                    }
                }
                for (int x =0; x<10;x++ )//Pinta de azul las casillas que rodean un barco derribado
                {
                    for(int y=0;y<10;y++)
                    {
                        if (MatrizCasillaEnemy[x, y].GetState() == "__floaded__")
                        {
                            if (dataGridRival.Rows[y].Cells[x].RowIndex+1<10)
                            {
                                if (MatrizCasillaEnemy[x , y+1].GetState() == "__water__")
                                    dataGridRival.Rows[y + 1].Cells[x].Style.BackColor = Color.DarkBlue;

                            }
                            if (dataGridRival.Rows[y].Cells[x].RowIndex - 1 >= 0)
                            {
                                if (MatrizCasillaEnemy[x , y - 1].GetState() == "__water__")
                                    dataGridRival.Rows[y - 1].Cells[x].Style.BackColor = Color.DarkBlue;

                            }
                            if (dataGridRival.Rows[y].Cells[x].ColumnIndex + 1 <10)
                            {
                                if (MatrizCasillaEnemy[x + 1, y].GetState() == "__water__")
                                    dataGridRival.Rows[y].Cells[x+1].Style.BackColor = Color.DarkBlue;

                            }
                            if (dataGridRival.Rows[y].Cells[x].ColumnIndex - 1 >= 0)
                            {
                                if (MatrizCasillaEnemy[x - 1, y].GetState() == "__water__")
                                    dataGridRival.Rows[y].Cells[x-1].Style.BackColor = Color.DarkBlue;

                            }

                        }
                    }
                }
                if (casillashundidas == 14)//Si hay 14 casillas hundidas, has ganado.
                {
                    int t = (Convert.ToInt32(mindec.Text) * 600) + (Convert.ToInt32(minunit.Text) * 60) + (Convert.ToInt32(segdec.Text) * 10) + Convert.ToInt32(segunits.Text);
                    server.SendToServer(19, p.GetBarcosJugador().ToString() + " " + p.GetBarcosRival().ToString() + " " + t.ToString());
                    MessageBox.Show("¡HAS GANADO!");
                    cerrar = true;
                    server.SendToServer(22, "0");

                }
            }
        }
        public void Caso20()//Si form1 recibe 20/ , se ejecuta esta función. Se desconecta del servidor para poder cerrar el form.
        {
            server.SendToServer(0, user);
            server.DisconnectServer();
        }
       public void Caso21()//Si recibes 21/ , tu rival se ha desconectado, has ganado. Solo el ganador envia estadísticas a la base de datos.
        {
            cerrar = true;
            clock_time.Stop();
            int tiempo = (Convert.ToInt32(mindec.Text) * 600) + (Convert.ToInt32(minunit.Text) * 60) + (Convert.ToInt32(segdec.Text) * 10) + Convert.ToInt32(segunits.Text);
            server.SendToServer(19, p.GetBarcosJugador().ToString() + " " + p.GetBarcosRival().ToString() + " " + tiempo.ToString());
            server.SendToServer(0, user);
            server.DisconnectServer();
            MessageBox.Show("¡Has ganado!... Tu rival se ha desconectado.");
        }
        public void Caso22()//Recibes 22/ al finalizar la partida
        {
            try
            {
                Disable dis = new Disable(DisableDatagridJugador);
                dataGridJugador.Invoke(dis, new object[] { });
                Disable d = new Disable(DisableDataGridRival);
                dataGridRival.Invoke(d, new object[] { });
                Disable di = new Disable(DisableEnviar);
                enviar.Invoke(di, new object[] { });
                Disable disa = new Disable(DisableMoneda);
                Moneda.Invoke(disa, new object[] { });
                Disable disab = new Disable(DisableRendirse);
                rendirseBtn.Invoke(disab, new object[] { });
            }
            catch { }
           
            server.SendToServer(0, user);
            server.DisconnectServer();
        }
        public void SonidoSplash ()//Hacer sonido de salpicadura
        {
            SoundPlayer player = new SoundPlayer("splash.wav");
            player.Play();
        }
        public void SonidoExplosion()//Hacer sonido de explosión
        {
            SoundPlayer player = new SoundPlayer("explosion.wav");
            player.Play();
        }

        
        private void Partida_Load(object sender, EventArgs e)
        {
            //DataGridView Initial Config.
            dataGridJugador.ColumnCount = 10;
            dataGridJugador.RowCount = 10;
            dataGridRival.ColumnCount = 10;
            dataGridRival.RowCount = 10;
            for (int i = 0; i < 10; i++)
            {
                DataGridViewRow row = dataGridJugador.Rows[i];
                row.Height = 50;
                DataGridViewRow r = dataGridRival.Rows[i];
                r.Height = 50;
                DataGridViewColumn column = dataGridJugador.Columns[i];
                column.Width = 50;
                DataGridViewColumn c = dataGridRival.Columns[i];
                c.Width = 50;
            }
            dataGridJugador.AutoSize = true;
            dataGridRival.AutoSize = true;

            //Matrices Initial Config.
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                {
                    MatrizCasillaEnemy[x, y] = new Casilla(x, y);   //Enemigo
                    MatrizCasillaUser[x, y] = new Casilla(x, y);    //Usuario
                }
            label2.Text = "3";
            label3.Visible = false;
            timer.Start();

        }

       

        private void enviar_Click(object sender, EventArgs e)//Envia 16/x y (coordenadas de casilla a atacar)
        {
            if (p.GetState() == estado.Jugando)
            {
                if (dataGridRival.SelectedCells.Count == 1)
                {
                    if (MatrizCasillaEnemy[dataGridRival.CurrentCell.RowIndex, dataGridRival.CurrentCell.ColumnIndex].IsItChecked() == true)
                    {
                        string msg = String.Format("{0}" + "-" + "{1}",
                        dataGridRival.CurrentCell.RowIndex,
                        dataGridRival.CurrentCell.ColumnIndex);
                        server.SendToServer(16, msg);
                        MatrizCasillaEnemy[dataGridRival.CurrentCell.RowIndex, dataGridRival.CurrentCell.ColumnIndex].CheckCell();
                        p.SetState("listo");
                        label1.Text = "¡LISTO!";
                    }
                    else MessageBox.Show("Ya habias probado antes con esa casilla...");
                }
                else MessageBox.Show("Selecciona una sola casilla");
            }
            else MessageBox.Show("No es tu turno!");
        }

        private void clock_time_Tick(object sender, EventArgs e)//Algoritmo reloj
        {
            int unidadesseg = Convert.ToInt32(segunits.Text);
            int decenasseg = Convert.ToInt32(segdec.Text);
            int unidadesmin = Convert.ToInt32(minunit.Text);
            int decenasmin = Convert.ToInt32(mindec.Text);
            unidadesseg++;
            
            if (Convert.ToInt32(segunits.Text)==9)
            {
                unidadesseg = 0;
                decenasseg++;
                if ((Convert.ToInt32(segdec.Text)==5)&&(Convert.ToInt32(segunits.Text) == 9))
                {
                    unidadesseg = 0;
                    decenasseg = 0;
                    unidadesmin++;
                    if ((Convert.ToInt32(minunit.Text)==9) && (Convert.ToInt32(segdec.Text) == 5) && (Convert.ToInt32(segunits.Text) == 9))
                    {
                        unidadesseg = 0;
                        decenasseg = 0;
                        unidadesmin = 0;
                        decenasmin++;
                        if ((Convert.ToInt32(mindec.Text) == 5) && (Convert.ToInt32(minunit.Text) == 9) && (Convert.ToInt32(segdec.Text) == 5) && (Convert.ToInt32(segunits.Text) == 9))
                            clock_time.Enabled = false;
                    }
                }
            }
            segunits.Text = unidadesseg.ToString();
            segdec.Text = decenasseg.ToString();
            minunit.Text = unidadesmin.ToString();
            mindec.Text = decenasmin.ToString();

        }

        private void Partida_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cerrar == false)
                e.Cancel = true;
           
        }

        private void rendirseBtn_Click(object sender, EventArgs e)//Boton para rendirse. Envia 20/0
        {
            DialogResult result= MessageBox.Show("Estas seguro de que quieres rendirte? Perderás la partida...", "Rendirse?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                cerrar = true;
                server.SendToServer(20, "0");
            }
            else cerrar = false;
        }

        private void timer_Tick(object sender, EventArgs e)//Timer para el inicio de la partida. Cuando llega a 0, actualiza el estado a PREPARACIÓN(para colocar barcos)
        {
           
            int x = Convert.ToInt32(label2.Text);
            x--;
            label2.Text = x.ToString();
            if ((x == 0) && (p.GetState() == estado.Preparacion))
            {
                timer.Stop();
                label3.Text = "¡COLOCA TUS BARCOS!";
                label1.Text = "¡PREPARACIÓN!";
                label1.Visible = true;
                label3.Visible = true;

            }
        }

        private void dataGridJugador_MouseUp(object sender, MouseEventArgs e)//Algoritmo para colocar barcos
        {
            int t = Convert.ToInt32(label2.Text);
            if ((t == 0) && ((cont2 == 0) || (cont3 == 0) || (cont4 == 0) || (cont5 == 0)))//Solo deja colocar si aun te falta algun barco por colocar y si la cuenta atrás inicial ha terminado
            {
                if ((dataGridJugador.SelectedCells.Count != 1) && (dataGridJugador.SelectedCells.Count < 6))//Solo se pueden colocar barcos de 2 a 5 casillas
                {
                    if (dataGridJugador.SelectedCells.Count == 2)
                    {
                        if (cont2 == 0)
                        {
                            if (MatrizCasillaUser[dataGridJugador.SelectedCells[0].RowIndex, dataGridJugador.SelectedCells[0].ColumnIndex].GetState() == "__water__")//Si las casillas son agua, se puede colocar
                            {
                                if (MatrizCasillaUser[dataGridJugador.SelectedCells[1].RowIndex, dataGridJugador.SelectedCells[1].ColumnIndex].GetState() == "__water__")
                                {

                                    dataGridJugador.SelectedCells[0].Style.BackColor = Color.Orange;
                                    dataGridJugador.SelectedCells[1].Style.BackColor = Color.Orange;


                                    MatrizCasillaUser[dataGridJugador.SelectedCells[0].RowIndex, dataGridJugador.SelectedCells[0].ColumnIndex].SetState("__boat__");//Actualiza el estado de las casillas a boat
                                    MatrizCasillaUser[dataGridJugador.SelectedCells[1].RowIndex, dataGridJugador.SelectedCells[1].ColumnIndex].SetState("__boat__");


                                    MatrizCasillaUser[dataGridJugador.SelectedCells[0].RowIndex, dataGridJugador.SelectedCells[0].ColumnIndex].SetPropietario("barco2");//Actualiza el propietario
                                    MatrizCasillaUser[dataGridJugador.SelectedCells[1].RowIndex, dataGridJugador.SelectedCells[1].ColumnIndex].SetPropietario("barco2");
                                    for (int i = 0; i < 2; i++)//Actualiza las casillas de alrededor del barco colocado
                                    {
                                        if (dataGridJugador.SelectedCells[i].RowIndex + 1 < 10)
                                        {
                                            if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex + 1, dataGridJugador.SelectedCells[i].ColumnIndex].GetState() == "__water__")
                                            {
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex + 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex + 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetPropietario("nadie");
                                            }
                                        }
                                        if (dataGridJugador.SelectedCells[i].RowIndex - 1 >= 0)
                                        {
                                            if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex - 1, dataGridJugador.SelectedCells[i].ColumnIndex].GetState() == "__water__")
                                            {
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex - 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex - 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetPropietario("nadie");
                                            }
                                        }
                                        if (dataGridJugador.SelectedCells[i].ColumnIndex + 1 < 10)
                                        {
                                            if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex + 1].GetState() == "__water__")
                                            {
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex + 1].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex + 1].SetPropietario("nadie");
                                                
                                            }
                                        }
                                        if (dataGridJugador.SelectedCells[i].ColumnIndex - 1 >= 0)
                                        {
                                            if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex - 1].GetState() == "__water__")
                                            {
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex - 1].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex - 1].SetPropietario("nadie");
                                               
                                            }
                                        }
                                    }
                                    for(int x=0;x<10;x++)//Cambia a color azul las casillas de alrededor del barco colocado
                                    {
                                        for(int y=0;y<10;y++)
                                        {
                                            if (MatrizCasillaUser[x, y].GetPropietario() == Propietario.nadie)
                                                dataGridJugador.Rows[x].Cells[y].Style.BackColor = Color.DarkBlue;
                                        }
                                    }
                                    barco2 = new Barco2();//Crea el barco
                                    cont2++;

                                    label3.Text = "Barco de 2 casillas colocado";


                                }
                                else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");
                            }

                            else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");
                        }
                        else label3.Text = "¡Ya tienes un barco de dos casillas colocado!";
                    }
                    if (dataGridJugador.SelectedCells.Count == 3)
                    {
                        if (cont3 == 0)
                        {
                            if (MatrizCasillaUser[dataGridJugador.SelectedCells[0].RowIndex, dataGridJugador.SelectedCells[0].ColumnIndex].GetState() == "__water__")
                            {
                                if (MatrizCasillaUser[dataGridJugador.SelectedCells[1].RowIndex, dataGridJugador.SelectedCells[1].ColumnIndex].GetState() == "__water__")
                                {
                                    if (MatrizCasillaUser[dataGridJugador.SelectedCells[2].RowIndex, dataGridJugador.SelectedCells[2].ColumnIndex].GetState() == "__water__")
                                    {
                                        dataGridJugador.SelectedCells[0].Style.BackColor = Color.Orange;
                                        dataGridJugador.SelectedCells[1].Style.BackColor = Color.Orange;
                                        dataGridJugador.SelectedCells[2].Style.BackColor = Color.Orange;

                                        MatrizCasillaUser[dataGridJugador.SelectedCells[0].RowIndex, dataGridJugador.SelectedCells[0].ColumnIndex].SetState("__boat__");
                                        MatrizCasillaUser[dataGridJugador.SelectedCells[1].RowIndex, dataGridJugador.SelectedCells[1].ColumnIndex].SetState("__boat__");
                                        MatrizCasillaUser[dataGridJugador.SelectedCells[2].RowIndex, dataGridJugador.SelectedCells[2].ColumnIndex].SetState("__boat__");

                                        MatrizCasillaUser[dataGridJugador.SelectedCells[0].RowIndex, dataGridJugador.SelectedCells[0].ColumnIndex].SetPropietario("barco3");
                                        MatrizCasillaUser[dataGridJugador.SelectedCells[1].RowIndex, dataGridJugador.SelectedCells[1].ColumnIndex].SetPropietario("barco3");
                                        MatrizCasillaUser[dataGridJugador.SelectedCells[2].RowIndex, dataGridJugador.SelectedCells[2].ColumnIndex].SetPropietario("barco3");
                                        for (int i = 0; i < 3; i++)
                                        {
                                            if (dataGridJugador.SelectedCells[i].RowIndex + 1 < 10)
                                            {
                                                if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex + 1, dataGridJugador.SelectedCells[i].ColumnIndex].GetState() == "__water__")
                                                {
                                                    MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex + 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetState("__boat__");
                                                    MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex + 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetPropietario("nadie");
                                                }
                                            }
                                            if (dataGridJugador.SelectedCells[i].RowIndex - 1 >= 0)
                                            {
                                                if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex - 1, dataGridJugador.SelectedCells[i].ColumnIndex].GetState() == "__water__")
                                                {
                                                    MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex - 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetState("__boat__");
                                                    MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex - 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetPropietario("nadie");
                                                }
                                            }
                                            if (dataGridJugador.SelectedCells[i].ColumnIndex + 1 < 10)
                                            {
                                                if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex + 1].GetState() == "__water__")
                                                {
                                                    MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex + 1].SetState("__boat__");
                                                    MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex + 1].SetPropietario("nadie");
                                                }
                                            }
                                            if (dataGridJugador.SelectedCells[i].ColumnIndex - 1 >= 0)
                                            {
                                                if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex - 1].GetState() == "__water__")
                                                {
                                                    MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex - 1].SetState("__boat__");
                                                    MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex - 1].SetPropietario("nadie");
                                                }
                                            }
                                        }
                                        for (int x = 0; x < 10; x++)
                                        {
                                            for (int y = 0; y < 10; y++)
                                            {
                                                if (MatrizCasillaUser[x, y].GetPropietario() == Propietario.nadie)
                                                    dataGridJugador.Rows[x].Cells[y].Style.BackColor = Color.DarkBlue;
                                            }
                                        }
                                        barco3 = new Barco3();
                                        cont3++;

                                        label3.Text = "Barco de 3 casillas colocado";
                                    }
                                    else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");
                                }
                                else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");
                            }
                            else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");

                        }
                        else label3.Text = "¡Ya tienes un barco de 3 casillas colocado!";
                    }




                    if (dataGridJugador.SelectedCells.Count == 4)
                    {
                        if (cont4 == 0)
                        {
                            if (MatrizCasillaUser[dataGridJugador.SelectedCells[0].RowIndex, dataGridJugador.SelectedCells[0].ColumnIndex].GetState() == "__water__")
                            {
                                if (MatrizCasillaUser[dataGridJugador.SelectedCells[1].RowIndex, dataGridJugador.SelectedCells[1].ColumnIndex].GetState() == "__water__")
                                {
                                    if (MatrizCasillaUser[dataGridJugador.SelectedCells[2].RowIndex, dataGridJugador.SelectedCells[2].ColumnIndex].GetState() == "__water__")
                                    {
                                        if (MatrizCasillaUser[dataGridJugador.SelectedCells[3].RowIndex, dataGridJugador.SelectedCells[3].ColumnIndex].GetState() == "__water__")
                                        {
                                            if (((dataGridJugador.SelectedCells[0].RowIndex == dataGridJugador.SelectedCells[1].RowIndex) && (dataGridJugador.SelectedCells[1].RowIndex == dataGridJugador.SelectedCells[2].RowIndex)) || ((dataGridJugador.SelectedCells[0].ColumnIndex == dataGridJugador.SelectedCells[1].ColumnIndex) && (dataGridJugador.SelectedCells[1].ColumnIndex == dataGridJugador.SelectedCells[2].ColumnIndex)))//Para impedir que se hagan barcos cuadrados. Detecta si coincide el RowIndex o el ColumnIndex de las casillas colocadas. 
                                            {
                                                dataGridJugador.SelectedCells[0].Style.BackColor = Color.Orange;
                                                dataGridJugador.SelectedCells[1].Style.BackColor = Color.Orange;
                                                dataGridJugador.SelectedCells[2].Style.BackColor = Color.Orange;
                                                dataGridJugador.SelectedCells[3].Style.BackColor = Color.Orange;
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[0].RowIndex, dataGridJugador.SelectedCells[0].ColumnIndex].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[1].RowIndex, dataGridJugador.SelectedCells[1].ColumnIndex].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[2].RowIndex, dataGridJugador.SelectedCells[2].ColumnIndex].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[3].RowIndex, dataGridJugador.SelectedCells[3].ColumnIndex].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[0].RowIndex, dataGridJugador.SelectedCells[0].ColumnIndex].SetPropietario("barco4");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[1].RowIndex, dataGridJugador.SelectedCells[1].ColumnIndex].SetPropietario("barco4");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[2].RowIndex, dataGridJugador.SelectedCells[2].ColumnIndex].SetPropietario("barco4");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[3].RowIndex, dataGridJugador.SelectedCells[3].ColumnIndex].SetPropietario("barco4");
                                                for (int i = 0; i < 4; i++)
                                                {
                                                    if (dataGridJugador.SelectedCells[i].RowIndex + 1 < 10)
                                                    {
                                                        if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex + 1, dataGridJugador.SelectedCells[i].ColumnIndex].GetState() == "__water__")
                                                        {
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex + 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetState("__boat__");
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex + 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetPropietario("nadie");
                                                        }
                                                    }
                                                    if (dataGridJugador.SelectedCells[i].RowIndex - 1 >= 0)
                                                    {
                                                        if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex - 1, dataGridJugador.SelectedCells[i].ColumnIndex].GetState() == "__water__")
                                                        {
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex - 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetState("__boat__");
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex - 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetPropietario("nadie");
                                                        }
                                                    }
                                                    if (dataGridJugador.SelectedCells[i].ColumnIndex + 1 < 10)
                                                    {
                                                        if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex + 1].GetState() == "__water__")
                                                        {
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex + 1].SetState("__boat__");
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex + 1].SetPropietario("nadie");
                                                        }
                                                    }
                                                    if (dataGridJugador.SelectedCells[i].ColumnIndex - 1 >= 0)
                                                    {
                                                        if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex - 1].GetState() == "__water__")
                                                        {
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex - 1].SetState("__boat__");
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex - 1].SetPropietario("nadie");
                                                        }
                                                    }
                                                }
                                                for (int x = 0; x < 10; x++)
                                                {
                                                    for (int y = 0; y < 10; y++)
                                                    {
                                                        if (MatrizCasillaUser[x, y].GetPropietario() == Propietario.nadie)
                                                            dataGridJugador.Rows[x].Cells[y].Style.BackColor = Color.DarkBlue;
                                                    }
                                                }
                                                barco4 = new Barco4();
                                                cont4++;
                                                label3.Text = "Barco de 4 casillas colocado";
                                            }
                                            else MessageBox.Show("No hagas barcos con forma de cuadrado...");
                                        }
                                        else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");
                                    }
                                    else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");
                                }
                                else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");

                            }
                            else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");
                        }
                        else label3.Text = "¡Ya tienes un barco de 4 casillas colocado!";
                    }
                    if (dataGridJugador.SelectedCells.Count == 5)
                    {
                        if (cont5 == 0)
                        {
                            if (MatrizCasillaUser[dataGridJugador.SelectedCells[0].RowIndex, dataGridJugador.SelectedCells[0].ColumnIndex].GetState() == "__water__")
                            {
                                if (MatrizCasillaUser[dataGridJugador.SelectedCells[1].RowIndex, dataGridJugador.SelectedCells[1].ColumnIndex].GetState() == "__water__")
                                {
                                    if (MatrizCasillaUser[dataGridJugador.SelectedCells[2].RowIndex, dataGridJugador.SelectedCells[2].ColumnIndex].GetState() == "__water__")
                                    {
                                        if (MatrizCasillaUser[dataGridJugador.SelectedCells[3].RowIndex, dataGridJugador.SelectedCells[3].ColumnIndex].GetState() == "__water__")
                                        {
                                            if (MatrizCasillaUser[dataGridJugador.SelectedCells[3].RowIndex, dataGridJugador.SelectedCells[4].ColumnIndex].GetState() == "__water__")
                                            {
                                                dataGridJugador.SelectedCells[0].Style.BackColor = Color.Orange;
                                                dataGridJugador.SelectedCells[1].Style.BackColor = Color.Orange;
                                                dataGridJugador.SelectedCells[2].Style.BackColor = Color.Orange;
                                                dataGridJugador.SelectedCells[3].Style.BackColor = Color.Orange;
                                                dataGridJugador.SelectedCells[4].Style.BackColor = Color.Orange;
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[0].RowIndex, dataGridJugador.SelectedCells[0].ColumnIndex].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[1].RowIndex, dataGridJugador.SelectedCells[1].ColumnIndex].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[2].RowIndex, dataGridJugador.SelectedCells[2].ColumnIndex].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[3].RowIndex, dataGridJugador.SelectedCells[3].ColumnIndex].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[4].RowIndex, dataGridJugador.SelectedCells[4].ColumnIndex].SetState("__boat__");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[0].RowIndex, dataGridJugador.SelectedCells[0].ColumnIndex].SetPropietario("barco5");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[1].RowIndex, dataGridJugador.SelectedCells[1].ColumnIndex].SetPropietario("barco5");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[2].RowIndex, dataGridJugador.SelectedCells[2].ColumnIndex].SetPropietario("barco5");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[3].RowIndex, dataGridJugador.SelectedCells[3].ColumnIndex].SetPropietario("barco5");
                                                MatrizCasillaUser[dataGridJugador.SelectedCells[4].RowIndex, dataGridJugador.SelectedCells[4].ColumnIndex].SetPropietario("barco5");
                                                for (int i = 0; i < 5; i++)
                                                {
                                                    if (dataGridJugador.SelectedCells[i].RowIndex + 1 < 10)
                                                    {
                                                        if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex + 1, dataGridJugador.SelectedCells[i].ColumnIndex].GetState() == "__water__")
                                                        {
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex + 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetState("__boat__");
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex + 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetPropietario("nadie");
                                                        }
                                                    }
                                                    if (dataGridJugador.SelectedCells[i].RowIndex - 1 >= 0)
                                                    {
                                                        if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex - 1, dataGridJugador.SelectedCells[i].ColumnIndex].GetState() == "__water__")
                                                        {
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex - 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetState("__boat__");
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex - 1, dataGridJugador.SelectedCells[i].ColumnIndex].SetPropietario("nadie");
                                                        }
                                                    }
                                                    if (dataGridJugador.SelectedCells[i].ColumnIndex + 1 < 10)
                                                    {
                                                        if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex + 1].GetState() == "__water__")
                                                        {
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex + 1].SetState("__boat__");
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex + 1].SetPropietario("nadie");
                                                        }
                                                    }
                                                    if (dataGridJugador.SelectedCells[i].ColumnIndex - 1 >= 0)
                                                    {
                                                        if (MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex - 1].GetState() == "__water__")
                                                        {
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex - 1].SetState("__boat__");
                                                            MatrizCasillaUser[dataGridJugador.SelectedCells[i].RowIndex, dataGridJugador.SelectedCells[i].ColumnIndex - 1].SetPropietario("nadie");
                                                        }
                                                    }
                                                }
                                                for (int x = 0; x < 10; x++)
                                                {
                                                    for (int y = 0; y < 10; y++)
                                                    {
                                                        if (MatrizCasillaUser[x, y].GetPropietario() == Propietario.nadie)
                                                            dataGridJugador.Rows[x].Cells[y].Style.BackColor = Color.DarkBlue;
                                                    }
                                                }
                                                barco5 = new Barco5();
                                                cont5++;
                                                label3.Text = "Barco de 5 casillas colocado";

                                            }
                                            else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");
                                        }
                                        else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");
                                    }
                                    else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");
                                }
                                else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");

                            }
                            else MessageBox.Show("¡Has seleccionado casillas que ya eran un barco, o está demasiado cerca!");


                        }
                        else label3.Text = "¡Ya tienes un barco de 5 casillas colocado!";
                    }
                }
            }
           
            if (((cont2 == 1) && (cont3 == 1) && (cont4 == 1) && (cont5 == 1))&&(p.GetState()==estado.Preparacion))//Actualiza el estado (segun la moneda) si estaba en preparación y ha terminado de colocar los barcos
            {
                colocados = true;
                if (herecibidomoneda==1)
                {
                    if (moneda==0)
                    {
                        p.SetState("listo");
                        delegate_write_lbl del = new delegate_write_lbl(EscribirLabel1);
                        label1.Invoke(del, new object[] { "¡LISTO!" });
                    }
                    else
                    {
                        p.SetState("jugando");
                        delegate_write_lbl del = new delegate_write_lbl(EscribirLabel1);
                        label1.Invoke(del, new object[] { "¡TU TURNO!" });
                    }
                    
                }
                else if ((herecibidomoneda==0)&&(SoyInvitado==false))
                    label3.Text = "¡Has colocado todos tus barcos! Espera a que tu rival tire la moneda...";
                else
                    label3.Text="¡Has colocado todos tus barcos! Tira la moneda para saber quien empieza.";    
            }
        }
        private void Moneda_Click(object sender, EventArgs e)//Botón para la saber quien empieza. Solo la puedes tirar si eres el invitado. Envia 17/1 si ganas (sale 1) o 17/0 si pierdes.
        {
            if ((cont2 == 1) && (cont3 == 1) && (cont4 == 1) && (cont5 == 1))
            {
                if (SoyInvitado == true)
                {

                    Random rand = new Random();
                    int moneda = rand.Next(0,2);
                    if (moneda == 1)
                    {
                        server.SendToServer(17, "1");
                        p.SetState("jugando");
                        label1.Text = "¡TU TURNO!";
                    }
                    else
                    {
                        p.SetState("listo");
                        label1.Text = "¡LISTO!";
                        server.SendToServer(17, "0");
                    }
                }
                else MessageBox.Show("¡Deja que la tire el invitado!");
                Moneda.Enabled = false;
            }
            else MessageBox.Show("¡Coloca primero tus barcos!");
            
        }

        public void EscribirLabel1(string text)//Funciones para delegados
        {
            label1.Text = text;
        }

        public void EscribirLabel2(string text)
        {
            label2.Text = text;
        }

        public void EscribirLabel3(string text)
        {
            label3.Text = text;
        }
        public void DisableDatagridJugador()
        {
            dataGridJugador.Enabled = false;
        }
        public void DisableDataGridRival()
        {
            dataGridRival.Enabled = false;
        }
        public void DisableMoneda()
        {
            Moneda.Enabled = false;
        }
        public void DisableRendirse()
        {
            rendirseBtn.Enabled = false;
        }
        public void DisableEnviar()
        {
            enviar.Enabled = false;
        }
           
    }
}

            
        
        
           
        
    


      

    
            

           
      
