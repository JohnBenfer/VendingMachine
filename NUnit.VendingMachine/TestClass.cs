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
    public class TestClass
    {
        [Test]
        public void Test1()
        {
            string path = "U:/HW4/sampleStock\n.25\n.25";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            VendingMachine vending = new VendingMachine();
            vending.insertMoney();
            vending.insertMoney();
            Assert.AreEqual(vending.Balance, 0.5);

        }

        [Test]
        public void Test2()
        {

            string path = "U:/HW4/sampleStock\n1\n.25\n.25\n.25\n.25\nr";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            VendingMachine vending = new VendingMachine();
            vending.insertMoney();
            vending.insertMoney();
            vending.insertMoney();
            vending.insertMoney();
            vending.insertMoney();
            vending.dispenseChange();
            Assert.AreEqual(vending.Balance, 0);

        }

        [Test]
        public void Test3()
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


        [Test]
        public void Test4()
        {

            string path = "U:/HW4/sampleStock\n1\n1\n0";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            VendingMachine vending = new VendingMachine();

            vending.insertMoney();
            vending.insertMoney();
            vending.dispenseSelection();

            Assert.AreEqual(vending.Selection, 0);

        }

        [Test]
        public void Test5()
        {

            string path = "U:/HW4/sampleStock\n1\n1\n0";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            VendingMachine vending = new VendingMachine();

            vending.insertMoney();
            vending.insertMoney();
            vending.dispenseSelection();

            Assert.AreEqual(vending.Stock[0].name, "Cola");

        }

        [Test]
        public void Test6()
        {

            string path = "U:/HW4/sampleStock\n1\n1\n0";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            VendingMachine vending = new VendingMachine();

            vending.insertMoney();
            vending.insertMoney();
            vending.dispenseSelection();

            Assert.AreEqual(vending.Stock[vending.Selection].name , vending.Stock[0].name);

        }

        [Test]
        public void Test7()
        {

            string path = "U:/HW4/sampleStock\n1\n1\n0";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            VendingMachine vending = new VendingMachine();

            vending.insertMoney();
            vending.insertMoney();
            vending.dispenseSelection();

            Assert.AreEqual(vending.Balance, 0.75);

        }

        [Test]
        public void Test8()
        {

            string path = "U:/HW4/sampleStock\n1\n1\n0";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            VendingMachine vending = new VendingMachine();

            vending.insertMoney();
            vending.insertMoney();
            vending.dispenseSelection();
            vending.dispenseChange();

            Assert.AreEqual(vending.Balance, 0);

        }
        /// <summary>
        /// Tests for the vending machine accepting invalid currency amount.
        /// </summary>
        [Test]
        public void Test9()
        {
            string path = "U:/HW4/sampleStock\n.07";
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(path);
            writer.Flush();
            stream.Position = 0;
            Console.SetIn(new StreamReader(stream));

            VendingMachine vending = new VendingMachine();

            vending.insertMoney();

            Assert.AreNotEqual(vending.Balance, 0.07);

        }



    }
}
