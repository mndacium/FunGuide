﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunGuide.Shared
{
    public class Sport
    {
        public int Id { get; set; }
        public string Name { get; set; }=String.Empty;
        public Sportsman? RecordHolder { get; set; }
        public int RecordHolderId { get; set; }
    }
}
