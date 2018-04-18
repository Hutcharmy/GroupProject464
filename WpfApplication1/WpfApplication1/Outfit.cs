using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Outfit
    {
        private ClothingItem shirt;
        private ClothingItem pants;
        private ClothingItem shoes;
        

        public Outfit()
        {
        }

        internal ClothingItem Shirts { get => shirt; set => shirt = value; }
        internal ClothingItem Pants { get => pants; set => pants = value; }
        internal ClothingItem Shoes { get => shoes; set => shoes = value; }

    }
}
