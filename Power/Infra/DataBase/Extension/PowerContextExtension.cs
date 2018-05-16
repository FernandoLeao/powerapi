using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Power.Infra.DataBase.Extension
{
    public static class PowerContextExtension
    {
        public static void EnsureSeedData(this PowerContext context)
        {
            if (!context.Database.GetPendingMigrations().Any())
            {

                if (!context.Usinas.Any())
                {
                    context.Usinas.AddRange(AddUsinas());
                }

                if (!context.Agentes.Any())
                {
                    context.Agentes.AddRange(AddAgentes());
                }
                context.SaveChanges();

                if (!context.Equipamentos.Any())
                {
                    context.Equipamentos.AddRange(AddEquipamentos());
                }
                context.SaveChanges();

            }
        }

        private static List<Usina> AddUsinas()
        {
            return new List<Usina>()
            {
                new Usina(){Nome = "USINA1", CapacidadeGeracao =1000,ValorHora = 50},
                new Usina(){Nome = "USINA2", CapacidadeGeracao =500,ValorHora = 10},
                new Usina(){Nome = "USINA3", CapacidadeGeracao =200,ValorHora = 20},
            };
        }


        private static List<Agente> AddAgentes()
        {
            return new List<Agente>()
            {
                new Agente(){Nome = "AGENTE1", NecessidadeDiariaEnergia =500},
                new Agente(){Nome = "AGENTE2", NecessidadeDiariaEnergia =700},
                new Agente(){Nome = "AGENTE3", NecessidadeDiariaEnergia =300},
                new Agente(){Nome = "AGENTE4", NecessidadeDiariaEnergia =200}
            };
        }


        private static List<Equipamento> AddEquipamentos()
        {
            return new List<Equipamento>()
            {
                new Equipamento(){Nome = "EQUIP1",AgenteId = 1,CapacidadeTransmissao = 150,Ativo = true},
                new Equipamento(){Nome = "EQUIP2",AgenteId = 1,CapacidadeTransmissao = 200,Ativo = true},
                new Equipamento(){Nome = "EQUIP3",AgenteId = 1,CapacidadeTransmissao = 100,Ativo = true},
                new Equipamento(){Nome = "EQUIP4",AgenteId = 1,CapacidadeTransmissao = 200,Ativo = true},


                new Equipamento(){Nome = "EQUIP5",AgenteId = 2,CapacidadeTransmissao = 150,Ativo = true},
                new Equipamento(){Nome = "EQUIP6",AgenteId = 2,CapacidadeTransmissao = 200,Ativo = true},
                new Equipamento(){Nome = "EQUIP7",AgenteId = 2,CapacidadeTransmissao = 200,Ativo = true},
                new Equipamento(){Nome = "EQUIP8",AgenteId = 2,CapacidadeTransmissao = 400,Ativo = true},


                new Equipamento(){Nome = "EQUIP9",AgenteId = 3,CapacidadeTransmissao = 300,Ativo = true},
                new Equipamento(){Nome = "EQUIP10",AgenteId = 3,CapacidadeTransmissao = 200,Ativo = true},
                new Equipamento(){Nome = "EQUIP11",AgenteId =3,CapacidadeTransmissao = 150,Ativo = true},


                new Equipamento(){Nome = "EQUIP12",AgenteId = 4,CapacidadeTransmissao = 200,Ativo = true},
                new Equipamento(){Nome = "EQUIP13",AgenteId = 4,CapacidadeTransmissao = 150,Ativo = true},
                new Equipamento(){Nome = "EQUIP14",AgenteId = 4,CapacidadeTransmissao = 50,Ativo = true},
                new Equipamento(){Nome = "EQUIP15",AgenteId = 4,CapacidadeTransmissao = 100,Ativo = true},
                new Equipamento(){Nome = "EQUIP16",AgenteId = 4,CapacidadeTransmissao = 100,Ativo = true},
                new Equipamento(){Nome = "EQUIP17",AgenteId = 4,CapacidadeTransmissao = 50,Ativo = true},

            };
        }
    }
}
