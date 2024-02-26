using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_homework2.Models
{
    internal class Events
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Description} - {Address} - {StartDate.ToString("yyyy:dd:MM")} - {StartTime.ToString("HH:mm")} - {EndTime.ToString("HH:mm")}";
        }
        
    }
}
