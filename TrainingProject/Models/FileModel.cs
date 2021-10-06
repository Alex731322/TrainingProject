using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingProject.Models
{
    public class FileDirectoryModel
    {
        public List<string> NameFile { get; set; } = new List<string>();
        public List<string> NameFolder { get; set; } = new List<string>();
        public string PathToContent { get; set; }
        public string FileContent { get; set; }
    }
}