using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using core.Blob;
using core.Table.Entry;
using core.Table.Service;
using AzureCoffeShop.Models;

namespace AzureCoffeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly CoffeeService coffeeService;
        private readonly BlobService blobService;

        public HomeController()
        {
            coffeeService = new CoffeeService();
            blobService = new BlobService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Coffee()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult CoffeeList()
        {
            var list = coffeeService.GetAll()
                    .Select(i => new CoffeeModel
                    {
                        Title = i.Title,
                        Image = blobService.GetBlobUrl(i.RowKey)
                    })
                    .ToList();
            return View(list);
        }
    }
}
