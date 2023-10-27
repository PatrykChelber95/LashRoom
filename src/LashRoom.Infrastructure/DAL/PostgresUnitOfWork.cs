namespace LashRoom.Infrastructure.DAL
{
    internal sealed class PostgresUnitOfWork : IUnitOfWork
    {
        private readonly LashroomDbContext _dbContext;

        public PostgresUnitOfWork(LashroomDbContext context)
        {
            _dbContext = context;
        }
        public async Task ExecuteAsync(Func<Task> action)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await action();
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
