using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public enum ClothingType
    {
        DressShirt, ButtonDown, Polo, TShirt, Blouse, Dress,
        DressPants, Jeans, Khakis, CasualShorts, AthleticShorts, CasualPants, BathingSuit,
        DressShoes, TennisShoes, Sandals, Heels, Flats
    }; 
    public enum ClothingColor { Black, White, Brown, Red, Gray, Blue, Green, Yellow, Purple, Orange };
    public enum ClothingCategory { Shirt, Pants, Shoes };

    class ClothingItem
    {
        private String name;
        private ClothingType type;
        private ClothingColor color;
        private ClothingCategory category;
        const int COUNT_SHIRTS = 6;
        const int COUNT_PANTS = 7;
        public int useCnt = 0;

        public string Name { get => name; set => name = value; }
        public int UseCnt { get => useCnt; set => useCnt = value; }
        public ClothingType Type { get => type; set => type = value; }
        public ClothingColor Color { get => color; set => color = value; }
        public ClothingCategory Category { get => category; set => category = value; }

        public ClothingItem(ClothingType type, ClothingColor color, String name = "")
        {
            this.Type = type;
            this.Color = color;
            this.Name = name;
            if ((int)type < COUNT_SHIRTS)
            {
                this.Category = ClothingCategory.Shirt;
            }
            else if ((int)type < (COUNT_SHIRTS + COUNT_PANTS))
            {
                this.Category = ClothingCategory.Pants;
            }
            else
            {
                this.Category = ClothingCategory.Shoes;
            }
        }


    }
}
