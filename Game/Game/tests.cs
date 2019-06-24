using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [TestFixture]
    class tests
    {
        [TestCase]
        public void fight()
        {
            Gaming game = new Gaming();
            //game.hit(0, 0);
            Assert.AreEqual(49, game.hpenemy);
            Assert.AreEqual(90, game.hp);
        }
    }
}
