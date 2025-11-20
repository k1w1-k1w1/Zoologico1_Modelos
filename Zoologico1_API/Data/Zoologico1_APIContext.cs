using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoologico1_Modelos;

public class Zoologico1_APIContext : DbContext
{
    public Zoologico1_APIContext(DbContextOptions<Zoologico1_APIContext> options)
        : base(options)
    {
    }

    public DbSet<Raza> Razas { get; set; } = default!;

    public DbSet<Especie> Especies { get; set; } = default!;

    public DbSet<Animal> Animales { get; set; } = default!;
}
