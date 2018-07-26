using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiQuizz.Models
{
    public class VideoLink
    {
        public int VideoLinkId { get; set; }

        public decimal MinutesRequired { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }
    }
}