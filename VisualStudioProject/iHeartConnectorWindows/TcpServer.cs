using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OximeterServer
{
    internal class TcpServer
    {
        public TcpServer(IPAddress ip, int port)
        {
            server = new(ip, 6000);
            thread = new Thread(new ThreadStart(threadWork));
        }

        private readonly TcpListener server;

        private List<TcpClient> clients = new();

        private readonly Thread thread;
        private bool terminationRequested = false;

        public void Start()
        {
            thread.Start();
            server.Start();
            Accept_connection();
        }

        public async void Stop()
        {
            terminationRequested = true;
            await Task.Run(() => thread.Join());
        }

        public void Send(byte[] data)
        {
            foreach (TcpClient client in clients)
            {
                try
                {
                    client.GetStream().Write(data);
                }
                catch
                {
                    clients.Remove(client);
                    client.Dispose();
                }
            }
        }

        private void threadWork()
        {
            while (!terminationRequested)
            {
                foreach (TcpClient c in clients)
                    if (!c.Client.Poll(100, SelectMode.SelectWrite))
                        try
                        {
                            clients.Remove(c);
                            c.Dispose();
                        }
                        catch { }

                Thread.Sleep(500);
            }

            for (int i = 0; i < clients.Count; i++)
            {
                try
                {
                    clients[i].Dispose();
                }
                catch { }
            }
        }

        private void Accept_connection()
        {
            try
            {
                server.BeginAcceptTcpClient(Handle_connection, server);
            }
            catch { }
        }

        private void Handle_connection(IAsyncResult result)
        {
            TcpClient client;

            try
            {
                Accept_connection();
                client = server.EndAcceptTcpClient(result);
                clients.Add(client);
            }
            catch { return; }
        }
    }
}
