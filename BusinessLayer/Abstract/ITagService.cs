using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ITagService
    {
        void TagInsert(Tag tag);
        void TagUpdate(Tag tag);
        void TagDelete(Tag tag);
        List<Tag> TagList();
        Tag GetTagById(int id);
    }
}
