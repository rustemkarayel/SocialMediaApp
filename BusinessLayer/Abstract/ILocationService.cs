using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ILocationService
    {
        void LocationInsert(Location location);
        void LocationUpdate(Location location);
        void LocationDelete(Location location);
        List<Location> LocationList();
        Location GetLocationById(int id);
    }
}
