using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Power.Model;

namespace Power.Services
{
    public class FileService : IFileService
    {
        public MemoryStream CriarStream(IEnumerable<UsinaModel> usinas)
        {
            var fileStringBuilder = new StringBuilder();
            foreach (var usina in usinas)
            {
                fileStringBuilder.Append(string.Format("{0};{1}", usina.Nome, usina.CapacidadeGeracao));
                fileStringBuilder.Append("\n");
                foreach (var agente in usina.Agentes){
                    fileStringBuilder.Append("\t");
                    fileStringBuilder.Append(string.Format("{0};{1}", agente.Value.Nome, agente.Value.NecessidadeAgente));
                    fileStringBuilder.Append("\n");
                    foreach (var eq in agente.Value.Equipamentos) { 

                        fileStringBuilder.Append("\t\t"); 
                        fileStringBuilder.Append(string.Format("{0};{1};{2};{3}", eq.Nome, eq.CapacidadeEquipamento, eq.CargaEnviada, eq.Custo));
                        fileStringBuilder.Append("\n");

                    }
                }
            }

            //todo: add some data from your database into that string:
            var string_with_your_data = fileStringBuilder.ToString(); ;

            var byteArray = Encoding.ASCII.GetBytes(string_with_your_data);
            var stream = new MemoryStream(byteArray);

            return stream;
        }
    }
}
