using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reactive;
using System.Reactive.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TPUM.Logic;
using TPUM.Logic.Services;

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

        private CyclicService _cyclicTimer;
        private IObservable<EventPattern<CyclicEvent>> _tickObservable;
        private IDisposable _observer;
        string ping = "000";

        public async Task InitServerAsync()
        {
            Log($"Web socket server listening on port: {WebsocketPort}");
            await WebSocketServer.Server(WebsocketPort, async _ws => await InitConnectionAsync(_ws));
            SetReactTimer();
        }

        private async Task InitConnectionAsync(WebSocketConnection ws)
        {
            Sockets.Add(ws);
            initMessageHandler(ws);
            initErrorHandler(ws);
            await WriteAsync(ws, "Connected");
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
            Log($"[Writing message]: {message}");
            await ws.SendAsync(message);
        }

        private async Task SendAll(string message)
        {
            foreach(WebSocketConnection ws in Sockets)
            {
                await ws.SendAsync(message);
            }
        }

        private void initMessageHandler(WebSocketConnection ws)
        {
            ws.onMessage = async (data) =>
            {
                Log($"[Received message]: {data}");
                //Resolve message
                MessageResolver messageResolver = new MessageResolver(Log);
                await ws.SendAsync(messageResolver.Resolve(data));
            };
        }

        public async void SetReactTimer()
        {
            SetReactiveTimer(TimeSpan.FromSeconds(2));
        }

        public void SetReactiveTimer(TimeSpan period)
        {
            _cyclicTimer = new CyclicService(period);
            _tickObservable = Observable.FromEventPattern<CyclicEvent>(_cyclicTimer, "Tick");
            _observer = _tickObservable.Subscribe(x => SendAll(ping));

            _cyclicTimer.Start();
        }

        public void Dispose()
        {
            Log($"Shuting down the communication manager");
            List<Task> _disconnectionTasks = new List<Task>();
            foreach (WebSocketConnection _item in Sockets)
                _disconnectionTasks.Add(_item.DisconnectAsync());
            Task.WaitAll(_disconnectionTasks.ToArray());
        }

        private Action<string> Log { get; }
        private int WebsocketPort = 8081;
        private List<WebSocketConnection> Sockets { get; set; } = new List<WebSocketConnection>();
    }
}
