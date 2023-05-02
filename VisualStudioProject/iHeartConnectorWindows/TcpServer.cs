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
            this.ip = ip;
            this.port = port;
        }

        private IPAddress ip;
        private int port;

        private bool running = false;
        public bool Running { get { return running; } }

        private TcpListener? server;

        private List<TcpClient> clients = new();

        private Thread? thread;
        private bool terminationRequested = false;

        public void Start()
        {
            server = new(ip, port);
            thread = new Thread(new ThreadStart(threadWork));
            thread.Start();
            server.Start();
            Accept_connection();
            running = true;
        }

        public async void Stop()
        {
            terminationRequested = true;
            if (thread != null)
                await Task.Run(() => thread.Join());
            if (server != null)
                server.Stop();
            running = false;
        }

        public void Send(byte[] data)
        {
            TcpClient client;
            for (int i = 0; i < clients.Count; i++)
            {
                client = clients[i];
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
            TcpClient client;
            while (!terminationRequested)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    client = clients[i];
                    if (!client.Client.Poll(100, SelectMode.SelectWrite))
                        try
                        {
                            clients.Remove(client);
                            client.Dispose();
                        }
                        catch { }
                }

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
