using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BusinessLogicLayer;
using BusinessLogicLayer.Models;
using DataAccessLayer.Entities;
using FileStorage.Models;
using FileStorage.Resources;
using PagedList;

namespace FileStorage.Controllers
{
    public class FileController : Controller
    {
        private FileService fileService;
        private UserManager userManager;
        private const int PageSize = 9;

        public FileController()
        {
            fileService = new FileService();
            userManager = new UserManager();
        }

        [Authorize]
        [HttpGet]
        public ActionResult LoadFile()
        {
            ViewData["FormTitle"] = MessagesResource.AddFileTitle;
            ViewData["BtnSubmitTitle"] = MessagesResource.AddFileSubmitTitle;
            var allRoles = Mapper.Map<IEnumerable<Role>, IEnumerable<RoleViewModel>>(userManager.GetAllRoles());
            var fileModel = new FileLoadViewModel { IsPublic = true };
            fileModel.VisibleForRole = allRoles.Select(role => new CheckboxRoleViewModel(role, true)).ToList();

            return PartialView(fileModel);
        }

        public ActionResult Gallery(int page = 1, string imageName = null)
        {
            ViewData["SectionImages"] = imageName == null ? "AllImages" : string.Empty;
            var curUser = Request.IsAuthenticated ? userManager.FindUser(HttpContext.User.Identity.Name) : null;
            var images = Mapper.Map<IEnumerable<FileInfoDTO>, IEnumerable<ImagePreviewViewModel>>(fileService.GetAllAvailableFiles(curUser));
            if (imageName != null)
            {
                images = FilterImages(images, imageName);
            }

            return View(images.ToPagedList(page, PageSize));
        }

        [Authorize]
        public ActionResult MyImages(int page = 1)
        {
            ViewData["SectionImages"] = "UserImages";
            var curUser = userManager.FindUser(HttpContext.User.Identity.Name);
            var images = Mapper.Map<IEnumerable<FileInfoDTO>, IEnumerable<ImagePreviewViewModel>>(fileService.GetUserFiles(curUser));
            return View("Gallery", images.ToPagedList(page, PageSize));
        }

        [Authorize(Roles="Admin,Moderator")]
        public ActionResult EditFile(int fileId)
        {
            ViewData["FormTitle"] = MessagesResource.EditFileTitle;
            ViewData["BtnSubmitTitle"] = MessagesResource.EditFileSubmitTitle;
            var allRoles = Mapper.Map<IEnumerable<Role>, IEnumerable<RoleViewModel>>(userManager.GetAllRoles());
            var file = fileService.FindFile(fileId);
            var viewFile = Mapper.Map<FileDTO, FileLoadViewModel>(file);
            viewFile.VisibleForRole = allRoles.Select(role => new CheckboxRoleViewModel(role, file.RolesId.Contains(role.Id))).ToList();
            viewFile.Content = (HttpPostedFileBase)new MemoryPostedFile(file.Content, file.Name);
            return PartialView("LoadFile", viewFile);
        }

        [HttpGet]
        public ActionResult Image(int imgId)
        {
            var file = fileService.FindFile(imgId);
            if (file == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (fileService.UserHasAccessToFile(file.Id, HttpContext.User.Identity.Name))
            {
                var image = Mapper.Map<FileDTO, ImageDetailsViewModel>(file);
                return View(image);
            }

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<ImagePreviewViewModel> FilterImages(IEnumerable<ImagePreviewViewModel> images, string filterName)
        {
            return images.Where(img => img.Name.ToLower().Contains(filterName.ToLower()));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult LoadFile(FileLoadViewModel file)
        {
            var preparedFile = Mapper.Map<FileLoadViewModel, FileDTO>(file);
            preparedFile.RolesId = file.VisibleForRole.Where(x => x.IsSelected)
                .Select(x => x.Role.Id)
                .ToArray();
            if (ModelState.IsValid)
            {
                preparedFile.Content = ReadFile(file.Content);
                preparedFile.User = userManager.FindUser(System.Web.HttpContext.Current.User.Identity.Name);
                fileService.LoadFile(preparedFile);

            }
            else if (file.Id != null && ModelState.IsValidField("Name") && ModelState.IsValidField("Description"))
            {
                fileService.UpdateFile(preparedFile);
                return RedirectToAction("Image", new { imgId = preparedFile.Id});
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ImageLink(int imgId)
        {
            var resultUrl = $"{Request.Url.GetLeftPart(UriPartial.Authority)}/File/Image?imgId={imgId}";
            return PartialView(model: resultUrl);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult ConfirmDelete(int imgId)
        {
            return PartialView(imgId);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteImage(int imgId)
        {
            fileService.RemoveFile(imgId);
            return RedirectToAction("Gallery");
        }

        private byte[] ReadFile(HttpPostedFileBase file)
        {
            byte[] resultFile = null;
            using (var binReader = new BinaryReader(file.InputStream))
            {
                resultFile = binReader.ReadBytes(file.ContentLength);
            }

            return resultFile;
        }
    }
}