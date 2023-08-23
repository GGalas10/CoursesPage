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
            _timer = new Timer(ClearDbFromCart, null, TimeSpan.Zero, TimeSpan.FromMinutes(60));
            await Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
        }
        private async void ClearDbFromCart(object state)
        {
            using (var scope = _scoopedFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<CoursesDbContext>();
                var carts = _context.Carts.ToList();
                var _cartRepository = scope.ServiceProvider.GetRequiredService<ICartRepository>();
                foreach (var cart in carts)
                {
                    if (cart.UpdatedAt.AddDays(7) <= DateTime.UtcNow)
                        await _cartRepository.DeleteCartAsync(cart.Id);
                }
            }
        }
    }
}
