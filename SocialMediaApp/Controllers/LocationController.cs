using Azure;
using BusinessLayer.Concrete;
using BusinessLayer.Validations;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMediaApp.Models;

namespace SocialMediaApp.Controllers
{
    public class LocationController : Controller
    {
        LocationManager locationManager = new LocationManager(new EfLocationRepository());
        public IActionResult Index()
        {
            var locations = locationManager.LocationList();
            return View(locations);
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
