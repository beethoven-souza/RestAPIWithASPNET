﻿using RestAPI_ASPNET.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestAPI_ASPNET.Data.VO
{
    public class BookVO
    {
        public long Id { get; set; }

        public string Author { get; set; }

        public DateTime LaunchDate { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }
    }
}
