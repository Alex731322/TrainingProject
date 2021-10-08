using EntitiesCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCL.Services
{
    public class FileService : IFileService
    {
        public void AddFile(string path)
        {

            if (!File.Exists(path))
            {
                using (FileStream fstream = new FileStream(path, FileMode.Create))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes("Something");
                    fstream.Write(array, 0, array.Length);

                }
            }

            
        }

        public FilesEntity ListFiles(string path, FilesEntity files)
        {
            string[] folderspaths = Directory.GetDirectories($@"C:/{path}");
            string[] filespaths = Directory.GetFiles($@"C:/{path}");

            files.PathToContent = $@"C:/{path}";


            foreach (string filepath in filespaths)
            {
                files.NameFiles.Add(Path.GetFileName(filepath));
            }


            foreach (string folderPath in folderspaths)
            {
                files.NameFolders.Add(Path.GetFileName(folderPath));
            }

            return files;
        }

        public void RemoveFile(string path)
        {
            FileInfo fileInf = new FileInfo(path);

            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }
    }
}
