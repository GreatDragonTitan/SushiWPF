namespace Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Sushi;

    [TestClass]
    public class ViewModelTesting
    {
        [TestMethod, ExpectedException(typeof(Exception), "File does not exists.")]
        public void WrongConstructorTest()
        {
            ViewModel test = new ViewModel("");
        }

        [TestMethod]
        public void ConstructorTest()
        {
            ViewModel test = new ViewModel("test.txt");
            SushiOrder testOrder_1 = new SushiOrder("test sushi 1", 3, 1);
            SushiOrder testOrder_2 = new SushiOrder("test sushi 2", 2, 2);
            SushiOrder testOrder_3 = new SushiOrder("test sushi 3", 4, 3);
            int testCount = 3;

            Assert.AreEqual(testOrder_1.Name, test.Orders[0].Name);
            Assert.AreEqual(testOrder_1.Number, test.Orders[0].Number);
            Assert.AreEqual(testOrder_1.Quantity, test.Orders[0].Quantity);

            Assert.AreEqual(testOrder_2.Name, test.Orders[1].Name);
            Assert.AreEqual(testOrder_2.Number, test.Orders[1].Number);
            Assert.AreEqual(testOrder_2.Quantity, test.Orders[1].Quantity);

            Assert.AreEqual(testOrder_3.Name, test.Orders[2].Name);
            Assert.AreEqual(testOrder_3.Number, test.Orders[2].Number);
            Assert.AreEqual(testOrder_3.Quantity, test.Orders[2].Quantity);

            Assert.AreEqual(testCount, test.Orders.Count);
        }

        [TestMethod, ExpectedException(typeof(Exception), "Cannot parse quantity value.")]
        public void WrongQuantityTest()
        {
            ViewModel test = new ViewModel("test_1");
        }

        [TestMethod]
        public void DeleteTest()
        {
            ViewModel test = new ViewModel("test.txt");
            SushiOrder testOrder_1 = new SushiOrder("test sushi 1", 3, 1);
            SushiOrder testOrder_2 = new SushiOrder("test sushi 2", 2, 2);
            SushiOrder testOrder_3 = new SushiOrder("test sushi 3", 4, 3);
            int testCount = 2;

            test.Delete();

            Assert.AreEqual(testOrder_2.Name, test.Orders[0].Name);
            Assert.AreEqual(testOrder_2.Number, test.Orders[0].Number);
            Assert.AreEqual(testOrder_2.Quantity, test.Orders[0].Quantity);

            Assert.AreEqual(testOrder_3.Name, test.Orders[1].Name);
            Assert.AreEqual(testOrder_3.Number, test.Orders[1].Number);
            Assert.AreEqual(testOrder_3.Quantity, test.Orders[1].Quantity);

            Assert.AreEqual(testCount, test.Orders.Count);
        }

        [TestMethod]
        public void SaveTest()
        {
            ViewModel test = new ViewModel("test.txt");
            SushiOrder testOrder_1 = new SushiOrder("Filadelfia roll", 9, 1);
            SushiOrder testOrder_2 = new SushiOrder("Great roll", 12, 2);
            SushiOrder testOrder_3 = new SushiOrder("Filadelfia roll", 23, 3);
            int testCount = 3;

            test.Orders[0] = testOrder_1;
            test.Orders[1] = testOrder_2;
            test.Orders[2] = testOrder_3;

            test.Path = "test_2.txt";

            test.Save();

            ViewModel test_2 = new ViewModel("test_2.txt");

            Assert.AreEqual(testOrder_1.Name, test_2.Orders[0].Name);
            Assert.AreEqual(testOrder_1.Number, test_2.Orders[0].Number);
            Assert.AreEqual(testOrder_1.Quantity, test_2.Orders[0].Quantity);

            Assert.AreEqual(testOrder_2.Name, test_2.Orders[1].Name);
            Assert.AreEqual(testOrder_2.Number, test_2.Orders[1].Number);
            Assert.AreEqual(testOrder_2.Quantity, test_2.Orders[1].Quantity);

            Assert.AreEqual(testOrder_3.Name, test_2.Orders[2].Name);
            Assert.AreEqual(testOrder_3.Number, test_2.Orders[2].Number);
            Assert.AreEqual(testOrder_3.Quantity, test_2.Orders[2].Quantity);

            Assert.AreEqual(testCount, test_2.Orders.Count);
        }
    }
}
