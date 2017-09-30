using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tcpclientSocket
{
    //客户端
    class Program
    {
        static void Main(string[] args)
        {
            Socket tcpclientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //发起建立连接的请求
            IPAddress ipAddress = IPAddress.Parse("192.168.1.100");
            EndPoint point = new IPEndPoint(ipAddress, 7882);
            tcpclientSocket.Connect(point);//定位到一个要连接的服务器端point

            //客户端接收消息
            byte[] data = new byte[1024];
            string message = Encoding.UTF8.GetString(data, 0, tcpclientSocket.Receive(data));
            Console.WriteLine(message);

            //向服务器端发送消息
            string message2 = Console.ReadLine();
            byte[] data2=Encoding.UTF8.GetBytes(message2);
            tcpclientSocket.Send(data2);
            
            Console.ReadKey();
        }
    }
}
