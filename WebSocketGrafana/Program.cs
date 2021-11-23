using Plc;
using System;
using Vortex.Adapters.Connector.Tc3.Adapter;

namespace WebSocketGrafana
{
    class Program
    {
        static void Main(string[] args)
        {
            var plc = new PlcTwinController(Tc3ConnectorAdapter.Create(null, 851, true));
            var websocketRelay = new WebSocketRelay(5002, plc);
            plc.Connector.BuildAndStart();
            websocketRelay.StartServer();
            Console.ReadLine();
        }
    }
}