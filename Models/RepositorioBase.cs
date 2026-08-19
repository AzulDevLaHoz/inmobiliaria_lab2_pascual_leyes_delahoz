using System;
using Microsoft.Extensions.Configuration;

namespace inmobiliaria_lab2_pascual_leyes_delahoz_clavero.Models
{
    public abstract class RepositorioBase
    {
        protected readonly IConfiguration configuration;
        protected readonly String connectionString;

        protected RepositorioBase(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration["ConnectionStrings:DefaultConnection"];
        }
    }
}