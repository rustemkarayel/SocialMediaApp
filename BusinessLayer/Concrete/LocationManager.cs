using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;

namespace BusinessLayer.Concrete
{
    public class LocationManager : ILocationService
    {
        ILocationDal locationDal;
        public LocationManager(ILocationDal locationDal)
        {
            this.locationDal = locationDal;
        }

        public Location GetLocationById(int id)
        {
            return locationDal.get(location=>location.LocationId==id);
        }

        public void LocationDelete(Location location)
        {
            locationDal.delete(location);
        }

        public void LocationInsert(Location location)
        {
            locationDal.insert(location);
        }

        public List<Location> LocationList()
        {
            return locationDal.list();
        }

        public void LocationUpdate(Location location)
        {
            locationDal.update(location);
        }
    }
}
