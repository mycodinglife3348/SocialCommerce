using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Social_Commerce_Server.Communicate
{
    public delegate void MsgProc(Socket client, String msg);
    public class Sock_Proc
    {
        private MsgProc msgProc = new MsgProc(Surrogate_Objs.Surogates.MsgProc);
        private String ip = "0.0.0.0";
        private int port = 3348;
        private int MaxConnect = 100;
        public class ServerParams
        {
            public Socket client = null;
            public const int BufferSize = 1024;
            public byte[] buffer = new byte[BufferSize];
        }
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public Sock_Proc()
        {
            
        }
    public void Listening()
        {
            IPAddress Addr = IPAddress.Parse(ip);
            IPEndPoint IEP = new IPEndPoint(Addr,port);
            Socket Listener = new Socket(Addr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
            try
            {

                Listener.Bind(IEP);
                Listener.Listen(MaxConnect);

                while (true)
                {
                    allDone.Reset();//사용자가 들어올때까지 대기
                    Console.WriteLine("Connection Wait...");

                    Listener.BeginAccept(
                        new AsyncCallback(AcceptCallBack),  
                        Listener); // 사용자가 접속하면 접속을 허용한후 처리하는 AcceptCallBack에 진입한다.
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {

            }
            
        }

        private void AcceptCallBack(IAsyncResult ar)
        {
            allDone.Set();
            Socket client = (Socket)ar.AsyncState;
            Socket handler = client.EndAccept(ar);
            ServerParams param = new ServerParams();
            param.client = client;
            //*.BeginReceive(버퍼,버퍼 시작부분,버퍼MAX사이즈,소켓 플래그,ReceiveCallBack호출부,넘길 파라메터)
            handler.BeginReceive(param.buffer, 0, ServerParams.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveCallBack), param);
            
        }

        private void ReceiveCallBack(IAsyncResult ar)
        {
            String content = String.Empty;
            ServerParams param = (ServerParams)ar.AsyncState;
            Socket client = param.client;
            int bytesRead = client.EndReceive(ar);
            
            if(bytesRead > 0)
            {
                content = Encoding.UTF8.GetString(param.buffer, 0, bytesRead);
                
                msgProc(client, content);

            }
        }
    }
}
