using Dark_Dungeon;

Main();
void Main()
{
    Random rand = new Random();
    int treasureX = 0;
    int treasureY = 0;
    int treasureSpawn = rand.Next(0, 3);
    if (treasureSpawn == 0)
    {
        treasureX = 2;
        treasureY = 4;
    }
    else if (treasureSpawn == 1)
    {
        treasureX = 9;
        treasureY = 1;
    }

    else if (treasureSpawn == 2)
    {
        treasureX = 9;
        treasureY = 9;
    }
    Wall[] walls = new Wall[] { new Wall(1, 1), new Wall(2, 1), new Wall(2, 2), new Wall(2, 3), new Wall(0, 3), new Wall(0, 7), new Wall(0, 9), new Wall(1, 5), new Wall(2, 5), new Wall(2, 7), new Wall(2, 8), new Wall(3, 4), new Wall(3, 3), new Wall(3, 5), new Wall(3, 7), new Wall(4, 0), new Wall(4, 2), new Wall(4, 3), new Wall(4, 5), new Wall(4, 6), new Wall(4, 9), new Wall(5, 8), new Wall(5, 9), new Wall(6, 0), new Wall(6, 1), new Wall(6, 3), new Wall(6, 5), new Wall(6, 6), new Wall(6, 9), new Wall(7, 6), new Wall(7, 7), new Wall(8, 1), new Wall(8, 2), new Wall(8, 4), new Wall(8, 7), new Wall(8, 9), new Wall(9, 2), new Wall(9, 4), new Wall(9, 5) };
    Portals[] portals = new Portals[] {new Portals(), new Portals(), new Portals()};
    int HroomX = rand.Next(0, 9);
    int HroomY = rand.Next(0, 9);
    for (int i = 0; i < portals.Length; i++)
    {
        if (portals[i].xLocation == walls[i].xLocation && portals[i].yLocation == walls[i].yLocation || portals[i].xLocation == 5 && portals[i].yLocation == 4 || portals[i].xLocation == 4 && portals[i].xLocation == 4 || portals[i].xLocation == treasureX && portals[i].yLocation == treasureY)
        {
            Main();
        }

        if (HroomX == walls[i].xLocation && HroomY == walls[i].yLocation || HroomX == 5 && HroomY == 4 || HroomX == 4 && HroomY == 4 || HroomX == treasureX && HroomY == treasureY || HroomX == portals[i].xLocation && HroomY == portals[i].yLocation)
        {
            Main();
        }
    }

    string message = "";
    string direction = "";
    string[,] map = new string[10, 10];
    int torch = 3;
    int health = 3;
    int playerX = 5;
    int playerY = 4;
    int boundMin = 0;
    int boundMaxY = 9;
    int boundMaxX = 9;
    bool treasure = false;
    //Player's previous coordinates
    int playerPX = 1;
    int playerPY = 1;
    //Enemy's coordinates
    int enemyX = 0;
    int enemyY = 0;
    //Enemy's previous coordinates
    int enemyPX = 0;
    int enemyPY = 0;
    //amount of moves player has made
    int moves = 0;

        //Title screen
        Console.WriteLine(" __ \\                |                         \r\n |   |   _` |   __|  |  /                      \r\n |   |  (   |  |       <                       \r\n____/  \\__,_| _|    _|\\_\\                      \r\n __ \\                                          \r\n |   |  |   |  __ \\    _` |   _ \\   _ \\   __ \\ \r\n |   |  |   |  |   |  (   |   __/  (   |  |   |\r\n____/  \\__,_| _|  _| \\__, | \\___| \\___/  _|  _|\r\n                     |___/                     ");
    Console.WriteLine("You are an adventurer. You have traveled the land conquering the worst the world has for you. Your reputation in the lands precede you as you take on any quest that is needed of you. You journey to the central hub of the adventures guild where a new quest catches your eye, a mysterious dungeon has been discovered, with treasures no man nor woman have ever seen before. Seeing your chance you take up this quest and head out to obtain the glorious treasures that await you inside. While investigating sightings of the ever illusive dungeon that changes locations after taking victims, you come across the dungeon, aged stone leading underground. But on the floor at the top of the stairs you see a piece of parchment, hastily scribbled on the paper is a map. You quickly gather that this is a map of the dungeon itself.");
    Console.WriteLine("\nPress ENTER to play");
    Movement();

    void DrawMap()
    {
        //Fill the players location with an X
        map[playerY, playerX] = "[x]";
        map[enemyY, enemyX] = "[!]";
        map[HroomY, HroomX] = "[H]";

        //Display every coordinate of the map
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }
        for (int i = 0; i < walls.Count(); i++)
        {
            walls[i].DrawWall();
        }
        for (int i = 0; i < portals.Count(); i++)
        {
            portals[i].DrawPortal();
        }
    }

    //Allows the player to move
    void Movement()
    {
        message = "";
        String input = Console.ReadLine();
        if (input.Contains("south"))
        {
            if (playerY == boundMaxY)
            {
                Console.Clear();
                Console.Beep();
                message = "Dead end!";
                Reaction();
            }
            playerPY = playerY;
            playerY += 1;
            direction = "You went south";
            //Set message for all rooms
            //message = $"You are in {playerX}, {playerY}.";
        }

        else if (input.Contains("north"))
        {
            if (playerY == boundMin)
            {
                Console.Clear();
                Console.Beep();
                message = "Dead end!";
                Reaction();
            }
            playerPY = playerY;
            playerY -= 1;
            direction = "You went north";
            //Set message for all rooms
            //message = $"You are in {playerX}, {playerY}.";
        }

        else if (input.Contains("east"))
        {
            if (playerX == boundMaxX)
            {
                Console.Clear();
                Console.Beep();
                message = "Dead End!";
                Reaction();
            }
            playerPX = playerX;
            playerX += 1;
            direction = "You went east";
            //Set message for all rooms
            //message = $"You are in {playerX}, {playerY}.";
        }

        else if (input.Contains("west"))
        {
            if (playerX == boundMin)
            {
                Console.Clear();
                Console.Beep();
                message = "Dead end!";
                Reaction();
            }
            playerPX = playerX;
            playerX -= 1;
            direction = "You went west";
            //Set message for all rooms
            //message = $"You are in {playerX}, {playerY}.";
        }

        //Makes torches functional
        else if (input.Contains("torch"))
        {
            if (torch > 0)
            {
                direction = "you used a torch!\nThe room around you lights up, and you know exactly where you are! room Y"+(playerY)+", X"+(playerX)+"!";
                torch -= 1;
            }
            else
            {
                message = "torch not found!";
            }
        }

        //Set every space on the map to empty
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                map[i, j] = "[ ]";
            }
        }

        Console.Clear();
        Reaction();
    }

    //Prints a response depending on the player's actions
    void Reaction()
    {
        Enemy();
        for (int i = 0; i < portals.Count(); i++)
        {
            if(playerX == portals[i].xLocation && playerY == portals[i].yLocation)
            {
                Warp();
            }
        }
        Walls();
        //DrawMap();
        Console.WriteLine("You can type 'south' to go down a tile, 'north' to go up a tile, 'west' to go left a tile and 'east' to go right a tile.");

        if (playerX == enemyX && playerY == enemyY)
        {
            health -= 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You were attacked by the minotaur! It ran away after.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Beep(200, 700);
            enemyX = 0;
            enemyY = 0;
            if (health <= 0)
            {
                Console.Clear();
                Console.WriteLine("GAME OVER\n\nPress ENTER to try again");
                Main();
            }
        }
        //check if minotaur is near
        if (playerY+1 >= enemyY && playerY-1 <= enemyY && playerX+1 >= enemyX && playerX-1 <= enemyX)
        {
            Console.Beep(400,1500);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You hear a low roaring... The Minotaur draws near.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Check specific room for landmarks
        if (playerX == 7 && playerY == 0 || playerX == 4 && playerY == 7 || playerX == 8 && playerY == 6)
        {
            message = "As you walk through the endless maze of the dungeon, you stumble across an area filled with a fluorescent blue light. As you gaze at the mesmerizing lights you notice the mushrooms scattered across the room. This seems like an important landmark to remember, you keep track of it on your map.";
        }
        if (playerX == 6 && playerY == 2 || playerX == 2 && playerY == 6 || playerX == 8 && playerY == 8)
        {
            message = "Walking through the cold dark of the dungeon, you find a room filled with lit candles. How did it stay like this? Who keeps these candles lit and for how long have they been lit for? Regardless you enjoy the warm light coming from the candles and mark this area on the map.";
        }
        if (playerX == 3 && playerY == 1 || playerX == 1  && playerY == 8 || playerX == 1 && playerY == 2)
        {
            message = "As you walk through this bone chilling dungeon you notice a room filled with skeletons, each one looking decayed and worse than the last.";
        }
        if (playerX == 5 && playerY == 4)
        {
            message = "You bear witness to a grand tree standing tall before you. You are unsure how this tree managed to grow to such lengths down here, nor do you know how it still lives, regardless however you make sure to keep track of it on your map, a good waypoint to find when you want to leave.";
        }

        //Check specific room for fountain of life
        if (playerX == HroomX && playerY == HroomY)
        {
            health = 3;
            message = "Feeling exhausted from the journey so far in the dungeon battered and bruised you discover a strange magic surrounding you as you approach a glowing,flowing fountain. As you approach it you decide to drink from it and feel rejuvenated, it seems this fountain can heal you of any injuries. You decide to mark this place down on your map in case of an emergency later on.";
        }
        //Check specific room for treasure
        if (playerX == treasureX && playerY == treasureY)
        {
            treasure = true;
            Console.ForegroundColor = ConsoleColor.Yellow;
            message = "You found the treasure! Now retrace your steps and escape up the stairs.";
            Console.ForegroundColor = ConsoleColor.White;
        }

        if (playerX == 4 && playerY == 4 && treasure)
        {
            Console.Clear();
            Console.WriteLine("Congradulations! You've escaped the DARK DUNGEON with the treasure in hand.\nYou took "+moves+" moves to escape. Can you go lower?\nPress ENTER to play again!");
            Main();
        }
        moves += 1;
        Console.WriteLine(direction);
        Console.WriteLine(message);
        Console.WriteLine("torches: x" + torch + "\nhealth: x" + health);
        Movement();
    }

    //Allows the enemy to move around randomly
    void Enemy()
    {
        Random rand = new Random();
        int directionE = rand.Next(0, 4);
        if (directionE == 0)
        {
            if (enemyY != boundMin)
            {
                enemyY -= 1;
                Walls();
            }
            else
            {
                Enemy();
            }
        }

        else if (directionE == 1)
        {
            if (enemyY != boundMaxY)
            {
                enemyY += 1;
                Walls();
            }
            else
            {
                Enemy();
            }
        }

        else if (directionE == 2)
        {
            if (enemyX != boundMin)
            {
                enemyX -= 1;
                Walls();
            }
            else
            {
                Enemy();

            }
        }

        else if (directionE == 3)
        {
            if (enemyX != boundMaxX)
            {
                enemyX += 1;
                Walls();
            }
            else
            {
                Enemy();
            }
        }
       
        enemyPX = enemyX;
        enemyPY = enemyY;
    }

    //Builds walls in the level
    void Walls()
    {
        for (int i = 0; i < walls.Count(); i++)
        {

            if (playerX == walls[i].xLocation && playerY == walls[i].yLocation)
            {
                playerY = playerPY;
                playerX = playerPX;
                Console.Clear();
                Console.Beep();
                message = "Dead End!";
                Reaction();
            }

            if (enemyX == walls[i].xLocation && enemyY == walls[i].yLocation)
            {
                enemyX = enemyPX;
                enemyY = enemyPY;
                Enemy();
            }
        }

        playerPY = playerY;
        playerPX = playerX;
    }

    //Makes portal rooms send the player to a new room at random
    void Warp()
    {
        playerPX = playerX;
        playerPY = playerY;
        Random rand = new Random();
        playerX = rand.Next(0, 9);
        playerY = rand.Next(0, 9);

        for (int i = 0; i < walls.Count(); i++)
        {

            if (playerX == walls[i].xLocation && playerY == walls[i].yLocation || playerX == 2 && playerY == 4)
            {
                playerY = playerPY;
                playerX = playerPX;
                Console.Clear();
                Warp();
            }
        }
        direction = "As you venture through the dungeon, you step on some ancient looking magic runes as the magic begins to swirl around you and suddenly you find yourself in a new room. It seems you found magic teleporters, but where did they take you? Explore around for landmarks or use a torch to find out! Make sure you mark down the teleporter so you don't step on it again.\r\n";
        Reaction();
    }
}