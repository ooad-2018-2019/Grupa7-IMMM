﻿using CalTrekApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalTrek.Models
{
    public class KorisnikTjelovjezba
    {
        public Klijent Klijent { get; set; }
        public Tjelovjezba Tjelovjezba { get; set; }
        public DateTime DatumUnosa { get; set; }
    }
}
