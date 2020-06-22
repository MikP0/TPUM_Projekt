using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TPUM.ClientData;

namespace TPUM.ClientLogic
{
    public class ConnectionService
    {
        public ClientWebSocketConnection _clientWebSocket;
        public Action<string> _connectionLogger;
        public WebSocketController socketController;
        private Uri _Uri;

        public ConnectionService()
        {
            socketController = new WebSocketController();
        }

        public ConnectionService(string uri)
        {
            socketController = new WebSocketController();
            _Uri = new Uri(uri);
        }

        public async Task<bool> CreateConnection()
        {
            await socketController.Connect(_Uri);
            return true;
        }

        public void CreateConnectionInter()
        {
            socketController.ConnectInter(_Uri);
        }

        public async Task<bool> SendTask(string newTask)
        {
            await socketController.SendTask(newTask);
            return true;
        }

        public void SendMessegeInter(string newTask)
        {
            socketController.SendMessegeInter(newTask);
        }

        public ClientWebSocketConnection GetClientWebSocket()
        {
            return socketController._clientWebSocket;
        }
    }
}
