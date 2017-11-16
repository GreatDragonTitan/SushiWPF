namespace Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Sushi;

    [TestClass]
    public class ModelTesting
    {
        [TestMethod]
        public void VoidConstructorTest()
        {
            SushiOrder testOrder = new SushiOrder();
            string expectedName = "None";
            int expectedQuantity = 0;
            int expectedNumber = 0;
            Assert.AreEqual(expectedName, testOrder.Name);
            Assert.AreEqual(expectedQuantity, testOrder.Quantity);
            Assert.AreEqual(expectedNumber, testOrder.Number);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            string expectedName = "SMthhgjhgk78b6e655v65v56vnnn";
            int expectedQuantity = 12;
            int expectedNumber = 234;
            SushiOrder testOrder = new SushiOrder(expectedName, expectedQuantity, expectedNumber);
            Assert.AreEqual(expectedName, testOrder.Name);
            Assert.AreEqual(expectedQuantity, testOrder.Quantity);
            Assert.AreEqual(expectedNumber, testOrder.Number);
        }

        [TestMethod]
        public void RightNumbersTest()
        {
            string expectedName = "Sushi name";
            int expectedQuantity = 0;
            int expectedNumber = 0;
            SushiOrder testOrder = new SushiOrder(expectedName, -1, -8);
            Assert.AreEqual(expectedName, testOrder.Name);
            Assert.AreEqual(expectedQuantity, testOrder.Quantity);
            Assert.AreEqual(expectedNumber, testOrder.Number);
        }

    }
}
