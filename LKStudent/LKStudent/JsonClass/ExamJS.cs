﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKStudent
{
    class ExamJS
    {
        public string SubjectName { get; set; }
        public DateTime ExamDate { get; set; }
        public string Location { get; set; }
        public string FIO { get; set; }
    }

    class ListExamJs
    {
         public List<ExamJS> Model { get; set; }
    }
}
