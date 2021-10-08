using EntitiesCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCL.Services
{
    public interface IFileService
    {
        void RemoveFile(string path);
        void AddFile(string path);
        FilesEntity ListFiles(string path, FilesEntity model);
    }
}
