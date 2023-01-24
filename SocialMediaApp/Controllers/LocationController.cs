using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;
using SocialMediaApp.PagedList;

namespace SocialMediaApp.Controllers
{
    public class LocationController : Controller
    {
        LocationManager locationManager = new LocationManager(new EfLocationRepository());
        public IActionResult Index(int page = 1, string searchText = "")
        {
            //return View(locationManager.LocationList().ToPagedList(page, pageSize));
            int pageSize = 5;

            Context c = new Context();
            Pager pager;
            List<Location> data;

            var itemCounts = 0;
            if (searchText != "" && searchText != null)
            {
                data = c.Locations.Where(
                        location => location.LocationName.Contains(searchText)
                ).Skip((page - 1) * pageSize).Take(pageSize).ToList();

                itemCounts = c.Locations.Where(
                        genre => genre.LocationName.Contains(searchText)
                ).ToList().Count;
            }
            else
            {
                data = c.Locations.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                itemCounts = c.Locations.ToList().Count;
            }

            pager = new Pager(itemCounts, pageSize, page);

            ViewBag.pager = pager;
            ViewBag.actionName = "location-list";
            ViewBag.contrName = "Location";
            ViewBag.searchText = searchText;

            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Location location)
        {
            LocationValidator locationValidator = new LocationValidator();
            var result = locationValidator.Validate(location);

            if (result.IsValid)
            {
                locationManager.LocationInsert(location);
                return RedirectToAction("location-list");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            Location location = locationManager.GetLocationById(id);
            location.IsActive = false;
            locationManager.LocationUpdate(location);

            return RedirectToAction("location-list");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Location location = locationManager.GetLocationById(id);

            LocationLocationListModel locationLocationListModel = new LocationLocationListModel();
            locationLocationListModel.locationModel = location;
            locationLocationListModel.locationsModel = locationManager.LocationList();

            return View(locationLocationListModel);
        }

        [HttpPost]
        public IActionResult Update(Location location)
        {
            LocationValidator locationValidator = new LocationValidator();
            var result = locationValidator.Validate(location);
            if (result.IsValid)
            {
                locationManager.LocationUpdate(location);
                return RedirectToAction("location-list");
            }
            else
            {
                LocationLocationListModel locationLocationListModel = new LocationLocationListModel();
                locationLocationListModel.locationModel = location;
                locationLocationListModel.locationsModel = locationManager.LocationList();

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(locationLocationListModel);
            }
        }
    }
}
