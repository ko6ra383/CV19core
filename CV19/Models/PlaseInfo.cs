using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CV19.Models
{
    public class PlaseInfo
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public IEnumerable<ConfirmedCount> Counts { get; set; }
    }
}
