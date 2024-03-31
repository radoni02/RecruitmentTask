using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stack.Infrastructure.Data.Configuration;

internal sealed class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("tags");

        builder.HasKey(x => x.Id);

        builder.OwnsMany(t => t.Collectives, collectives =>
        {
            collectives.WithOwner().HasForeignKey(c => c.TagId);
            collectives.HasKey(c => c.Id);

            collectives.OwnsMany(c => c.ExternalLinks, externalLinks =>
            {
                externalLinks.WithOwner().HasForeignKey(ex => ex.CollectiveId);
                externalLinks.HasKey(ex => ex.Id);
            });
        });
    }
}
