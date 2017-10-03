using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Apontamentos { get; set; }

        public Anotacoes Anotacoes { get; set; }
    }
}
