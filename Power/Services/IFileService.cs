using Power.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Power.Services
{
    public interface IFileService
    {
         MemoryStream CriarStream(IEnumerable<UsinaModel> usinas);
    }
}
