using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Power.Infra.DataBase.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Infra.DataBase
{
    public class PowerContext : DbContext
    {

        public PowerContext(DbContextOptions<PowerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Usina> Usinas { get; set; }
        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Equipamento> Equipamentos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.RegisterEntityMapping<Usina, UsinaMap>();
            builder.RegisterEntityMapping<Agente, AgenteMap>();
            builder.RegisterEntityMapping<Equipamento, EquipamentoMap>();
        }
    }
}
