using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillingStation
{
    public class Item
    {
        public string Name { get; set; }
        public Guid Id { get; private set; }
        public double Price { get; set; }
        public TypeItem Type { get; set; }

        public Item()
        {
            Id = new Guid();    
        }
    }
}
