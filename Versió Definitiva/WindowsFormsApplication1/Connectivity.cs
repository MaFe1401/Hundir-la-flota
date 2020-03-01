using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{
    public class Connectivity
    {
        Socket Servidor;
        IPAddress direc;
        IPEndPoint ipep;
        int PORT = 50002;
        int codigo;
        public int GetCodigo()
        {
            return codigo;
        }
        public void SetCodigo()
        {
            codigo = 0;
        }

        public Socket ReturnServidor()
        {
            return Servidor;
        }
        //Establece las direcciones
        private void SetConnection()
        {
            this.direc = IPAddress.Parse("147.83.117.22"); //IP
            this.ipep = new IPEndPoint(direc, PORT);//IP, Puerto definido como variable del Connectivity
        }
        //Conectar al servidor
        public int ConnectServer()
        {
            this.SetConnection(); //Creamos las connexiones
            Servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                this.Servidor.Connect(ipep); //Creamos una conexion con el servidor.
                return 1; //Retornamos 1 para informar al cliente de que se ha establecido connexión.
            }
            catch (SocketException)
            {
                return 0; //Retornamos 0 para informar que no se ha podido establecer connexión con el cliente.
            }
        }
        //Desconectar del servidor
        public void DisconnectServer()
        {
            Servidor.Shutdown(SocketShutdown.Both);
            Servidor.Close();
        }
        //Enviar el mensaje al servidor
        public void SendToServer(int codigo, string mensaje)
        {
            mensaje = codigo.ToString() + "/" + mensaje;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            Servidor.Send(msg); 
        }
        //Función que ejecuta el thread
        public string ReceiveFromServer()
        {
            string[] mensaje;
            int code;
            string msg;
            byte[] msg2 = new byte[500];
            Servidor.Receive(msg2);
            mensaje = Encoding.ASCII.GetString(msg2).Split('/');
            code = Convert.ToInt32(mensaje[0]);
            codigo = code;
            msg = mensaje[1].Split('\0')[0];
            return msg;
          
        }
    }
}