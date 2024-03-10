using DiscountSystem.Services;
using Microsoft.AspNetCore.SignalR;

namespace DiscountSystem
{
    public class DiscountCodeHub : Hub
    {

        private readonly IDiscountCodeService _codeManager;

        public DiscountCodeHub(IDiscountCodeService codeManager)
        {
            _codeManager = codeManager;
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (exception != null)
            {
                Console.WriteLine($"Connection with id {Context.ConnectionId} disconnected with error: {exception.Message}");
            }

            await base.OnDisconnectedAsync(exception);
        }


        public bool GenerateCodes(int count, byte length)
          =>  _codeManager.GenerateCodes(count, length);
        

        public byte UseCode(string code)
            =>  _codeManager.UseCode(code);


    }
}
