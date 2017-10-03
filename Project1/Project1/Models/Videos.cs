using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1.Models
{
    public partial class Videos
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Source { get; set; }
        public int LinguagemId { get; set; }

        internal static string ToPageList(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        internal static IQueryable<Videos> AsNoTracking()
        {
            throw new NotImplementedException();
        }
    }
}
