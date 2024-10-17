using Coordinator.Models.Contexts;
using Coordinator.Services;
using Coordinator.Services.Abstracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TwoPhaseCommitContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"));
});


builder.Services.AddHttpClient("OrderAPI", client => client.BaseAddress = new("https://localhost:7047"));
builder.Services.AddHttpClient("StockAPI", client => client.BaseAddress = new("https://localhost:7231"));
builder.Services.AddHttpClient("PaymentAPI", client => client.BaseAddress = new("https://localhost:7123"));

builder.Services.AddTransient<ITransactionService, TransactionService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/create-order-transaction", async (ITransactionService transactionService) =>
{
    // Phase 1 -> Prepare
    var transactionId = await transactionService.CreateTransactionAsync();
    await transactionService.PrepareServicesAsync(transactionId);
    bool transactionIsReady = await transactionService.CheckReadyServicesAsync(transactionId);

    if (transactionIsReady)
    {
        // Phase 2 => Commit
        await transactionService.CommitAsync(transactionId);
        bool transactionState = await transactionService.CheckTransactionStateServicesAsync(transactionId);

        if (!transactionState)
        {
            await transactionService.RollBackAsync(transactionId);
        }
    }
});

app.Run();
