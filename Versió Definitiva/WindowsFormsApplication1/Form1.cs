using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Connectivity server = new Connectivity();
        Partida p;
        bool Logged;
        bool jugando = false;
        bool soyinvitado;
        Thread atender;
        string user;
        string password;
        delegate void Delegate_to_write(string remitente,string texto);//delegados
        delegate void Delegate_lista(string text);
        delegate void Delegate_to_show(bool optn);
        delegate void Delegate_Etiqueta(string text);
        delegate void Form_Delegate(Partida p);
        delegate void Form_Close();
        public Form1()
        {
            InitializeComponent();
        }
        public bool GetLogged()//devuelve logged
        {
            return Logged;
        }
        public void SetLogged()//establece logged=true
        {
            Logged = true;
        }
        public string GetUser()//devuelve user
        {
            return user;
        }
        public void SetJugando()//jugando=false
        {
            jugando = false;
        }
        private void Conectados_visible(bool optn)//
        {
            Conectados.Visible = optn;
        }


        //Para Iniciar el cliente con Logged false
        private void Form1_Load(object sender, EventArgs e)
        {
            Logged = false;
            Conectados.ColumnCount = 1;
            Conectados.Columns[0].HeaderText = "Conectados";
        }

        //Iniciar sesión(solo si logged=false) con lo cual no habias iniciado sesión antes
        private void LogIN_Click(object sender, EventArgs e)
        {
           
            if (Logged==false)
            {
                if (server.ConnectServer() == 1)
                {
                    Login();
                    ThreadStart ts = delegate { EjecutarThread(); };
                    atender = new Thread(ts);
                    atender.Start();

                }
                else
                    MessageBox.Show("Hubo algún problema con la conexión.");
            }
            else
            {
                MessageBox.Show("Ya has iniciado sesión.");
            }

        }
        //Registrarse (solo si logged=false)
        private void SignUP_Click_1(object sender, EventArgs e)
        {

            if (!Logged)
            {
                if (server.ConnectServer() == 1)
                {
                    Register();
                    ThreadStart ts = delegate { EjecutarThread(); };
                    atender = new Thread(ts);
                    atender.Start();
                }
                else
                    MessageBox.Show("Hubo algún problema con la conexión.");
            }
            else
            {
                MessageBox.Show("Cuidado estas loggeado por el moment.");
            }
        }

        private void DeleteAccount_Click(object sender, EventArgs e)//borrar cuenta. Envia 15/usuario al server
        {
            if (!Logged)
                MessageBox.Show("No has iniciado sesión");
            else
            {
                server.SendToServer(15,user);
            }
                 
        }
        private void Disconnect_Click(object sender, EventArgs e)//desconectarse si estás logeado (envia 0/ si no se está jugando o 20/ si se esta jugando)
        {
            if (Logged)
            {
                if (jugando == false)
                {
                    atender.Abort();
                    server.SendToServer(0, user);
                    server.DisconnectServer();
                    Logged = false;
                }
                else server.SendToServer(20, "0");
            }
        }   
       
        //Consultas
        private void QueryButton_Click(object sender, EventArgs e)
        {
            if (Logged)
            {
                if (puntotal.Checked)//Puntos(barcos derribados) de un jugador
                {
                    GetPunTotal();
                }

                if (tiempo.Checked)//tiempo jugado
                {
                    GetTiempoTotal();
                }

                if (veces.Checked)//victorias de un jugador
                {
                    GetVictorias();
                }
                else if ((!veces.Checked) && (!tiempo.Checked) && (!puntotal.Checked))
                {
                    MessageBox.Show("Selecciona primero una categoria");
                }
            }
            else
                MessageBox.Show("Para Usar estas funciones deberías iniciar sesión.");
        }
       
        //Actualizar lista conectados
        public void ActualizarLista(string lista)
        {
            Conectados.Rows.Clear();
            string[] conectados = lista.Split(' ');
            for (int i = 0; i < conectados.Length-1; i++)
            {
                Conectados.Rows.Add(conectados[i]);
            }
        }
        public void RellenarEtiqueta(string remitente,string mensaje)//funcion delegado
        {
            Chat.Text =remitente+": "+ mensaje;
        }
        public void CerrarForm()//funcion delegado
        {
            p.Close();
        }
        public void MostrarForm ()//No se usa
        {
            Partida p = new Partida(server); //creamos un nuevo form para la partida
            p.SetSoyInvitado(false);
            p.ShowDialog();
        }
        public void MostrarFormInvitado()//No se usa
        {
            Partida p = new Partida(server); //creamos un nuevo form para la partida
            p.SetSoyInvitado(true);
            p.ShowDialog();
        }
        //Enviar invitaciones
        private void Invitar_Click(object sender, EventArgs e)//Si "user" coincide con el texto de la casilla seleccionada, te estas invitando a tí mismo...No queremos eso
        {
            if (jugando == false)
            {
                if (Conectados.SelectedRows.Count == 1)
                {
                    if (user != Conectados.SelectedRows[0].Cells[0].Value.ToString())
                        server.SendToServer(7, Conectados.SelectedRows[0].Cells[0].Value.ToString());
                    else MessageBox.Show("¡No te invites a tí mismo!");
                }
                if (Conectados.SelectedRows.Count == 0)
                    MessageBox.Show("Selecciona a alguien primero");
                if ((Conectados.SelectedRows.Count != 0) && (Conectados.SelectedRows.Count != 1))
                    MessageBox.Show("Selecciona 1 jugador");
            }
            else MessageBox.Show("Ya estás jugando una partida...");
        }
        private void Send_Click(object sender, EventArgs e)//Enviar mensaje
        {
            if (Conectados.SelectedRows.Count == 1)
            {
                if (user != Conectados.SelectedRows[0].Cells[0].Value.ToString())
                {
                    server.SendToServer(13, Conectados.SelectedRows[0].Cells[0].Value.ToString() + "-" + texto.Text);
                }
                else MessageBox.Show("¡No te hables a tí mismo");
               
            }
            if (Conectados.SelectedRows.Count == 0)
                MessageBox.Show("Selecciona a alguien primero");
            if ((Conectados.SelectedRows.Count != 0) && (Conectados.SelectedRows.Count != 1))
                MessageBox.Show("Selecciona 1 jugador");
            
        }
        //FUNCIONES PARA LOS BOTONES:
        private void Register()//Registrarse. Envia 2/usuario contraseña al servidor
        {
            if ((string.IsNullOrEmpty(usuario.Text)) || (string.IsNullOrEmpty(contraseña.Text)))
            {
                MessageBox.Show("Los campos no pueden estar vacios.");
            }
            else
            {
                user = usuario.Text;
                password = contraseña.Text;
                server.SendToServer(2, usuario.Text + " " + contraseña.Text);
            }
        }

        private void Login()//Iniciar sesión. Envia 1/usuario contraseña al servidor
        {
            if ((string.IsNullOrEmpty(usuario.Text)) || (string.IsNullOrEmpty(contraseña.Text)))
            {
                MessageBox.Show("Los campos no pueden estar vacios.");
            }
            else
            {
                user = usuario.Text;
                password=contraseña.Text;
                server.SendToServer(1, user + " " + password);
            }
        }
        private bool GetPunTotal()//Envia 3/usuario para saber los barcos derribados por usuario. Retorna true si salió bien
        {
            if (string.IsNullOrEmpty(usuarioPuntos.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.");
                return false;
            }
            else
            {
                server.SendToServer(3, usuarioPuntos.Text);
                return true;
            }
        }

        private bool GetTiempoTotal()//Envia 4/usuario para saber el tiempo jugado por usuario. Retorna true si salió bien
        {
            if (string.IsNullOrEmpty(usuarioTiempo.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.");
                return false;
            }
            else
            {
                server.SendToServer(4, usuarioTiempo.Text);
                return true;
            }
        }

        private bool GetVictorias()//Envia 5/usuario para saber las victorias conseguidas por usuario. Retorna true si salió bien
        {
            if (string.IsNullOrEmpty(usuarioVeces.Text))
            {
                MessageBox.Show("El campo no puede estar vacío.");
                return false;
            }
            else
            {
                server.SendToServer(5, usuarioVeces.Text);
                return true;
            }
        }
        //Al cerrar se desconecta.Detiene el thread. Envia 0/usuario
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Logged)
            {
                if (jugando == false)
                {
                    DialogResult res = MessageBox.Show("¿Estas seguro que quieres salir?", "Exit", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK)
                    {
                        atender.Abort();
                        server.SendToServer(0, user);
                        server.DisconnectServer();
                    }
                    if (res == DialogResult.Cancel)
                        e.Cancel = true;
                }
                else server.SendToServer(20, "0");
               
            }
        }
        //Funcion que ejecuta el thread
        private void EjecutarThread()
        {
            while (true)
            {
                string msg = server.ReceiveFromServer();
                int respuesta;

                switch (server.GetCodigo())
                {
                    case 1://Login
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta == 1)//Logeado correctamente
                        {
                            if (Logged==false)
                            {
                                Logged = true;
                                MessageBox.Show("Has iniciado sesión.");
                                Delegate_to_show delegated;
                                delegated = new Delegate_to_show(Conectados_visible);
                                Conectados.Invoke(delegated, new object[] { true });
                                server.SetCodigo();
                            }
                            else
                            {
                                Delegate_to_show delegated;
                                delegated = new Delegate_to_show(Conectados_visible);
                                Conectados.Invoke(delegated, new object[] { true });
                                server.SetCodigo();
                            }
                           
                        }
                        else
                        {
                            MessageBox.Show("Hubo algún problema.");
                            server.SetCodigo();
                        }
                        break;
                    case 2://Registro
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta == 1)
                        {
                            Logged = true;
                            MessageBox.Show("Correctamente Registrado y Loggeado.");
                            server.SetCodigo();
                        }
                        else
                        {
                            MessageBox.Show("Hubo algún problema.");
                            server.SetCodigo();
                        }
                        break;
                    case 3://Consulta barcos derribados
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta >= 0)
                        {
                            MessageBox.Show("Ha derribado un total de " + respuesta.ToString() + " barcos");
                            server.SetCodigo();
                        }
                        else
                        {
                            MessageBox.Show("El usuario no existe o hubo algun problema");
                            server.SetCodigo();
                        }
                        break;
                    case 4://Consulta tiempo jugado
                        respuesta = Convert.ToInt32(msg);
                        float minutos = respuesta / 60;
                        float segundos = respuesta % 60;
                        if (respuesta >= 0)
                        {
                            MessageBox.Show("Su tiempo total jugado es " +minutos.ToString()+" min"+" "+segundos.ToString()+" seg");
                            server.SetCodigo();
                        }
                        else
                        {
                            MessageBox.Show("El usuario no existe o hubo algun problema");
                            server.SetCodigo();
                        }
                        break;
                    case 5://consulta victorias
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta >= 0)
                        {
                            MessageBox.Show("Ha ganado" + " " + respuesta.ToString() + " " + "veces");
                            server.SetCodigo();
                        }
                        else
                        {
                            MessageBox.Show("El usuario no existe o hubo algun problema");
                            server.SetCodigo();
                        }
                        break;
                    case 6://Actualizar lista conectados
                        {
                            Delegate_lista delegated = new Delegate_lista(ActualizarLista);
                            Conectados.Invoke(delegated, new object[] { msg });
                            server.SetCodigo();
                            break;
                        }
                    case 7://Recepción de invitación. Envia 8/ si acepta, 9/ si rechaza
                        DialogResult result = MessageBox.Show(msg + " " + "te invita a jugar una partida, aceptas?", "Invitación recibida", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            
                            server.SendToServer(8, msg);
                            server.SetCodigo();
                          
                        }
                        else if (result == DialogResult.No)
                        {
                            server.SendToServer(9, msg);
                            server.SetCodigo();
                        }
                        break;
                    case 8://El invitado ha aceptado
                        MessageBox.Show(msg + " ha aceptado la invitación. Clica el botón 'partida' para empezar.");
                        server.SetCodigo();
                        soyinvitado = false;
                        jugando = true;
                        break;
                    case 9://El invitado ha rechazado
                        MessageBox.Show(msg + " ha rechazado la invitación");
                        server.SetCodigo();
                        break;
                    case 10://
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta == 0)
                            MessageBox.Show("Hubo algun problema");
                        server.SetCodigo();
                        break;
                    case 11://
                        respuesta = Convert.ToInt32(msg);
                        if (respuesta == 0)
                            MessageBox.Show("Hubo algun problema");
                        server.SetCodigo();
                        break;
                    case 12://Aquel que acepte una invitación recibirá 12/ si salió bien
                        respuesta = Convert.ToInt32(msg);
                        server.SetCodigo();
                        if (respuesta == 1)
                        {
                            soyinvitado = true;
                            jugando = true;
                            MessageBox.Show("Invitación aceptada. Clica el boton 'partida' para empezar");
                            
                        }
                        if (respuesta == 0)
                            MessageBox.Show("Hubo algún problema");
                        break;
                    case 13://Chat
                        string[] resp = msg.Split('-');
                        MessageBox.Show(usuario.Text+", "+resp[0]+" "+"te envía un mensaje");
                        Delegate_to_write delegatex = new Delegate_to_write(RellenarEtiqueta);
                        Chat.Invoke(delegatex, new object[] { resp[0],resp[1] });
                            server.SetCodigo();
                            break;
                    case 14://Se envió un mensaje que ha llegado bien
                            MessageBox.Show(usuario.Text+","+"el mensaje se ha enviado bien");
                            break;
                    case 15://Borrar cuenta. Recibe 15/1 si salió bien
                         respuesta = Convert.ToInt32(msg);
                         if (respuesta == 1)
                         {
                             MessageBox.Show("Cuenta borrada correctamente");
                             Logged = false;
                         }
                         else MessageBox.Show("Ocurrió algun problema");
                         break;
                    case 16://Ejecuta función Caso16 del Form Partida
                        p.Caso16(msg);
                        server.SetCodigo();
                        break;
                    case 17://Ejecuta funcion Caso17 del Form Partida
                        respuesta = Convert.ToInt32(msg);
                        p.Caso17(respuesta);
                        server.SetCodigo();
                        break;
                    case 18://Ejecuta funcion Caso18 del Form Partida
                        respuesta = Convert.ToInt32(msg);
                        p.Caso18(respuesta);
                        server.SetCodigo();
                        break;
                    case 20://Ejecuta funcion Caso20 del Form Partida, cierra el form Partida
                        p.Caso20();
                        jugando = false;
                        soyinvitado = false;
                        Form_Close delegad = new Form_Close(CerrarForm);
                        try
                        {
                            p.Invoke(delegad, new object[] { });
                        }
                        catch { }
                        server.ConnectServer();
                        server.SendToServer(1, user + " " + password);
                        break;
                    case 21://Ejecuta funcion Caso21 del Form Partida, cierra el form Partida
                        p.Caso21();
                        jugando = false;
                        soyinvitado = false;
                        Form_Close delegado = new Form_Close(CerrarForm);
                        try
                        {
                            p.Invoke(delegado, new object[] { });
                        }
                        catch { }
                        server.ConnectServer();
                        server.SendToServer(1, user + " " + password);
                        break;
                    case 22://Ejecuta funcion Caso22 del Form Partida, cierra el form Partida
                        p.Caso22();
                        jugando = false;
                        soyinvitado = false;
                        Form_Close delega = new Form_Close(CerrarForm);
                        try
                        {
                            p.Invoke(delega, new object[] { });
                        }
                        catch { }
                        server.ConnectServer();
                        server.SendToServer(1, user + " " + password);
                        break;

                }
            }

        }

        private void button1_Click(object sender, EventArgs e)//Abre el form partida, determina si eres invitado o no (si aceptó una invitación, es invitado)
        {
            if (jugando == true)
            {
                p = new Partida(server);
                p.SetUser(user);
                if (soyinvitado == true)
                    p.SetSoyInvitado(true);
                else p.SetSoyInvitado(false);
                p.ShowDialog();
            }
            else MessageBox.Show("Encuentra a alguien para jugar primero");
            

        }

      
    }
}
       
            
        


      



    



