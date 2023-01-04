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
        public void messageDelete(Message message)
        {
            messageDal.delete(message);
        }

        public Message messageGetById(int id)
        {
            return messageDal.get(x => x.MessageId == id);
        }

        public void messageInsert(Message message)
        {
            messageDal.insert(message);
        }

        public List<Message> messageList()
        {
            return messageDal.list();
        }

        public void messageUpdate(Message message)
        {
            messageDal.update(message);
        }
    }
}
