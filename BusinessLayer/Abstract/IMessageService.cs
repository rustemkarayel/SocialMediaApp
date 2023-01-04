using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        void messageInsert(Message message);
        void messageDelete(Message message);
        void messageUpdate(Message message);
        List<Message> messageList();
        Message messageGetById(int id);
        
    }
}
