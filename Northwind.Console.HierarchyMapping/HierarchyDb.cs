﻿using Microsoft.EntityFrameworkCore; // DbSet<T>

namespace Northwind.Console.HierarchyMapping;

public class HierarchyDb : DbContext
{
    public DbSet<Person>? People { get; set; }
    public DbSet<Student>? Students { get; set; }
    public DbSet<Employee>? Employees { get; set; }

    public HierarchyDb(DbContextOptions<HierarchyDb> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
        //.UseTphMappingStrategy();
        //.UseTptMappingStrategy();
        .UseTpcMappingStrategy()
        .Property(person => person.Id)
        .HasDefaultValueSql("NEXT VALUE FOR [PersonIds]");

        modelBuilder.HasSequence<int>("PersonIds", builder =>
        {
            builder.StartsAt(4);
        });

        // Populate database with sample data.

        Student p1 = new() { Id = 1, Name = "Roamn Roy", Subject = "History" };

        Employee p2 = new() { Id = 2, Name = "Kendall Roy", HireDate = new(year: 2014, month: 4, day: 2) };

        Employee p3 = new() { Id = 3, Name = "Siobhan Ray", HireDate = new(2020, 9, 12) };

        modelBuilder.Entity<Student>().HasData(p1);

        modelBuilder.Entity<Employee>().HasData(p2, p3);
    }
}
