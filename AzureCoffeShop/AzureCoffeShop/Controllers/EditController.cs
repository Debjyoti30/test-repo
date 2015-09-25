using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using core.Blob;
using core;
using core.Table.Entry;
using core.Table.Service;

namespace Controllers
{
    public class EditController : Controller
    {
        private readonly CoffeeService coffeeService;
        private readonly BlobService blobService;

        public EditController()
        {
            coffeeService = new CoffeeService();
            blobService = new BlobService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CofeeList()
        {
            var list = coffeeService.GetAll();

            return View(list);
        }

        public ActionResult CoffeeEntry(string goodId)
        {
            return View(
                string.IsNullOrEmpty(goodId) ?
                    new Coffee { PartitionKey = "" } :
                    coffeeService.GetById(goodId));
        }

        [HttpPost]
        public ActionResult CoffeeEntry(Coffee entry, HttpPostedFileBase cover)
        {
            if (cover != null)
            {
                blobService.UploadByStream(entry.RowKey, cover.InputStream);
            }

            coffeeService.InsertOrReplace(entry);

            return RedirectToAction("CoffeeList");
        }

        public ActionResult CoffeeDelete(string id)
        {
            coffeeService.DeleteById(id);

            return RedirectToAction("CoffeeList");
        }
    }
}
