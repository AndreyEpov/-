using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Gaming
    {
        public int hp = 100, hpenemy = 50;
        public bool canfight = true;
        static Random rand = new Random();

       public void hit(int weapon,int armor)
        {
            hpenemy = hpenemy - (1+5 * weapon);
            hp = hp - 10 + armor;
        }
    }
}
