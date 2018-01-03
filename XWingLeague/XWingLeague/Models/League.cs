﻿using System;
using System.Collections.Generic;

namespace XWingLeague.Models
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<ApplicationUser> Administrators { get; set; }
        public List<ApplicationUser> Players { get; set; }
    }
}