using Microsoft.EntityFrameworkCore;
using System;
using DotNetEnv;
using p3_csharp_orm.Data;

class Program
{
    static void Main(string[] args)
    {
        // Cargar variables desde .env
        Env.Load();
        var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");

        var optionsBuilder = new Microsoft.EntityFrameworkCore.DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        using var context = new AppDbContext(optionsBuilder.Options);

        Console.WriteLine(context.Database.CanConnect()
            ? "Conexión exitosa a PostgreSQL."
            : "No se pudo conectar a la base de datos.");
    }
}
