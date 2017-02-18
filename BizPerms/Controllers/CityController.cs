using BizPerms.Helpers;
using G4.BizPermit.Dal;
using G4.BizPermit.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace G4.BizPermit.Web.Controllers
{
    [AccessDeniedAuthorize(Roles = "Admin")]
    public class CityController : Controller
    {
        // GET: City
        public ActionResult Index()
        {
            ViewBag.Provinces = ProvincesData.ListAll();
            List<City> model = new List<City>();
            model = CitiesData.ListAll();
            return View(model);
        }
        public ActionResult Add()
        {
            ViewBag.Provinces = ProvincesData.ListAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(City city)
        {
            bool result = CitiesData.Add(city);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            ViewBag.Provinces = ProvincesData.ListAll();
            City city = CitiesData.GetById(id);
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(City city)
        {
            bool result = CitiesData.Edit(city);
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            ViewBag.Provinces = ProvincesData.ListAll();
            City city = CitiesData.GetById(id);
            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(City city)
        {
            bool result = CitiesData.Delete(city.UniqueId.ToString());
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}