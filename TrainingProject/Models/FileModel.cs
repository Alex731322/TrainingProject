using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingProject.Models
{
    public class FileDirectoryModel
    {
        public List<string> NameFiles { get; set; } = new List<string>();
        public List<string> NameFolders { get; set; } = new List<string>();
        public string PathToContent { get; set; }
    }
}