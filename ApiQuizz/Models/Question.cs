using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiQuizz.Models
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string QuestionString { get; set; }

        [JsonIgnore]
        public virtual ICollection<Answer> Answers { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; set; }

    }
}