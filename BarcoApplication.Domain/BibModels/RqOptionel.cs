﻿using System;
using System.Collections.Generic;

namespace BarcoApplication.Data.BibModels
{
    public partial class RqOptionel
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Remarks { get; set; }
        public int IdRequest { get; set; }

        public virtual RqRequest IdRequestNavigation { get; set; }
    }
}
