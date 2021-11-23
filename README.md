# Streaming from PLC to Grafana with Inxton

![grafana-stream-gif-2.gif](/assets/grafana-stream-gif-2.gif)
## Requirements 

- Grafana - [link](https://grafana.com/docs/grafana/latest/getting-started/getting-started/)
- Inxton developer license - [link](https://inxton.com/)
- hse Streaming Source - [link](https://github.com/hse-electronics/hse-streaming-source)
- .NET SDK - [link](https://dotnet.microsoft.com/download/visual-studio-sdks)
- TwinCAT 3 installed 

## How to run

1. Install hse Stream Source by unpacking from `.\assets\` it to  `path_to_grafana\plugins-bundled\internal\`.
1. Add hse Stream Source as Data Source in Grafana - [grafana docs](https://grafana.com/docs/grafana/latest/datasources/add-a-data-source/).
1. Open the solution, activate configuration, run the PLC.
1. Run the `WebSocketGrafana` project.
1. Open Grafana.  [link](https://grafana.com/docs/grafana/latest/getting-started/getting-started/)
1. Create new dashboard. Select the hse Stream source in the panel. 
    [grafana docs](https://grafana.com/docs/grafana/latest/panels/queries/#data-source-selector). It will say that the datasource is unsigned. Don't worry about that.
1. To server field write `ws://127.0.0.1:5002/MAIN/Data/IntValue$` 
1. You should see the value live.

If you want to use the dashoard in the Gif import the dashboard from json (located in assets\Inxton-Grafan.json) [grafana docs](https://grafana.com/docs/grafana/latest/dashboards/export-import/#import-dashboard).

## What is going on

When you enter `ws://127.0.0.1:5002/MAIN/Data/IntValue$` to Grafana a WebSocket connection is estabilshed between the Grafana panel and the server app. 

The server app will parse the input `MAIN/Data/IntValue$` into `MAIN.Data.IntValue` and read the value from PLC and publish it to the websocket. 

### URL explained

- `ws://127.0.0.1` Address of the websocket server
- `:5002` Port
- `/MAIN/Data/IntValue` path to the variable 
- `$` terminating character 

## Adding new variable in the PLC

When you add a variable to the PLC, you need to run the Inxton builder and restart the app.