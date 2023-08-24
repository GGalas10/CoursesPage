using Courses.Core.Repositories;
using Courses.Infrastructure.Database;
using Courses.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Courses.API.HostedService
{
    public class CartHostedService : IHostedService, IDisposable
    {
        private readonly IServiceScopeFactory _scoopedFactory;
        private Timer _timer;
        public CartHostedService(IServiceScopeFactory scoopedFactory)
        {
            _scoopedFactory = scoopedFactory;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync("Starting cart hosted service");
            _timer = new Timer(ClearDbFromCart, null, TimeSpan.Zero, TimeSpan.FromMinutes(60));
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
        }
        private async void ClearDbFromCart(object? state)
        {
            var scope = _scoopedFactory.CreateScope();
            var _cartRepository = scope.ServiceProvider.GetRequiredService<ICartRepository>();
            await _cartRepository.ClearCartFromDatabase();
        }
    }
}
