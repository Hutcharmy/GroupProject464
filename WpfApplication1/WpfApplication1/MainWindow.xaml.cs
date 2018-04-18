using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        List<String> events = new List<String>();
        Wardrobe wardrobe = new Wardrobe();

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void printResult_Click(object sender, RoutedEventArgs e)
        {
            List<Outfit> finalOutfits = new List<Outfit>();
            Outfit temp = null;

            //iterate through each event in eventList
            for (int i = 0; i < events.Capacity; i++)
            {
                temp = ChooseOutfit(events[i]);
                finalOutfits.Add(temp);
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

        public Outfit ChooseShirt(int index, String eventName)
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

                    outfit.Shirts = wardrobe.Shirts[index];

                    //call function choosePant(Article shirt)
                    outfit = ChoosePant(0, eventName, outfit);
                }
                else
                {
                    //chooseShirt(next index)
                    ChooseShirt(index + 1, eventName);
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
            if (shirt.useCnt > 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        //passesPantTest(Article shirt, Article pant)
        public bool PassesPantsTests(Outfit outfit, ClothingItem pant) {

            //if pant.color == shirt.color
            if (pant.Color == outfit.Shirts.Color)
            {
                return false;
            } else if () {
                //else if shoe.eventType != shirt.eventType != pant.eventType
                return false;
            } else if (pant.useCnt > 3) {
                return false;
            }
            else {
                return true;
            }
        }

        //passesShoeTests(Article shirt, Article pant, Article shoe)
        public bool PassesShoesTests(Outfit outfit, ClothingItem shoes) {

            //if shoe.color == blue && shirt.color == black || shoe.color == black && shirt.color == blue)
            if ((shoes.Color.ToString().Equals("blue") && outfit.Shirts.Color.ToString().Equals("black")) || 
                    (shoes.Color.ToString().Equals("black") && outfit.Shirts.Color.ToString().Equals("blue")))
            {
                return false;
            } else if () {
                //else if shoe.eventType != shirt.eventType != pant.eventType
                return false;
            }
            else {
                return true;
            }
        }
    }
}
