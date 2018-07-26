using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiQuizz.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<UserQuestionAnswer> UserQuestionAnswers { get; set; }
    }
}