using Fleck;
using Newtonsoft.Json;
using Plc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebSocketGrafana
{
    public class WebSocketRelay : IDisposable
    {
        private readonly IList<IWebSocketConnection> openSockets = new List<IWebSocketConnection>();
        private readonly PlcTwinController plcTwin;
        private readonly WebSocketServer webSocketServer;

        public WebSocketRelay(int Port, PlcTwinController PlcTwin)
        {
            webSocketServer = new WebSocketServer($"ws://127.0.0.1:{Port}") { RestartAfterListenError = true };
            plcTwin = PlcTwin;
        }

        private bool webServerStarted = false;
        public void StartServer()
        {
            if (!webServerStarted)
            {
                webSocketServer.Start(socket =>
                {
                    socket.OnError = (err) => Console.WriteLine(err);
                    socket.OnOpen = () =>
                    {
                        if (!socket.ConnectionInfo.Path.EndsWith("$"))
                            socket.Close();
                        lock (openSockets)
                        {
                            openSockets.Add(socket);
                        }
                        Console.WriteLine($"New WebSocket for {PathToSymbol(socket.ConnectionInfo.Path)} Total: {openSockets.Count}");
                    };
                    socket.OnClose = () =>
                    {
                        lock (openSockets)
                        {
                            openSockets.Remove(socket);
                        }
                        Console.WriteLine($"WebSocket for {PathToSymbol(socket.ConnectionInfo.Path)} closed Total: {openSockets.Count}");
                    };
                });
                webServerStarted = true;
            }
            Task.Run(PublishPlcVariablesAsync);
        }

        private async Task PublishPlcVariablesAsync()
        {
            while (true)
            {
                Parallel.ForEach(openSockets, (socket) =>
                {
                    var symbol = PathToSymbol(socket.ConnectionInfo.Path);
                    var plcVarValue = GetPlcValue(symbol);
                    // lock (openSockets)
                    {
                        socket.Send(Jsonify(plcVarValue));
                    }
                });
                await Task.Delay(75);
            }
        }

        private static string PathToSymbol(string path)
        {
            var trimAndSplit = path.TrimStart('.').TrimEnd('$').Split('/');
            var joined = string.Join('.', trimAndSplit);
            return joined.TrimStart('.');
        }

        private object GetPlcValue(string symbol)
        {
            object toReturn;
            try
            {
                toReturn = plcTwin.GetPropertyValue(symbol + ".Cyclic");
            }
            catch (Exception)
            {
                toReturn = $"{symbol} not found";
            }
            return toReturn;
        }

        private static string Jsonify(object value) => JsonConvert.SerializeObject(new
        {
            time = NowUnixTime(),
            value = value
        });

        private static long NowUnixTime() => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public void Dispose() => webSocketServer.Dispose();

    }
}
