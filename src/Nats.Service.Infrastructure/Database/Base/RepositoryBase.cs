using Microsoft.EntityFrameworkCore;
using Nats.Service.Infrastructure.Base;
using Nats.Setvice.Domain;
using Nats.Setvice.Domain.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nats.Service.Domain.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected AppDbContext RepositoryContext { get; set; }

        public RepositoryBase(AppDbContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public async Task<List<T>> FindAllAsync()
        {
            return await this.RepositoryContext.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await this.RepositoryContext.Set<T>().Where(x => !x.IsDeleted).Where(expression).ToListAsync();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await this.RepositoryContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<T> CreateAsync(T entity)
        {
            if (await Exists(entity.Guid))
                throw new InvalidOperationException(nameof(Const.Message.ItemWasCreated));

            await this.RepositoryContext.Set<T>().AddAsync(entity);

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (await Exists(entity.Guid))
                throw new InvalidOperationException(nameof(Const.Message.ItemWasCreated));
           
            this.RepositoryContext.Set<T>().Update(entity);
           
            await this.RepositoryContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            if (!(await Exists(entity.Guid)))
                throw new InvalidOperationException(nameof(Const.Message.ItemNotFound));
           
            entity.Delete();

            this.RepositoryContext.Set<T>().Update(entity);
           
            await this.RepositoryContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await this.RepositoryContext.Set<T>().AnyAsync(x => x.Guid == id && !x.IsDeleted);
        }
        
        public override int GetHashCode()
        {
            return (GetType().ToString()).GetHashCode();
        }

       
    }
}
