using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class QuizPergunta
    {
        public QuizPergunta()
        {
            Resultados = new HashSet<Resultados>();
        }

        public int QuizId { get; set; }
        public int PerguntaId { get; set; }
        public int PerguntaExtenso { get; set; }
        public int PerguntaOpcoes { get; set; }
        public int RespostaCerta { get; set; }

        public Quiz Quiz { get; set; }
        public ICollection<Resultados> Resultados { get; set; }
    }
}
