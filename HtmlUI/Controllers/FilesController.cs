using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HtmlUI.Models.Details.Files;
using HtmlUI.Models.Entities;
using HtmlUI.Models.Search;

namespace HtmlUI.Controllers
{
    public class FilesController : Controller
    {
        // GET: FilesController
        [HttpGet("{FileId}")]
        public ActionResult Details(int FileId)
        {
            var model = new FileDetailHeader();

            //populate with values from FileEntity.cs

            return View(model);
        }


        public ActionResult Search()
        {
            var model = new FilesSearchModel();
            
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Search(FilesSearchModel ssm)
        {
            //perform search
            var model = new List<FileEntity>();
            model.Add(new FileEntity() {
                PK = 1,
                InstructionText = "take File blahblahblah",
                FileTypeId = "3",
                Required = "false",
                FileCollected = "0",
                FileCollectionStatusId = "5",
                PhotoStatusId = "3",
                StatusReason = "",
                FileSource = "",
                FileColour = "",
                FilePackId = "",
                FileTestType = "",
                FileLengthInCm = "",
                FileQty = ""
            });
            model.Add(new FileEntity()
            {
                PK = 2,
                InstructionText = "no isntruction",
                FileTypeId = "4",
                Required = "true",
                FileCollected = "0",
                FileCollectionStatusId = "3",
                PhotoStatusId = "4",
                StatusReason = "",
                FileSource = "",
                FileColour = "",
                FilePackId = "",
                FileTestType = "",
                FileLengthInCm = "",
                FileQty = ""
            });
            return View("SearchResult", model);
        }


        // GET: FilesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FilesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
