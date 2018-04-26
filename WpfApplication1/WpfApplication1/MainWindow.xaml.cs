using System;
using System.Collections.Generic;
using System.IO;
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
        //actual list
        private Dictionary<String, byte> events = new Dictionary<String, byte>();

        //property
        public Dictionary<string, byte> Events { get => events; set => events = value; }

        private Wardrobe ward;

        public Dictionary<string, byte> userEvents = new Dictionary<string, byte>();

        public Dictionary<string, byte> UserEvents { get => events; set => events = value; }

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Events.Add("Formal", 0b10000);
            Events.Add("Semiformal", 0b1000);
            Events.Add("Business Casual", 0b100);
            Events.Add("Casual", 0b10);
            Events.Add("Athletic", 0b1);

            AddDaysAndEventsToDict();

            foreach (var item in Enum.GetValues(typeof(ClothingColor)))
            {
                articleColor.Items.Add(item);
            }
            foreach (var item in Enum.GetValues(typeof(ClothingType)))
            {
                articleType.Items.Add(item);
            }
            AddToEventDropdowns();
            string directory = Directory.GetCurrentDirectory().Replace(@"bin\Debug", "");
            string filepath = System.IO.Path.Combine(directory, @"listClothes1.xlsx");
            if (System.IO.File.Exists(filepath))
            {
                ward = new Wardrobe(filepath);
                foreach (var item in ward.Shirts)
                {
                    articleList.Items.Add(item);
                }
                foreach (var item in ward.Pants)
                {
                    articleList.Items.Add(item);
                }
                foreach (var item in ward.Shoes)
                {
                    articleList.Items.Add(item);
                }
            }
            else
            {
                ward = new Wardrobe();
            }
        }

        public void AddDaysAndEventsToDict()
        {
            userEvents.Add("dayOneEventOne", 0b00000);
            userEvents.Add("dayOneEventTwo", 0b00000);
            userEvents.Add("dayOneEventThree", 0b00000);

            userEvents.Add("dayTwoEventOne", 0b00000);
            userEvents.Add("dayTwoEventTwo", 0b00000);
            userEvents.Add("dayTwoEventThree", 0b00000);

            userEvents.Add("dayThreeEventOne", 0b00000);
            userEvents.Add("dayThreeEventTwo", 0b00000);
            userEvents.Add("dayThreeEventThree", 0b00000);

            userEvents.Add("dayFourEventOne", 0b00000);
            userEvents.Add("dayFourEventTwo", 0b00000);
            userEvents.Add("dayFourEventThree", 0b00000);

            userEvents.Add("dayFiveEventOne", 0b00000);
            userEvents.Add("dayFiveEventTwo", 0b00000);
            userEvents.Add("dayFiveEventThree", 0b00000);

            userEvents.Add("daySixEventOne", 0b00000);
            userEvents.Add("daySixEventTwo", 0b00000);
            userEvents.Add("daySixEventThree", 0b00000);

            userEvents.Add("daySevenEventOne", 0b00000);
            userEvents.Add("daySevenEentTwo", 0b00000);
            userEvents.Add("daySevenEventThree", 0b00000);

            userEvents.Add("dayEightEventOne", 0b00000);
            userEvents.Add("dayEightEventTwo", 0b00000);
            userEvents.Add("dayEightEventThree", 0b00000);

            userEvents.Add("dayNineEventOne", 0b00000);
            userEvents.Add("dayNineEventTwo", 0b00000);
            userEvents.Add("dayNineEventThree", 0b00000);

            userEvents.Add("dayTenEventOne", 0b00000);
            userEvents.Add("dayTenEventTwo", 0b00000);
            userEvents.Add("dayTenEventThree", 0b00000);

            userEvents.Add("dayElevenEventOne", 0b00000);
            userEvents.Add("dayElevenEventTwo", 0b00000);
            userEvents.Add("dayElevenEventThree", 0b00000);

            userEvents.Add("dayTwelveEventOne", 0b00000);
            userEvents.Add("dayTwelveEventTwo", 0b00000);
            userEvents.Add("dayTwelveEventThree", 0b00000);

            userEvents.Add("dayThirteenEventOne", 0b00000);
            userEvents.Add("dayThirteenEventTwo", 0b00000);
            userEvents.Add("dayThirteenEventThree", 0b00000);

            userEvents.Add("dayFourteenEventOne", 0b00000);
            userEvents.Add("dayFourteenEventTwo", 0b00000);
            userEvents.Add("dayFourteenEventThree", 0b00000);

        }

        private void AddToEventDropdowns()
        {
            foreach (var item in Events.Keys)
            {

                dayOneEventOne.Items.Add(item);
                dayOneEventTwo.Items.Add(item);
                dayOneEventThree.Items.Add(item);

                dayTwoEventOne.Items.Add(item);
                dayTwoEventTwo.Items.Add(item);
                dayTwoEventThree.Items.Add(item);

                dayThreeEventOne.Items.Add(item);
                dayThreeEventTwo.Items.Add(item);
                dayThreeEventThree.Items.Add(item);

                dayFourEventOne.Items.Add(item);
                dayFourEventTwo.Items.Add(item);
                dayFourEventThree.Items.Add(item);

                dayFiveEventOne.Items.Add(item);
                dayFiveEventTwo.Items.Add(item);
                dayFiveEventThree.Items.Add(item);

                daySixEventOne.Items.Add(item);
                daySixEventTwo.Items.Add(item);
                daySixEventThree.Items.Add(item);

                daySevenEventOne.Items.Add(item);
                daySevenEventTwo.Items.Add(item);
                daySevenEventThree.Items.Add(item);

                dayEightEventOne.Items.Add(item);
                dayEightEventTwo.Items.Add(item);
                dayEightEventThree.Items.Add(item);

                dayNineEventOne.Items.Add(item);
                dayNineEventTwo.Items.Add(item);
                dayNineEventThree.Items.Add(item);

                dayTenEventOne.Items.Add(item);
                dayTenEventTwo.Items.Add(item);
                dayTenEventThree.Items.Add(item);

                dayElevenEventOne.Items.Add(item);
                dayElevenEventTwo.Items.Add(item);
                dayElevenEventThree.Items.Add(item);

                dayTwelveEventOne.Items.Add(item);
                dayTwelveEventTwo.Items.Add(item);
                dayTwelveEventThree.Items.Add(item);

                dayThirteenEventOne.Items.Add(item);
                dayThirteenEventTwo.Items.Add(item);
                dayThirteenEventThree.Items.Add(item);

                dayFourteenEventOne.Items.Add(item);
                dayFourteenEventTwo.Items.Add(item);
                dayFourteenEventThree.Items.Add(item);

            }
        }

        private void printResult_Click(object sender, RoutedEventArgs e)
        {
            //search through each of the combo boxes and add them to the dictionary
            ReadEvents();

            
        }

        public void ReadEvents()
        {
            //loop through each
            if(dayOneEventOne.SelectedItem != null)
            {
                //UserEvents.
            }

        }

        /*public byte getByteValue(String name)
        {
            foreach(String eventType in events.Keys)
            {
                if (eventType.Equals(name))
                {
                    return 
                }
            }
        }*/
    }
}
