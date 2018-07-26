using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiQuizz.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public string AnswerString { get; set; }

        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }

        [JsonIgnore]
        public virtual  Question Question { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; set; }
    }
}