using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class Subcategorias
    {
        public Subcategorias()
        {
            Posts = new HashSet<Posts>();
        }

        public int Id { get; set; }
        public int CategoriasId { get; set; }
        public string Title { get; set; }

        public Categorias Categorias { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}
