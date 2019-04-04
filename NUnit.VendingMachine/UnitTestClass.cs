using NUnit.Framework;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit.VendingMachine
{
    [TestFixture]
    public class UnitTestClass
    {
        [TestCase(".25\n.25", 0.5, 2)]
        [TestCase("1\n.1\n.25", 1.35, 3)]
        public void TestCorrectBalance(string s, double total, int num)
        {
            string path = "U:/HW4/sampleStock\n" + s;
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            VendingMachine vending = new VendingMachine();
            for (int i = 0; i < num; i++)
            {
                vending.insertMoney();
            }

            Assert.AreEqual(vending.Balance, total);

        }
        

        [Test]
        public void TestRestock()
        {

            string path = "U:/HW4/sampleStock\nr\nU:/HW4/restock1";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));
            VendingMachine vending = new VendingMachine();
            vending.restock();
            Assert.GreaterOrEqual(vending.Stock[1].count, 0);

        }
        
        /// <summary>
        /// Tests for the vending machine accepting invalid currency amount.
        /// </summary>
        [TestCase(0.02)]
        [TestCase(0.75)]
        [TestCase(0.07)]
        public void TestInvalidCoin(double coin)
        {
            string path = "U:/HW4/sampleStock\n" + coin.ToString();
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            VendingMachine vending = new VendingMachine();
            vending.insertMoney();
            Assert.AreNotEqual(vending.Balance, coin);
        }

        [Test]
        public void TestReadFile()
        {
            string path = "U:/HW4/sampleStock\nU:/HW4/sampleStock";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            VendingMachine vending = new VendingMachine();
            List<string> s = vending.readFile();
            Assert.AreEqual(s[0], "Cola,1.25,3");
        }

        [Test]
        public void TestExit()
        {
            string path = "U:/HW4/sampleStock\ne";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            VendingMachine vending = new VendingMachine();
            vending.start();
            Assert.AreEqual(vending.Status, VendingMachine.State.OFF);
        }

        [Test]
        public void TestMain()
        {
            string path = "U:/HW4/sampleStock\ne";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            try
            {
                MainClass.Main(null);
            } catch (Exception) {
                Assert.Fail();
            }
        }


    }
}
