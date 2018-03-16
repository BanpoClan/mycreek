using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace MyCreek.EntityFramework.Repositories
{
    public abstract class MyCreekRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<MyCreekDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MyCreekRepositoryBase(IDbContextProvider<MyCreekDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class MyCreekRepositoryBase<TEntity> : MyCreekRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected MyCreekRepositoryBase(IDbContextProvider<MyCreekDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
