using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiQuizz.Models
{
    public class QuestionResponse
    {
        public int QuestionId { get; set; }

        public string QuestionString { get; set; }

       public List<Answer> Answers { get; set; }

    }
}