using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using Domain.Abstract;
using Domain.Concrete;
using WebUI.Models;
using File = Domain.Entities.File;

namespace WebUI.Controllers
{
    
    public class FileController : Controller
    {
        private readonly IFileRepository _repository;
        private readonly IUserRepository _userRepository;

        public FileController(IFileRepository repository, IUserRepository userRepository)
        {
            this._repository = repository;
            this._userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        [Authorize]
        public ActionResult AddFile()
        {
            return View();
        }

        public ActionResult List()
        {
            var viewModel = new FileViewModel {Files = _repository.GetAll()};
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult List(string key)
        {
            if (key.IsEmpty()) return RedirectToAction("List");
            var viewModel = new FileViewModel
            {
                Files = _repository.GetByName(key),
                Key = key
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddFile(File file, HttpPostedFileBase uploadFile)
        {
            if (ModelState.IsValid && uploadFile != null)
            {
                /*
                byte[] fileData;
                using (var binaryReader = new BinaryReader(uploadFile.InputStream))
                {
                    fileData = binaryReader.ReadBytes(uploadFile.ContentLength);
                }
                file.Files = fileData;
                file.Name = uploadFile.FileName;
                file.Size = uploadFile.ContentLength;
                file.CreationDate=DateTime.Now;
                file.UserId= _userRepository.GetByEmail(User.Identity.Name).Id;
                */
                file.Size = uploadFile.ContentLength;
                file.Files = new byte[uploadFile.ContentLength];
                uploadFile.InputStream.Read(file.Files, 0, uploadFile.ContentLength);
                file.Name = uploadFile.FileName;
                file.CreationDate = DateTime.Now;
                file.UserId = _userRepository.GetByEmail(User.Identity.Name).Id;

                _repository.Create(file);

                TempData["message"] = $"{uploadFile.ContentLength} has been saved";
                return RedirectToAction("AddFile");
            }
            return View();
        }


    }
}