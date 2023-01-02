﻿using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MVCApp.Models.Db
{
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
}
