using Microsoft.AspNetCore.SignalR;

namespace eBoletimServer.API.SignalHub
{
    public class BaseHub : Hub
    {
        public async Task StartCon(string startupText)
        {
            string returnString;

            if (startupText == "client") returnString = "server";
            else returnString = "unauthorized";

            await Clients.Clients(this.Context.ConnectionId).SendAsync("startConResponse", returnString);
        }
    }
}
