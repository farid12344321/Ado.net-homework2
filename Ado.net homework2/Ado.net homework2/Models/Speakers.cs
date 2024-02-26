using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ado.net_homework2.Models
{
    internal class Speakers
    {

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string Image { get; set; }


        public override string ToString()
        {
            return $"{Id} - {FullName} - {Position} - {Company} - {Image}";
        }
    }
}
