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
        

    

    public class ClothingItem
    {
        private String name;
        private ClothingType type;
        private ClothingColor color;
        private ClothingCategory category;
        const int COUNT_SHIRTS = 6;
        const int COUNT_PANTS = 7;
        private int useCnt = 0;
        private byte eventType;

        public string Name { get => name; set => name = value; }
        public int UseCnt { get => useCnt; set => useCnt = value; }
        public ClothingType Type { get => type; set => type = value; }
        public ClothingColor Color { get => color; set => color = value; }
        public ClothingCategory Category { get => category; set => category = value; }
        public byte EventType { get => eventType; set => eventType = value; }

        public List<ClothingType> FormalClothes = new List<ClothingType> {
            ClothingType.DressShirt, ClothingType.Dress, ClothingType.DressPants, ClothingType.DressShoes, ClothingType.Heels
        };
        public List<ClothingType> SemiFormalClothes = new List<ClothingType> {
            ClothingType.DressShirt, ClothingType.ButtonDown, ClothingType.Dress, ClothingType.Blouse,
            ClothingType.DressPants, ClothingType.Khakis, ClothingType.DressShoes, ClothingType.Heels, ClothingType.Flats
        };
        public List<ClothingType> BCClothes = new List<ClothingType> {
           ClothingType.ButtonDown, ClothingType.Polo, ClothingType.Blouse, ClothingType.Dress,
           ClothingType.DressShoes, ClothingType.Flats, ClothingType.Heels, ClothingType.Jeans, ClothingType.Khakis
        };
        public List<ClothingType> CasualClothes = new List<ClothingType> {
            ClothingType.Polo, ClothingType.AthleticShorts, ClothingType.CasualPants, ClothingType.CasualShorts,
            ClothingType.Flats, ClothingType.Jeans, ClothingType.Sandals, ClothingType.TennisShoes, ClothingType.TShirt
        };
        public List<ClothingType> AthleticClothes = new List<ClothingType> {
            ClothingType.TShirt, ClothingType.AthleticShorts, ClothingType.TennisShoes
        };


        byte AthleticFlag = 1;
        byte CasualFlag = 2;
        byte BusinessCasualFlag = 4;
        byte SemiFormalFlag = 8;
        byte FormalFlag = 16;

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
            this.eventType = DetermineEventType(); 
        }

        private byte DetermineEventType()
        {
            byte events = 00000;

            if (FormalClothes.Contains(this.type))
            {
                events |= FormalFlag;
            }
            if (SemiFormalClothes.Contains(this.type))
            {
                events |= SemiFormalFlag;
            }
            if (BCClothes.Contains(this.type))
            {
                events |= BusinessCasualFlag;
            }
            if (CasualClothes.Contains(this.type))
            {
                events |= CasualFlag;
            }
            if (AthleticClothes.Contains(this.type))
            {
                events |= AthleticFlag;
            }

            return events;
        }

        public Boolean CompareEventType (byte flag)
        {
            return (flag & this.eventType) > 0;
        }

        public override string ToString()
        {
            return name + "\t" + type.ToString() + "\t" + color.ToString();
        }
        
    }
}
