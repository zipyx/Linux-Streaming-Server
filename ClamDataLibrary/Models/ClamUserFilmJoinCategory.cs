using System;
using System.Collections.Generic;
using System.Text;

namespace ClamDataLibrary.Models
{
    public class ClamUserFilmJoinCategory
    {
        public Guid FilmId { get; set; }
        public ClamUserFilm ClamUserFilm { get; set; }

        public Guid CategoryId { get; set; }
        public ClamUserFilmCategory ClamUserFilmCategory { get; set; }

    }
}
