using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Dungeon
{
    internal class Portals
    {
        public int xLocation;
        public int yLocation;
        string appearance = "P";

        public Portals()
        {
            Random rand = new Random();
            xLocation = rand.Next(0, 9);
            yLocation = rand.Next(0, 9);

        }

        public void DrawPortal()
        {
            int oldCursorX = Console.CursorLeft;
            int oldCursorY = Console.CursorTop;

            Console.CursorLeft = xLocation * 3 + 1;
            Console.CursorTop = yLocation;
            Console.Write(appearance);
            Console.CursorLeft = oldCursorX;
            Console.CursorTop = oldCursorY;
        }
    }
}
