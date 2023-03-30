using Microsoft.AspNetCore.SignalR;

namespace eBoletimServer.API.SignalHub
{
    public class ResultsHub : Hub
    {
        public async Task StartCon(int studentId)
        {
            await Clients.Clients(this.Context.ConnectionId).SendAsync("startConResponse", "Conexão Iniciada: " + studentId);
        }
    }
}
