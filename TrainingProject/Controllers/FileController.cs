using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrainingProject.Models;

namespace TrainingProject.Controllers
{
    public class FileController : Controller
    {


        [Route("~/C/{*catchall}")]
        public ActionResult FileOut()
        {

            string path = Request.Path.Length > 3 ? Request.Path.Substring(3).ToString() :
                                                            String.Empty;

            FileDirectoryModel files = new FileDirectoryModel();

            string[] folderspaths = Directory.GetDirectories($@"C:/{path}");
            string[] filespaths = Directory.GetFiles($@"C:/{path}");

            files.PathToContent = $@"C:/{path}";

            if (Directory.GetFiles($@"C:/{path}").Length == 0)
            {
                return HttpNotFound(); 
            }


            foreach (string filepath in filespaths)
            {
                files.NameFiles.Add(Path.GetFileName(filepath));
            }
            

            foreach(string folderPath in folderspaths)
            {
                files.NameFolders.Add(Path.GetFileName(folderPath));
            }
            

            return View(files);
        }

        public ActionResult DeleteFile(string fileName , string path)
        {
            string pathToContent = $@"{path}/{fileName}" ;


            FileInfo fileInf = new FileInfo(pathToContent);

            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
            path = path.Length > 3 ? path.Substring(3).ToString() :
                                                            String.Empty;
            return Redirect($"~/C/{path}");
        }

        public ActionResult CreateFile(string fileName, string pathToFile)
        {
            string pathToContent = $@"{pathToFile}/{fileName}";

            using (FileStream fstream = new FileStream(pathToContent, FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes("Something");
                fstream.Write(array, 0, array.Length);

            }

            pathToFile = pathToFile.Length > 3 ? pathToFile.Substring(3).ToString() : String.Empty;

            return Redirect($"~/C/{pathToFile}");
        }


        [HttpPost]
        public ActionResult CreateFolder(string folderName, string pathToFolder)
        {

            string folder = $@"{pathToFolder}/{folderName}";
            
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                ViewBag.Message = "Folder " + folderName.ToString() + " created successfully!";
            }
            else
            {
                ViewBag.Message = "Folder " + folderName.ToString() + "  already exists!";
            }

            pathToFolder = pathToFolder.Length > 3 ? pathToFolder.Substring(3).ToString() :
                                                            String.Empty;

            return Redirect($"~/C/{pathToFolder}");
        }
    }
}
