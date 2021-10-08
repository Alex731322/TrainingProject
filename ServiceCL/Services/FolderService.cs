using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCL.Services
{
    public class FolderService : IFolderService
    {
        public void createFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void deleteFolder(string path)
        {
            throw new NotImplementedException();
        }
    }
}
