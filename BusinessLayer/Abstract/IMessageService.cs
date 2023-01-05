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
        void MessageInsert(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        List<Message> MessageList();
        Message MessageGetById(int id);
        
    }
}
