﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using TPUM.ClientData.Model;
using TPUM.Dependencies.Model;

namespace TPUM.ClientData
{
    public class WebSocketController
    {
        public ClientWebSocketConnection _clientWebSocket;
        public Action<string> _connectionLogger;

        string _result = "";
        bool _parseResult = false;

        public WebSocketController()
        {
            _connectionLogger = message => _result = message;
        }

        public async Task<bool> Connect(Uri peer)
        {
            await WebSocketClient.Connect(peer, _connectionLogger);
            _clientWebSocket = (ClientWebSocketConnection)WebSocketClient._connectionSocket;
            _clientWebSocket.onMessage = message => OnInvokeMessage(message);
            return true;
        }

        public async Task<bool> SendTask(string newTask)
        {
            await _clientWebSocket.SendTask(newTask);
            _parseResult = true;
            return true;
        }

        private void OnInvokeMessage(string message)
        {
            if (_parseResult)
            {
                ParseMessege(message);
                _parseResult = false;
            }

            _result = message;
        }

        private void ParseMessege(string message)
        {
            MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(message));

            try
            {
                SProduct deserializedObject = new SProduct();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(deserializedObject.GetType());
                deserializedObject = serializer.ReadObject(memoryStream) as SProduct;

                DbContext.Instance.SProducts.Add(deserializedObject);
            }
            catch (SerializationException e)
            {
                try
                {
                    List<SProduct> deserializedObject = new List<SProduct>();
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<SProduct>));

                    memoryStream.Position = 0;
                    deserializedObject = serializer.ReadObject(memoryStream) as List<SProduct>;

                    foreach(SProduct prod in deserializedObject)
                    {
                        DbContext.Instance.SProducts.Add(prod);
                    }
                }
                catch (SerializationException ee)
                {
                    try
                    {
                        SClient deserializedObject = new SClient();
                        DataContractJsonSerializer serializer = new DataContractJsonSerializer(deserializedObject.GetType());
                        deserializedObject = serializer.ReadObject(memoryStream) as SClient;

                        DbContext.Instance.SClients.Add(deserializedObject);
                    }
                    catch (SerializationException eeee)
                    {
                        return;
                    }
                }                       
            }

            memoryStream.Close();
        }
    }
}
