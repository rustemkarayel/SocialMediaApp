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
    public class TagManager : ITagService
    {
        ITagDal tagDal;
        public TagManager(ITagDal tagDal)
        {
            this.tagDal = tagDal;
        }

        public Tag GetTagById(int id)
        {
            return tagDal.get(tag => tag.TagId == id);
        }

        public void TagDelete(Tag tag)
        {
            tagDal.delete(tag);
        }

        public void TagInsert(Tag tag)
        {
            tagDal.insert(tag);
        }

        public List<Tag> TagList()
        {
            return tagDal.list();
        }

        public void TagUpdate(Tag tag)
        {
            tagDal.update(tag);
        }
    }
}
