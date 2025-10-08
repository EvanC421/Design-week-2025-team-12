using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dark_Dungeon
{
    internal class Wall
    {
        public int xLocation;
        public int yLocation;

        string apperance = "O";

        public Wall(int xLocation, int yLocation)
        {
            this.xLocation = xLocation;
            this.yLocation = yLocation;
        }

        public void DrawWall()
        {
            int oldCursorX = Console.CursorLeft;
            int oldCursorY = Console.CursorTop;

            Console.CursorLeft = xLocation * 3 + 1;
            Console.CursorTop = yLocation;
            Console.Write(apperance);
            Console.CursorLeft = oldCursorX;
            Console.CursorTop = oldCursorY;
        }

    }
}
