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

            string[] folderspaths = Directory.GetDirectories($@"C:/{path}");
            string[] filespaths = Directory.GetFiles($@"C:/{path}");


            FileDirectoryModel files = new FileDirectoryModel();

            if(String.IsNullOrEmpty(folderspaths[1]))
            {
                folderspaths[0] = String.Empty;
            }

            files.PathToContent = Path.GetDirectoryName(folderspaths[0]);

            foreach (string filepath in filespaths)
            {
                files.NameFile.Add(Path.GetFileName(filepath));
            }
            

            foreach(string folderPath in folderspaths)
            {
                files.NameFolder.Add(Path.GetFileName(folderPath));
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

            return Redirect("~/C/Files");
        }

        public ActionResult CreateFile(string fileName, string path)
        {
            string pathToContent = $@"{path}/{fileName}";

            using (FileStream fstream = new FileStream(pathToContent, FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes("Alena is the best sister in the world");
                fstream.Write(array, 0, array.Length);

            }

            return Redirect("~/C/Files");
        }


        [HttpPost]
        public ActionResult CreateFolder(string folderName)
        {

            string folder = $@"C:/Files/{folderName}";
            
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
                ViewBag.Message = "Folder " + folderName.ToString() + " created successfully!";
            }
            else
            {
                ViewBag.Message = "Folder " + folderName.ToString() + "  already exists!";
            }
            return Redirect("~/C/Files");
        }

        
    }
}