using ClassLibrary.Repositories.BorrowOrderRepositories;
using Microsoft.Extensions.Logging;

namespace ClassLibrary.Services;

public interface IEmailService
{
    Task DoWork(CancellationToken stoppingToken);
}

public class EmailService(ILogger<EmailService> logger, IBOrderRepositoryRead repository):IEmailService
{
    private int _executionCount = 0;

    public async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _executionCount++;

            logger.LogInformation("Scoped Processing Service is working. Count: {Count}", _executionCount);

            await Task.Delay(86400000, stoppingToken);//does this only once a day

            var orders = await repository.GetBOrders();
            var ordersArr = orders.ToArray();

            foreach (var order in ordersArr)
            {
                if (order != null && order.CloseDate > DateTime.Now && order.CloseDate < DateTime.Now.AddDays(1))
                {
                    //SendEmail(order); // send Email that he needs to return the book
                }
            }
        }

    }
}

