using System;
using System.Collections.Generic;

namespace Project1.Models
{
    public partial class Resultados
    {
        public int PerguntaId { get; set; }
        public int RespostaDada { get; set; }

        public QuizPergunta Pergunta { get; set; }
    }
}
