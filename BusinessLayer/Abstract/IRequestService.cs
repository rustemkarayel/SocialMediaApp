using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRequestService
    {
        void RequestInsert(Request Request);
        void RequestUpdate(Request Request);
        void RequestDelete(Request Request);
        List<Request> RequestList();
        Request GetRequestById(int id);
    }
}
