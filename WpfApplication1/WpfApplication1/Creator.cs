using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Creator
    {
        private Dictionary<String, byte> events;
        private Wardrobe wardrobe;
        private Dictionary<String, Outfit> finalOutfits;

        public Creator(Dictionary<String, byte> events)
        {
            finalOutfits = new Dictionary<string, Outfit>();
            predefineOutfitDict();
            this.events = events;
            wardrobe = new Wardrobe();
        }
        public Creator(Dictionary<String, byte> events, Wardrobe ward)
        {
            finalOutfits = new Dictionary<string, Outfit>();
            predefineOutfitDict();
            this.events = events;
            this.wardrobe = ward;
        }

        private void predefineOutfitDict()
        {
            Outfit tempOutfit = new Outfit();

            finalOutfits.Add("dayOneEventOne", tempOutfit);
            finalOutfits.Add("dayOneEventTwo", tempOutfit);
            finalOutfits.Add("dayOneEventThree", tempOutfit);

            finalOutfits.Add("dayTwoEventOne", tempOutfit);
            finalOutfits.Add("dayTwoEventTwo", tempOutfit);
            finalOutfits.Add("dayTwoEventThree", tempOutfit);

            finalOutfits.Add("dayThreeEventOne", tempOutfit);
            finalOutfits.Add("dayThreeEventTwo", tempOutfit);
            finalOutfits.Add("dayThreeEventThree", tempOutfit);

            finalOutfits.Add("dayFourEventOne", tempOutfit);
            finalOutfits.Add("dayFourEventTwo", tempOutfit);
            finalOutfits.Add("dayFourEventThree", tempOutfit);

            finalOutfits.Add("dayFiveEventOne", tempOutfit);
            finalOutfits.Add("dayFiveEventTwo", tempOutfit);
            finalOutfits.Add("dayFiveEventThree", tempOutfit);

            finalOutfits.Add("daySixEventOne", tempOutfit);
            finalOutfits.Add("daySixEventTwo", tempOutfit);
            finalOutfits.Add("daySixEventThree", tempOutfit);

            finalOutfits.Add("daySevenEventOne", tempOutfit);
            finalOutfits.Add("daySevenEentTwo", tempOutfit);
            finalOutfits.Add("daySevenEventThree", tempOutfit);

            finalOutfits.Add("dayEightEventOne", tempOutfit);
            finalOutfits.Add("dayEightEventTwo", tempOutfit);
            finalOutfits.Add("dayEightEventThree", tempOutfit);

            finalOutfits.Add("dayNineEventOne", tempOutfit);
            finalOutfits.Add("dayNineEventTwo", tempOutfit);
            finalOutfits.Add("dayNineEventThree", tempOutfit);

            finalOutfits.Add("dayTenEventOne", tempOutfit);
            finalOutfits.Add("dayTenEventTwo", tempOutfit);
            finalOutfits.Add("dayTenEventThree", tempOutfit);

            finalOutfits.Add("dayElevenEventOne", tempOutfit);
            finalOutfits.Add("dayElevenEventTwo", tempOutfit);
            finalOutfits.Add("dayElevenEventThree", tempOutfit);

            finalOutfits.Add("dayTwelveEventOne", tempOutfit);
            finalOutfits.Add("dayTwelveEventTwo", tempOutfit);
            finalOutfits.Add("dayTwelveEventThree", tempOutfit);

            finalOutfits.Add("dayThirteenEventOne", tempOutfit);
            finalOutfits.Add("dayThirteenEventTwo", tempOutfit);
            finalOutfits.Add("dayThirteenEventThree", tempOutfit);

            finalOutfits.Add("dayFourteenEventOne", tempOutfit);
            finalOutfits.Add("dayFourteenEventTwo", tempOutfit);
            finalOutfits.Add("dayFourteenEventThree", tempOutfit);
        }

        public Dictionary<String, Outfit> GenerateOutfit(Dictionary<String, byte> e = null, Wardrobe ward = null)
        {
            if (e != null)
            {
                this.events = e;
            }
            if (ward != null)
            {
                this.wardrobe = ward;
            }
            Dictionary<String, Outfit> finalOutfits = new Dictionary<String, Outfit>();
            Outfit currentOutfit = null;
            //Stopwatch time = new Stopwatch();
            //time.Start();
            this.wardrobe.Shuffle();
            foreach (var item in events.Keys)
            {
                if (events[item] != 0b0)
                {
                    currentOutfit = ChooseOutfit(events[item]);
                    finalOutfits.Add(item, currentOutfit);
                }
            }
            //time.Stop();
            //Console.WriteLine(time.ElapsedMilliseconds);
            return finalOutfits;
        }
        
        public Outfit ChooseOutfit(byte eventType)
        {
            Outfit outfit = ChooseShirt(0, eventType);
 
            if (outfit == null)
            {
                return null;
            }
            else
            {
                return outfit;
            }
        }

        public Outfit ChooseShirt(int index, byte eventType)
        {
            Outfit outfit = null;
            
            if (index >= wardrobe.Shirts.Count)
            {
                return null;
            }
            else
            {
                if (PassesShirtTests(wardrobe.Shirts[index], eventType))
                {
                    outfit = new Outfit();
                    outfit.Shirt = wardrobe.Shirts[index];
                    outfit = ChoosePant(0, eventType, outfit);
                    if (outfit.Pants != null)
                    {
                        wardrobe.Shirts[index].UseCnt += 1;
                        var temp = wardrobe.Shirts[index];
                        wardrobe.Shirts.RemoveAt(index);
                        wardrobe.Shirts.Add(temp);
                    }
                    else
                    {
                        outfit = ChooseShirt(index + 1, eventType);
                    }
                }
                else
                {
                    outfit = ChooseShirt(index + 1, eventType);
                }

                return outfit;
            }
        }

        public Outfit ChoosePant(int index, byte eventType, Outfit outfit)
        {
            if (index >= wardrobe.Pants.Count)
            {
                return outfit;
            }
            else
            {
                if (PassesPantsTests(outfit, wardrobe.Pants[index], eventType))
                {

                    outfit.Pants = wardrobe.Pants[index];
                    
                    outfit = ChooseShoe(0, eventType, outfit);
                    if (outfit.Shoes != null)
                    {
                        wardrobe.Pants[index].UseCnt += 1;
                        var temp = wardrobe.Pants[index];
                        wardrobe.Pants.RemoveAt(index);
                        wardrobe.Pants.Add(temp);
                    }
                    else
                    {
                        outfit = ChoosePant(index + 1, eventType, outfit);
                    }
                }
                else
                {
                    outfit = ChoosePant(index + 1, eventType, outfit);
                }

                return outfit;
            }
        }

        public Outfit ChooseShoe(int index, byte eventType, Outfit outfit)
        {
            if (index >= wardrobe.Shoes.Count)
            {
                return outfit;
            }
            else
            {
                if (PassesShoesTests(outfit, wardrobe.Shoes[index], eventType))
                {
                    outfit.Shoes = wardrobe.Shoes[index];
                    wardrobe.Shoes[index].UseCnt += 1;
                    var temp = wardrobe.Shoes[index];
                    wardrobe.Shoes.RemoveAt(index);
                    wardrobe.Shoes.Add(temp);
                }
                else
                {
                    outfit = ChooseShoe(index + 1, eventType, outfit);
                }

                return outfit;
            }
        }
        
        public bool PassesShirtTests(ClothingItem shirt, byte eventType)
        {
            return shirt.UseCnt < 1 && ((shirt.EventType & eventType) > 0);

        }
        
        public bool PassesPantsTests(Outfit outfit, ClothingItem pant, byte eventType)
        {
            if (pant.Color == outfit.Shirt.Color)
            {
                return false;
            }
            else if ((pant.EventType & eventType) == 0b0)
            {
                return false;
            }
            else if (pant.UseCnt > 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public bool PassesShoesTests(Outfit outfit, ClothingItem shoes, byte eventType)
        {
            if ((shoes.Color.ToString().Equals("blue") && outfit.Shirt.Color.ToString().Equals("black")) ||
                    (shoes.Color.ToString().Equals("black") && outfit.Shirt.Color.ToString().Equals("blue")))
            {
                return false;
            }
            else if ((shoes.EventType & eventType) == 0b0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
