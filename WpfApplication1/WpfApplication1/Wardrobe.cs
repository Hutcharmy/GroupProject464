using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Wardrobe
    {
        private List<ClothingItem> shirts;
        private List<ClothingItem> pants;
        private List<ClothingItem> shoes;
        

        public Wardrobe()
        {
            shirts = new List<ClothingItem>();
            pants = new List<ClothingItem>();
            shoes = new List<ClothingItem>();
        }

        public Wardrobe(String fileName)
        {
            //load from file
        }

        internal List<ClothingItem> Shirts { get => shirts; }
        internal List<ClothingItem> Pants { get => pants; }
        internal List<ClothingItem> Shoes { get => shoes; }

        public void AddItem(ClothingItem newItem)
        {
            if (newItem.Category == ClothingCategory.Shirt)
            {
                shirts.Add(newItem);
            }
            else if (newItem.Category == ClothingCategory.Pants)
            {
                pants.Add(newItem);
            }
            else
            {
                shoes.Add(newItem);
            }
        }

        public void StoreWardrobe(String filename)
        {
            //Store wardrobe in specified file location
        }
    }
}
