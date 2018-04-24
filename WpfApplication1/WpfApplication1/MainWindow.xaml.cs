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
        private Dictionary<String, byte> events = new Dictionary<String, byte>();

        public Dictionary<string, byte> Events { get => events; set => events = value; }

        private Wardrobe ward;

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
    }
}
