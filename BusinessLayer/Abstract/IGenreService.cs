using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface IGenreService
    {
        void GenreInsert(Genre genre);
        void GenreUpdate(Genre genre);
        void GenreDelete(Genre genre);
        Genre GetGenreById(int id);
        List<Genre> GenreList();
    }
}
