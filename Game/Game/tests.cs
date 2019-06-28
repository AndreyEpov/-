using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    [TestFixture]
    class tests
    {
        [TestCase]
        public void weapon()
        {
            Gaming test = new Gaming();
            Assert.AreEqual(1, test.weapon);
        }

        [TestCase]
        public void armor()
        {
            Gaming test = new Gaming();
            Assert.AreEqual(5, test.armor);
        }

        [TestCase]
        public void weaponp()
        {
            Gaming test = new Gaming();
            test.buyingweapon(6);
            Assert.AreEqual(6, test.weapon);
        }

        //[STAThread]
        //[TestCase]
        //public void forest()
        //{
        //    MainWindow test = new MainWindow();
        //    Assert.AreEqual(false, test.forest);
        //}
    }
}
