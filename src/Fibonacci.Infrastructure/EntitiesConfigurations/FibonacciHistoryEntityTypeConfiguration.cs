using Fibonacci.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Fibonacci.Infrastructure.EntitiesConfigurations
{
    internal sealed class FibonacciHistoryEntityTypeConfiguration : IEntityTypeConfiguration<RequestedNumbersHistory>
    {
        public void Configure(EntityTypeBuilder<RequestedNumbersHistory> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property<int>("RequestedNumber").IsRequired();
            builder.Property<int>("Result").IsRequired();
            builder.Property<DateTime>("RequestedDateTime").IsRequired();
        }
    }
}