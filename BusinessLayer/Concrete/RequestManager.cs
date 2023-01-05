using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RequestManager : IRequestService
    {
        IRequestDal RequestDal;
        public RequestManager(IRequestDal RequestDal)
        {
            this.RequestDal = RequestDal;
        }

        public Request GetRequestById(int id)
        {
            return RequestDal.get(Request=>Request.RequestId==id);
        }

        public void RequestDelete(Request Request)
        {
            RequestDal.delete(Request);
        }

        public void RequestInsert(Request Request)
        {
            RequestDal.insert(Request);
        }

        public List<Request> RequestList()
        {
            return RequestDal.list();
        }

        public void RequestUpdate(Request Request)
        {
            RequestDal.update(Request);
        }
    }
}
