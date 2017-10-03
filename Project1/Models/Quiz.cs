using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            QuizPergunta = new HashSet<QuizPergunta>();
        }

        public int QuizId { get; set; }
        public int LinguagemId { get; set; }

        public Linguagem Linguagem { get; set; }
        public ICollection<QuizPergunta> QuizPergunta { get; set; }
    }
}
