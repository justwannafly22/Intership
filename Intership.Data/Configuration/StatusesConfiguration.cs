using System;
using Intership.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intership.Data.Configuration
{
    public class StatusesConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(
                new Status()
                {
                    Id = new Guid("38b4bbaa-2da2-4cec-b6c2-a84f9dd3fa32"),
                    StatusInfo = "New"
                },
                new Status()
                {
                    Id = new Guid("95b2d4fc-5356-42d8-9087-f1e292bd6bfb"),
                    StatusInfo = "Waiting to processing by agent"
                },
                new Status()
                {
                    Id = new Guid("d3a5ea06-44b2-43e8-89c1-8d5a17bd7791"),
                    StatusInfo = "Processing by agent"
                },
                new Status()
                {
                    Id = new Guid("cbdfc5bd-82a6-4a8f-b8ec-71a3279f2e07"),
                    StatusInfo = "Waiting to register the completing repair"
                },
                new Status()
                {
                    Id = new Guid("23ea6ac5-a0a1-4da2-9102-5e7c472aa663"),
                    StatusInfo = "Completed"
                }
            );
        }
    }
}
