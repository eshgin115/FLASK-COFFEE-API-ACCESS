﻿using APICOFFE.Contracts.Identity;
using APICOFFE.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APICOFFE.Database.Configurations
{
    public class RoleConfigurations : IEntityTypeConfiguration<Role>
    {

        private int _idCounter = 1;

        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
               .ToTable("Roles");


            builder
                .HasData(
                    new Role
                    {
                        Id = _idCounter++,
                        Name = RoleNames.ADMIN,
                        CreatedAt = Convert.ToDateTime("2023-01-24"),
                        UpdatedAt = Convert.ToDateTime("2023-01-24")
                    },
                    new Role
                    {
                        Id = _idCounter++,
                        Name = RoleNames.MODERATOR,
                        CreatedAt = Convert.ToDateTime("2023-01-24"),
                        UpdatedAt = Convert.ToDateTime("2023-01-24")
                    },
                    new Role
                    {
                        Id = _idCounter++,
                        Name = RoleNames.HR,
                        CreatedAt = Convert.ToDateTime("2023-01-24"),
                        UpdatedAt = Convert.ToDateTime("2023-01-24")
                    },
                    new Role
                    {
                        Id = _idCounter++,
                        Name = RoleNames.CLIENT,
                        CreatedAt = Convert.ToDateTime("2023-01-24"),
                        UpdatedAt = Convert.ToDateTime("2023-01-24")
                    }
                );
        }
    }
}
