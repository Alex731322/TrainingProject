using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesCL
{
    public class FilesEntity
    {
        public List<string> NameFiles { get; set; } = new List<string>();
        public List<string> NameFolders { get; set; } = new List<string>();
        public string PathToContent { get; set; }
    }
}
