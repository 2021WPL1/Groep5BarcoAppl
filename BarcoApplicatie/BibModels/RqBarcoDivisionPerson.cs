﻿using System;
using System.Collections.Generic;

namespace BarcoApplicatie.BibModels
{
    public partial class RqBarcoDivisionPerson
    {
        public int Id { get; set; }
        public string AfkDevision { get; set; }
        public string AfkPerson { get; set; }

        public virtual RqBarcoDivision AfkDevisionNavigation { get; set; }
        public virtual Person AfkPersonNavigation { get; set; }
    }
}
