﻿using DiegoRangel.DotNet.Framework.CQRS.Domain.Core.Auditing;
using DiegoRangel.DotNet.Framework.CQRS.Domain.Core.Repositories.Segregations;

namespace DiegoRangel.DotNet.Framework.CQRS.Domain.Core.Repositories.Agregations
{
    public interface IDeletionAuditedRepository<TEntity, in TEntityKey, TUserKey> : 
        ICrudRepository<TEntity, TEntityKey>,
        ISoftDeletableRepository<TEntity, TEntityKey>
        where TEntity : IDeletionAudited<TEntityKey, TUserKey>
        where TUserKey : struct
    {

    }

    public interface IDeletionAuditedRepository<TEntity> : IDeletionAuditedRepository<TEntity, int, int>
        where TEntity : IDeletionAudited<int, int>
    {

    }
}