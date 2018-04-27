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

        public override string ToString()
        {
            return "Shirt: " + Shirt.ToString() + "\nPants: " + Pants.ToString() + "\nShoes: " + Shoes.ToString();
        }

        internal ClothingItem Shirt { get => shirt; set => shirt = value; }
        internal ClothingItem Pants { get => pants; set => pants = value; }
        internal ClothingItem Shoes { get => shoes; set => shoes = value; }

    }
}
