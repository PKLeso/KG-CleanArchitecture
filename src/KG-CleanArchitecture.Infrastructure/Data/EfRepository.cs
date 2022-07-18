using Ardalis.Specification.EntityFrameworkCore;
using KG_CleanArchitecture.SharedKernel.Interfaces;

namespace KG_CleanArchitecture.Infrastructure.Data;

// inherit from Ardalis.Specification type
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
  public EfRepository(AppDbContext dbContext) : base(dbContext)
  {
  }
}
