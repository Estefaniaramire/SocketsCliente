
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PracticaSocketCS
{
    internal class Program
    { 
        //SOCKET CLIENTE
        static void Main(string[] args)
        {
            string servidorIP = "127.0.0.1";
            int puerto = 11200;

            Socket clienteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Hacemoms conexión al servidorr utilizando el endPoint especificado.
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(servidorIP), puerto);
            clienteSocket.Connect(endPoint);

            // El mensaje se envía al servidor a través del socket del cliente.
            string mensaje = "¡Hola, servidor soy el primer cliente!";
            byte[] mensajeBytes = Encoding.ASCII.GetBytes(mensaje);
            clienteSocket.Send(mensajeBytes);

            // Se recibe la respuesta del servidor y se almacena en el buffer.
            // La cantidad de bytes recibidos se almacena en la variable 'bytesRecibidos'.
            byte[] buffer = new byte[1024];
            int bytesRecibidos = clienteSocket.Receive(buffer);
            string respuesta = Encoding.ASCII.GetString(buffer, 0, bytesRecibidos);
            System.Console.WriteLine($"Respuesta del servidor: {respuesta}");

            // Se cierra el socket del cliente después
            // de completar la comunicación con el servidor.
            clienteSocket.Close();
            System.Console.ReadKey();
        }
    }
}