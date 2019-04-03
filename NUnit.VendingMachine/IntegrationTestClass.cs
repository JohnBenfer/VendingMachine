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
    public class IntegrationTestClass
    {
        

        [Test]
        public void TestDispenseChangeNormal()
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
        public void TestDispenseSelection1()
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
        public void TestDispenseSelection2()
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
        public void TestDispenseSelection3()
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
        public void TestDispenseSelectionRemainingBalance()
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
        public void TestDispenseSelectionAndBalanceRemainingBalance()
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

    }
}
