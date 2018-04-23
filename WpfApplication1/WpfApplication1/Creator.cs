using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Creator
    {
        private List<String> events;
        private Wardrobe wardrobe;
        public Creator()
        {
            events = new List<String>();
            wardrobe = new Wardrobe();
        }
        public Creator(List<String> e, Wardrobe ward)
        {
            events = e;
            wardrobe = ward;
        }
        private void GenerateOutfit(List<String> e = null, Wardrobe ward = null)
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

            //iterate through each event in eventList
            for (int i = 0; i < events.Capacity; i++)
            {
                currentOutfit = ChooseOutfit(events[i]);
                finalOutfits.Add(events[i], currentOutfit);
            }

            //print the outfits to the console for the User

        }

        //chooseOutfit(event)
        public Outfit ChooseOutfit(String eventName)
        {
            //Outfit outfit = chooseShirt()
            Outfit outfit = ChooseShirt(0, eventName);

            //if no outfit can be made for the event 
            if (outfit == null)
            {
                //return "No outfit could be made for this event"
                return null;
            }
            else
            {
                //return outfit
                return outfit;
            }
        }

        public Outfit ChooseShirt(int index, string eventName)
        {
            Outfit outfit = null;

            //if(no more shirts)
            if (wardrobe.Shirts[index] == null)
            {
                //return nothing
                return null;
            }
            else
            {
                //if(passesShirtTests(Article shirt))
                if (PassesShirtTests(wardrobe.Shirts[index]))
                {

                    outfit.Shirt = wardrobe.Shirts[index];

                    //call function choosePant(Article shirt)
                    outfit = ChoosePant(0, eventName, outfit);
                }
                else
                {
                    //chooseShirt(next index)
                    outfit = ChooseShirt(index + 1, eventName);
                }

                return outfit;
            }
        }

        public Outfit ChoosePant(int index, String eventName, Outfit outfit)
        {
            //if(no more pants)
            if (wardrobe.Pants[index] == null)
            {
                //return nothing
                return null;
            }
            else
            {
                //if(passesPantsTests(Article pant))
                if (PassesPantsTests(outfit, wardrobe.Pants[index]))
                {

                    outfit.Pants = wardrobe.Pants[index];

                    //call function chooseShoe(Article shoe)
                    outfit = ChooseShoe(0, eventName, outfit);
                }
                else
                {
                    //chooseShirt(next index)
                    ChoosePant(index + 1, eventName, outfit);
                }

                return outfit;
            }
        }

        public Outfit ChooseShoe(int index, String eventName, Outfit outfit)
        {
            //if(no more shoes)
            if (wardrobe.Shoes[index] == null)
            {
                //return nothing
                return null;
            }
            else
            {
                //if(passesShoesTests(Article shoe))
                if (PassesShoesTests(outfit, wardrobe.Shoes[index]))
                {

                    outfit.Shoes = wardrobe.Shoes[index];

                    //OUTFIT COMPLETE
                    return outfit;
                }
                else
                {
                    //chooseShoe(next index)
                    ChooseShoe(index + 1, eventName, outfit);
                }

                return outfit;
            }
        }

        //passesShirtTests(Article shirt)
        public bool PassesShirtTests(ClothingItem shirt)
        {
            if (shirt.UseCnt > 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        //passesPantTest(Article shirt, Article pant)
        public bool PassesPantsTests(Outfit outfit, ClothingItem pant)
        {

            //if pant.color == shirt.color
            if (pant.Color == outfit.Shirt.Color)
            {
                return false;
            }
            //else if ()
            //{
            //    //else if shoe.eventType != shirt.eventType != pant.eventType
            //    return false;
            //}
            else if (pant.UseCnt > 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //passesShoeTests(Article shirt, Article pant, Article shoe)
        public bool PassesShoesTests(Outfit outfit, ClothingItem shoes)
        {

            //if shoe.color == blue && shirt.color == black || shoe.color == black && shirt.color == blue)
            if ((shoes.Color.ToString().Equals("blue") && outfit.Shirt.Color.ToString().Equals("black")) ||
                    (shoes.Color.ToString().Equals("black") && outfit.Shirt.Color.ToString().Equals("blue")))
            {
                return false;
            }
            //else if ()
            //{
            //    //else if shoe.eventType != shirt.eventType != pant.eventType
            //    return false;
            //}
            else
            {
                return true;
            }
        }
    }
}
