﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TPUM.ServerPresentation
{
    public class CommunicationManager : IDisposable
    {
        public CommunicationManager(int websocketPort, Action<string> log)
        {
            Log = log;
            if (IPEndPoint.MaxPort > websocketPort && IPEndPoint.MinPort < websocketPort)
                WebsocketPort = websocketPort;
            else
                Log($"Wrong port number. System will use default port {this.WebsocketPort}");
        }

        public async Task InitServerAsync()
        {
            Log($"listening web-socket p2p port on: {WebsocketPort}");
            await WebSocketServer.Server(WebsocketPort, async _ws => await InitConnectionAsync(_ws));
        }

        private async Task InitConnectionAsync(WebSocketConnection ws)
        {
            Sockets.Add(ws);
            initMessageHandler(ws);
            initErrorHandler(ws);
            await WriteAsync(ws, "");
        }

        private void initErrorHandler(WebSocketConnection ws)
        {
            ws.onClose = () => closeConnection(ws);
            ws.onError = () => closeConnection(ws);
        }

        private void closeConnection(WebSocketConnection ws)
        {
            Log($"Closing connection to peer: {ws}");
            Sockets.Remove(ws);
        }

        private async Task WriteAsync(WebSocketConnection ws, string message)
        {
            Log($"Writing message {message}");
            await ws.SendAsync(message);
        }

        private void initMessageHandler(WebSocketConnection ws)
        {
            ws.onMessage = async (data) =>
            {
                Log($"Received message {data}");
            };
        }

        public void Dispose()
        {
            Log($"Shuting down the communicatin engine");
            List<Task> _disconnectionTasks = new List<Task>();
            foreach (WebSocketConnection _item in Sockets)
                _disconnectionTasks.Add(_item.DisconnectAsync());
            Task.WaitAll(_disconnectionTasks.ToArray());
        }

        private Action<string> Log { get; }
        private int WebsocketPort = 6001;
        private List<WebSocketConnection> Sockets { get; set; } = new List<WebSocketConnection>();
    }
}
