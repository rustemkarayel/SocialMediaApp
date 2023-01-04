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
    public class MessageManager : IMessageService
    {
        IMessageDal messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            this.messageDal = messageDal;
        }
        public void MessageDelete(Message message)
        {
            messageDal.delete(message);
        }

        public Message MessageGetById(int id)
        {
            return messageDal.get(x => x.MessageId == id);
        }

        public void MessageInsert(Message message)
        {
            messageDal.insert(message);
        }

        public List<Message> MessageList()
        {
            return messageDal.list();
        }

        public void MessageUpdate(Message message)
        {
            messageDal.update(message);
        }
    }
}
