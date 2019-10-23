﻿using DiegoRangel.DotNet.Framework.CQRS.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiegoRangel.DotNet.Framework.CQRS.Infra.Data.EFCore.Mappings
{
    public abstract class EntityMap<TEntity, TPrimaryKey> : IEntityTypeConfiguration<TEntity>
        where TPrimaryKey : struct
        where TEntity : Entity<TPrimaryKey>
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Ignore(x => x.ValidationResult);

            ConfigureEntityBuilder(builder);
        }

        public abstract void ConfigureEntityBuilder(EntityTypeBuilder<TEntity> builder);
    }

    public abstract class EntityMap<TEntity> : EntityMap<TEntity, int>
        where TEntity : Entity<int>
    {

    }
}