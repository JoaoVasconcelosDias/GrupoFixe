using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class Linguagem
    {
        public Linguagem()
        {
            Quiz = new HashSet<Quiz>();
        }

        public int LinguagemId { get; set; }

        public ICollection<Quiz> Quiz { get; set; }
    }
}
