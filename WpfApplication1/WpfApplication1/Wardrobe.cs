using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Wardrobe
    {
        private List<ClothingItem> ward;

        internal List<ClothingItem> Ward { get => ward; set => ward = value; }

        public Wardrobe()
        {
            ward = new List<ClothingItem>();
        }

        public Wardrobe(String fileName)
        {
            //load from file
        }

        public void AddItem(ClothingItem newItem)
        {
            ward.Add(newItem);
        }

        public void StoreWardrobe(String filename)
        {
            //Store wardrobe in specified file location
        }
    }
}
