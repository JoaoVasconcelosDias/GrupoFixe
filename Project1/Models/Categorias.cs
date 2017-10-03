using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class Categorias
    {
        public Categorias()
        {
            Subcategorias = new HashSet<Subcategorias>();
        }

        public int Id { get; set; }
        public string CategoryTitle { get; set; }

        public ICollection<Subcategorias> Subcategorias { get; set; }
    }
}
