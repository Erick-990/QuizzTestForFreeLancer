using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiQuizz.Models
{
    public class UserQuestionAnswer
    {
        public int UserQuestionAnswerId { get; set; }

        public int AnswerId { get; set; }

        public int UserId { get; set; }

        public int QuestionId { get; set; }
        [JsonIgnore]
        public virtual Answer Answer { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual Question Question { get; set; }
    }
}