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

            //call Creator to run the algorithm
            
        }

        private void ReadEvents()
        {
            //loop through each combo box, check if the value is null, if not find the byte string 
            //associated with the event type and put it in the events dictionary
            if(dayOneEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(dayOneEventOne.SelectedValue.ToString());
                events["dayOneEventOne"] = temp;
            }
            if (dayOneEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(dayOneEventTwo.SelectedValue.ToString());
                events["dayOneEventTwo"] = temp;
            }
            if (dayOneEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(dayOneEventThree.SelectedValue.ToString());
                events["dayOneEventThree"] = temp;
            }

            if (dayTwoEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(dayTwoEventOne.SelectedValue.ToString());
                events["dayTwoEventOne"] = temp;
            }
            if (dayTwoEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(dayTwoEventTwo.SelectedValue.ToString());
                events["dayTwoEventTwo"] = temp;
            }
            if (dayTwoEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(dayTwoEventThree.SelectedValue.ToString());
                events["dayTwoEventThree"] = temp;
            }

            if (dayThreeEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(dayThreeEventOne.SelectedValue.ToString());
                events["dayThreeEventOne"] = temp;
            }
            if (dayThreeEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(dayThreeEventTwo.SelectedValue.ToString());
                events["dayThreeEventTwo"] = temp;
            }
            if (dayThreeEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(dayThreeEventThree.SelectedValue.ToString());
                events["dayThreeEventThree"] = temp;
            }

            if (dayFourEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(dayFourEventOne.SelectedValue.ToString());
                events["dayFourEventOne"] = temp;
            }
            if (dayFourEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(dayFourEventTwo.SelectedValue.ToString());
                events["dayFourEventTwo"] = temp;
            }
            if (dayFourEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(dayFourEventThree.SelectedValue.ToString());
                events["dayFourEventThree"] = temp;
            }

            if (dayFiveEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(dayFiveEventOne.SelectedValue.ToString());
                events["dayFiveEventOne"] = temp;
            }
            if (dayFiveEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(dayFiveEventTwo.SelectedValue.ToString());
                events["dayFiveEventTwo"] = temp;
            }
            if (dayFiveEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(dayFiveEventThree.SelectedValue.ToString());
                events["dayFiveEventThree"] = temp;
            }

            if (daySixEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(daySixEventOne.SelectedValue.ToString());
                events["daySixEventOne"] = temp;
            }
            if (daySixEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(daySixEventTwo.SelectedValue.ToString());
                events["daySixEventTwo"] = temp;
            }
            if (daySixEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(daySixEventThree.SelectedValue.ToString());
                events["daySixEventThree"] = temp;
            }

            if (daySevenEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(daySevenEventOne.SelectedValue.ToString());
                events["daySevenEventOne"] = temp;
            }
            if (daySevenEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(daySevenEventTwo.SelectedValue.ToString());
                events["daySevenEventTwo"] = temp;
            }
            if (daySevenEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(daySevenEventThree.SelectedValue.ToString());
                events["daySevenEventThree"] = temp;
            }

            if (dayEightEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(dayEightEventOne.SelectedValue.ToString());
                events["dayEightEventOne"] = temp;
            }
            if (dayEightEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(dayEightEventTwo.SelectedValue.ToString());
                events["dayEightEventTwo"] = temp;
            }
            if (dayEightEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(dayEightEventThree.SelectedValue.ToString());
                events["dayEightEventThree"] = temp;
            }

            if (dayNineEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(dayNineEventOne.SelectedValue.ToString());
                events["dayNineEventOne"] = temp;
            }
            if (dayNineEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(dayNineEventTwo.SelectedValue.ToString());
                events["dayNineEventTwo"] = temp;
            }
            if (dayNineEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(dayNineEventThree.SelectedValue.ToString());
                events["dayNineEventThree"] = temp;
            }

            if (dayTenEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(dayTenEventOne.SelectedValue.ToString());
                events["dayTenEventOne"] = temp;
            }
            if (dayTenEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(dayTenEventTwo.SelectedValue.ToString());
                events["dayTenEventTwo"] = temp;
            }
            if (dayTenEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(dayTenEventThree.SelectedValue.ToString());
                events["dayTenEventThree"] = temp;
            }

            if (dayElevenEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(dayElevenEventOne.SelectedValue.ToString());
                events["dayElevenEventOne"] = temp;
            }
            if (dayElevenEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(dayElevenEventTwo.SelectedValue.ToString());
                events["dayElevenEventTwo"] = temp;
            }
            if (dayElevenEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(dayElevenEventThree.SelectedValue.ToString());
                events["dayElevenEventThree"] = temp;
            }

            if (dayTwelveEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(dayTwelveEventOne.SelectedValue.ToString());
                events["dayTwelveEventOne"] = temp;
            }
            if (dayTwelveEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(dayTwelveEventTwo.SelectedValue.ToString());
                events["dayTwelveEventTwo"] = temp;
            }
            if (dayTwelveEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(dayTwelveEventThree.SelectedValue.ToString());
                events["dayTwelveEventThree"] = temp;
            }

            if (dayThirteenEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(dayThirteenEventOne.SelectedValue.ToString());
                events["dayThirteenEventOne"] = temp;
            }
            if (dayThirteenEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(dayThirteenEventTwo.SelectedValue.ToString());
                events["dayThirteenEventTwo"] = temp;
            }
            if (dayThirteenEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(dayThirteenEventThree.SelectedValue.ToString());
                events["dayThirteenEventThree"] = temp;
            }

            if (dayFourteenEventOne.SelectedItem != null)
            {
                byte temp = GetByteValue(dayFourteenEventOne.SelectedValue.ToString());
                events["dayFourteenEventOne"] = temp;
            }
            if (dayFourteenEventTwo.SelectedItem != null)
            {
                byte temp = GetByteValue(dayFourteenEventTwo.SelectedValue.ToString());
                events["dayFourteenEventTwo"] = temp;
            }
            if (dayFourteenEventThree.SelectedItem != null)
            {
                byte temp = GetByteValue(dayFourteenEventThree.SelectedValue.ToString());
                events["dayFourteenEventThree"] = temp;
            }


        }

        private byte GetByteValue(String nameOfEvent)
        {
            foreach(String eventType in events.Keys)
            {
                if (eventType.Equals(nameOfEvent))
                {
                    return events[eventType];
                }
            }

            //this calls if there is no event 
            return 0b00000;
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            ward.StoreWardrobe(outputFileName.Text);
            outputError.Content = "File was saved";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string fileName = inputFileName.Text;
            string directory = Directory.GetCurrentDirectory();
            string filepath = System.IO.Path.Combine(directory, @"" + fileName + ".xlsx");
            if (System.IO.File.Exists(filepath))
            {
                articleList.Items.Clear();
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

            intputError.Content = "File was brought in";
        }

        private void saveArticle_Click(object sender, RoutedEventArgs e)
        {
            if(articleName.Text == "")
            {
                errorLabel.Content = "Please Provide an article name";
            }
            else
            {
                ClothingItem tempItem = new ClothingItem((ClothingType)articleType.SelectedItem, (ClothingColor)articleColor.SelectedValue, articleName.Text);
                ward.AddItem(tempItem);

                //add the item to the listbox
                articleList.Items.Add(tempItem.ToString());
                errorLabel.Content = "Article Added to bottom of list";


            }
        }
    }
}
