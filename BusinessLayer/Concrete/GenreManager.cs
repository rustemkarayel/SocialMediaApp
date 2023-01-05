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
    public class GenreManager : IGenreService
    {
        IGenreDal genreDal;

        public GenreManager(IGenreDal genreDal)
        {
            this.genreDal = genreDal;
        }
        public void GenreDelete(Genre genre)
        {
            genreDal.delete(genre);
        }

        public void GenreInsert(Genre genre)
        {
            genreDal.insert(genre);
        }

        public List<Genre> GenreList()
        {
            return genreDal.list();
        }

        public void GenreUpdate(Genre genre)
        {
            genreDal.update(genre);
        }

        public Genre GetGenreById(int id)
        {
            return genreDal.get(genre=>genre.GenreId==id);
        }
    }
}
