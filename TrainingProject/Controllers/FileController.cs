using EntitiesCL;
using ServiceCL.Services;
using System;
using System.Web.Mvc;
using TrainingProject.Models;

namespace TrainingProject.Controllers
{
    public class FileController : Controller
    {

        private IFileService _fileServisce;
        private IFolderService _folderService;
        private IRouteService _routeService;

        public FileController(IFileService fileService, IFolderService folderService, IRouteService routeService)
        {
            _fileServisce = fileService;
            _folderService = folderService;
            _routeService = routeService;
        }


        [Route("~/C/{*catchall}")]
        public ActionResult FileOut()
        {

            string path = _routeService.handleRoute(Request.Path, Request.Path.Length);

          
            FilesEntity filesEntity = new FilesEntity();

            filesEntity = _fileServisce.ListFiles(path, filesEntity);


            FileModel files = new FileModel()
            {
                NameFiles = filesEntity.NameFiles,
                NameFolders = filesEntity.NameFolders,
                PathToContent = filesEntity.PathToContent
            };

            return View(files);
        }

        public ActionResult DeleteFile(string fileName , string path)
        {
            string pathToContent = $@"{path}/{fileName}" ;

            _fileServisce.RemoveFile(pathToContent);
        
            path = _routeService.handleRoute(path, path.Length);
          
            return Redirect($"~/C/{path}");
        }

        public ActionResult CreateFile(string fileName, string pathToFile)
        {
            string pathToContent = $@"{pathToFile}/{fileName}";

            _fileServisce.AddFile(pathToContent);

            pathToFile = _routeService.handleRoute(pathToFile, pathToFile.Length);

            return Redirect($"~/C/{pathToFile}");
        }


        [HttpPost]
        public ActionResult CreateFolder(string folderName, string pathToFolder)
        {

            string path = $@"{pathToFolder}/{folderName}";

            _folderService.createFolder(path); 

            pathToFolder = _routeService.handleRoute(pathToFolder, pathToFolder.Length);

            return Redirect($"~/C/{pathToFolder}");
        }
    }
}
