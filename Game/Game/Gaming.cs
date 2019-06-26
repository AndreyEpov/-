using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Gaming
    {
        public int hp = 100, hpenemy = 50, gold = 0, heal = 0;
        public int weapon = 1, armor = 5;
        public bool canfight = true;
        static Random rand = new Random();

        public void rewarding(int reward)
        {
            gold = gold + reward;
        }

        public void output()
        {

        }

        public void spendinggold(int cost)
        {
            gold = gold + cost;
        }

        public void buyingheal(int healp)
        {
            heal = heal + healp;
        }

        public void buyingarmor(int armorp)
        {
            armor = armorp;
        }

        public void buyingweapon(int weaponp)
        {
            weapon = weaponp;
        }

        //public void hit(int weapon,int armor)
        // {
        //     hpenemy = hpenemy - (1+5 * weapon);
        //     hp = hp - 10 + armor;
        // }
    }
}
