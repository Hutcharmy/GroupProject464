using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.IO;

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

        public Wardrobe(String filename)
        {
            shirts = new List<ClothingItem>();
            pants = new List<ClothingItem>();
            shoes = new List<ClothingItem>();

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filename);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            String name = "";
            String type = "";
            String color = "";
            bool error = false;
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    if (j == 1)
                    {
                        name = xlRange.Cells[i, j].Value2;
                    }
                    else if (j == 2)
                    {
                        type = xlRange.Cells[i, j].Value2;
                    }
                    else if (j == 3)
                    {
                        color = xlRange.Cells[i, j].Value2;
                    }
                    else
                    {
                        //too many columns
                        error = true;
                    }
                    //write the value to the console
                    //if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        //Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");
                }

                if (error == false)
                {
                    ClothingItem temp = new ClothingItem(getType(type), getColor(color), name);
                    if (temp.Category == ClothingCategory.Shirt) {
                        Shirts.Add(temp);
                    }
                    else if (temp.Category == ClothingCategory.Pants)
                    {
                        Pants.Add(temp);
                    }
                    else if (temp.Category == ClothingCategory.Shoes)
                    {
                        Shoes.Add(temp);
                    }
                    else
                    {
                        //error time
                        break;
                    }
                }
                else
                {
                    //throw error
                    break;
                }
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
            
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
            using (ExcelPackage excel = new ExcelPackage())
            {

                excel.Workbook.Worksheets.Add("outfits");

                //create a new excel file
                //files are saved in GroupProject464\WpfApplication1\WpfApplication1\bin\Debug\{filename.xlsx}
                FileInfo excelFile = new FileInfo(@"" + filename + ".xlsx");
                excel.SaveAs(excelFile);

                //create a worksheet in the excel file
                var excelWorksheet = excel.Workbook.Worksheets["outfits"];

                //add info to the cells
                int rowCount = shirts.Count() + pants.Count() + shoes.Count();
                var cellData = new List<string[]>();

                //itterate through all the shirts and add them to the cellData
                for (int i = 0; i < shirts.Count; i++)
                {
                    string[] row = new string[3];
                    //go over each column
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == 0)
                        {
                            row[j] = shirts[i].Name;
                        }
                        else if (j == 1)
                        {
                            row[j] = shirts[i].Type.ToString();
                        }
                        else
                        {
                            row[j] = shirts[i].Color.ToString();
                        }
                    }
                    cellData.Add(row);
                }

                //itterate through all the pants and add them to the cellData
                for (int i = 0; i < pants.Count; i++)
                {
                    string[] row = new string[3];
                    //go over each column
                    for (int j = 0; j < 3; j++)
                    {
                        if (j == 0)
                        {
                            row[j] = pants[i].Name;
                        }
                        else if (j == 1)
                        {
                            row[j] = pants[i].Type.ToString();
                        }
                        else
                        {
                            row[j] = pants[i].Color.ToString();
                        }
                    }
                    cellData.Add(row);
                }

                //itterate through all the shoes and add them to the cellData
                for (int i = 0; i < shoes.Count; i++)
                {
                    string[] row = new string[3];
                    //go over each column
                    for (int j = 0; j < 3; j++)
                    {
                            if (j == 0)
                            {
                                row[j] = shoes[i].Name;
                            }
                            else if (j == 1)
                            {
                                row[j] = shoes[i].Type.ToString();
                            }
                            else
                            {
                                row[j] = shoes[i].Color.ToString();
                            }
                    }
                    cellData.Add(row);
                }

                //add all of the outfits to the excel file 
                excelWorksheet.Cells[1, 1].LoadFromArrays(cellData);
                excel.SaveAs(excelFile);
                
            }
        }

        private ClothingColor getColor(String color)
        {
            if (color.Equals(Enum.GetName(typeof(ClothingColor), ClothingColor.Black)))
            {
                return ClothingColor.Black;
            }
            else if (color.Equals(Enum.GetName(typeof(ClothingColor), ClothingColor.Blue)))
            {
                return ClothingColor.Blue;
            }
            else if (color.Equals(Enum.GetName(typeof(ClothingColor), ClothingColor.Brown)))
            {
                return ClothingColor.Brown;
            }
            else if (color.Equals(Enum.GetName(typeof(ClothingColor), ClothingColor.Gray)))
            {
                return ClothingColor.Gray;
            }
            else if (color.Equals(Enum.GetName(typeof(ClothingColor), ClothingColor.Green)))
            {
                return ClothingColor.Green;
            }
            else if (color.Equals(Enum.GetName(typeof(ClothingColor), ClothingColor.Orange)))
            {
                return ClothingColor.Orange;
            }
            else if (color.Equals(Enum.GetName(typeof(ClothingColor), ClothingColor.Purple)))
            {
                return ClothingColor.Purple;
            }
            else if (color.Equals(Enum.GetName(typeof(ClothingColor), ClothingColor.Red)))
            {
                return ClothingColor.Red;
            }
            else if (color.Equals(Enum.GetName(typeof(ClothingColor), ClothingColor.White)))
            {
                return ClothingColor.White;
            }
            else if (color.Equals(Enum.GetName(typeof(ClothingColor), ClothingColor.Yellow)))
            {
                return ClothingColor.Yellow;
            }
            else
            {
                //could not read the color
                return ClothingColor.Black;
            }
        }

        private ClothingType getType(String type)
        {
            if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.AthleticShorts)))
            {
                return ClothingType.AthleticShorts;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.BathingSuit)))
            {
                return ClothingType.BathingSuit;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.Blouse)))
            {
                return ClothingType.Blouse;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.ButtonDown)))
            {
                return ClothingType.ButtonDown;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.CasualPants)))
            {
                return ClothingType.CasualPants;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.CasualShorts)))
            {
                return ClothingType.CasualShorts;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.Dress)))
            {
                return ClothingType.Dress;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.DressPants)))
            {
                return ClothingType.DressPants;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.DressShirt)))
            {
                return ClothingType.DressShirt;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.DressShoes)))
            {
                return ClothingType.DressShoes;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.Flats)))
            {
                return ClothingType.Flats;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.Heels)))
            {
                return ClothingType.Heels;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.Jeans)))
            {
                return ClothingType.Jeans;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.Khakis)))
            {
                return ClothingType.Khakis;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.Polo)))
            {
                return ClothingType.Polo;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.Sandals)))
            {
                return ClothingType.Sandals;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.TennisShoes)))
            {
                return ClothingType.TennisShoes;
            }
            else if (type.Equals(Enum.GetName(typeof(ClothingType), ClothingType.TShirt)))
            {
                return ClothingType.TShirt;
            }
            else
            {
                //throw some type of error
                //type was unreadable
                return ClothingType.TShirt;
            }
        }
    }
}
