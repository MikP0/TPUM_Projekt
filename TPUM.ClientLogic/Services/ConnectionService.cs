using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TPUM.ClientData;
using TPUM.ClientData.Model;

namespace TPUM.ClientLogic
{
    public class ConnectionService
    {
        public ClientWebSocketConnection _clientWebSocket;
        public Action<string> _connectionLogger;
        public WebSocketController socketController;

        public ConnectionService()
        {
            socketController = new WebSocketController();
        }

        public async Task<bool> CreateConnection(Uri peer)
        {
            await socketController.Connect(peer);
            return true;
        }

        public async Task<bool> SendTask(string newTask)
        {
            await socketController.SendTask(newTask);
            return true;
        }
    }
}
