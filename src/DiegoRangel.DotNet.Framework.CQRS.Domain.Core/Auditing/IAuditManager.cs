﻿using System;
using DiegoRangel.DotNet.Framework.CQRS.Domain.Core.Entities;

namespace DiegoRangel.DotNet.Framework.CQRS.Domain.Core.Auditing
{
    public interface IAuditManager
    {
        void AuditCreation<TEntityPrimaryKey>(IDomainEntity entity) 
            where TEntityPrimaryKey : struct;

        void AuditCreation(IDomainEntity entity, params Type[] keyTypes);

        void AuditModification<TEntityPrimaryKey>(IDomainEntity entity)
            where TEntityPrimaryKey : struct;

        void AuditModification(IDomainEntity entity, params Type[] keyTypes);

        void AuditDeletion<TEntityPrimaryKey>(IDomainEntity entity)
            where TEntityPrimaryKey : struct;

        void AuditDeletion(IDomainEntity entity, params Type[] keyTypes);
    }
}