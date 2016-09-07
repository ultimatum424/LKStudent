using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKStudent
{
    public class AchievementData
    {
        public int Id { get; set; }
        public string Direction { get; set; }
        public string Name { get; set; }
        public string SubName { get; set; }
        public float Mark { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public bool HasScan { get; set; }
        public string FullName { get; set; }
    }
    

}
