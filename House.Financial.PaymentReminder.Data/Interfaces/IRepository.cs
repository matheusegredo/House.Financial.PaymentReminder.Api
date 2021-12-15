namespace House.Financial.PaymentReminder.Data.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetById(int id);

        Task UpdateAsync(TEntity entity);
    }
}
