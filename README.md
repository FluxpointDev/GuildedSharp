# GuildedSharp
A library for connecting to the Guilded official API with a bot account.
Http is only supported atm, websocket will be coming soon.

You can check out my [Guilded Server](https://www.guilded.gg/fluxpoint/groups/rD45Zyyd/channels/063d2192-ae95-4b59-adfb-7fe6d8f39618/chat) or visit our [Website](https://fluxpoint.dev)

# Bot Access
This library is only used for the official API and will never support userbots or abuse.
You need to apply for beta access to get full bot accounts [Apply Here](https://www.guilded.gg/r/zzQR46qKZE?i=x4ooeNo4)

# Install
You can install the nuget package here to use the API https://www.nuget.org/packages/GuildedSharp
Here is an example of how to use it.
```cs
static void Main(string[] args)
{
    Start().GetAwaiter().GetResult();
}

public static GuildedClient Client;

public static async Task Start()
{
    Client = new GuildedClient(ClientMode.Websocket, "Bot Token");
           
    await Client.Rest.SendMessageAsync("Channel ID", "Message here :D");
           
    await Task.Delay(-1);
}```
