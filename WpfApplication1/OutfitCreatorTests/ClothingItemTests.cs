using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication1;

namespace OutfitCreatorTests
{
    [TestClass]
    public class ClothingItemTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            ClothingItem testShirt = new ClothingItem(ClothingType.TShirt, ClothingColor.Red, "RA Shirt");
            Assert.AreEqual(0b00011, testShirt.EventType);
            Assert.IsTrue(testShirt.CompareEventType(0b00010));
            Assert.IsFalse(testShirt.CompareEventType(0b10000));
        }
    }
}
