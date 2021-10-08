using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCL.Services
{
    public interface IFolderService
    {
        void createFolder(string path);
        void deleteFolder(string path);
    }
}
