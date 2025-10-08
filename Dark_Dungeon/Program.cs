using Dark_Dungeon;

Main();
void Main()
{
    Wall[] walls = new Wall[] { new Wall(1, 1), new Wall(2, 1), new Wall(2,2), new Wall(2,3), new Wall(2,4), new Wall (0,3), new Wall(0,7), new Wall(0,9), new Wall(1,5), new Wall(2,5), new Wall(2,7), new Wall (2,8), new Wall (3,4), new Wall (3,3), new Wall (3,5), new Wall (3,7), new Wall (4,0), new Wall (4,2), new Wall (4,3), new Wall (4,5), new Wall (4,6), new Wall (4,9), new Wall(5,8), new Wall (5,9), new Wall (6,0), new Wall (6,1), new Wall (6,3), new Wall (6,5), new Wall (6,6), new Wall (6,9), new Wall (7,6), new Wall (7,7), new Wall (8,1), new Wall (8,2), new Wall (8,4), new Wall (8,7), new Wall (8,9), new Wall (9,2), new Wall (9,4), new Wall (9,5)};
   

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
    Movement();

    void DrawMap()
    {
        //Fill the players location with an X
        map[playerY, playerX] = "[x]";
        map[enemyY, enemyX] = "[!]";

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
                direction = "you used a torch!\nThe room around you lights up, and you know exactly where you are! room "+(playerY)+","+(playerX)+"!";
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
        Walls();
        //DrawMap();
       

        if (playerX == enemyX && playerY == enemyY)
        {
            health -= 1;
            Console.WriteLine("You were attacked by a monster! It ran away after.");
            Console.Beep(100, 1000);
            enemyX = 1;
            enemyY = 1;
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
            Console.Beep(200,700); 
        }

        //Check specific room
        if (playerX == 7 && playerY == 3 || playerX == 9 && playerY == 1)
        {
            message = "There is a bunch of glowing blue mushrooms on the floor.";
        }

        if (playerX == 8 && playerY == 8 || playerX == 5 && playerY == 0)
        {
            message = "There is a candlestick with a dim red glow in the middle of the room.";
        }

        if (playerX == 3 && playerY == 1 || playerX == 1  && playerY == 8)
        {
            message = "There is a skeleton lying on the floor.";
        }

        if (playerX == 1 && playerY == 4)
        {
            treasure = true;
            message = "You found the treasure! Now retrace your steps and escape up the stairs.";
        }

        if (playerX == 4 && playerY == 4 && treasure)
        {
            Console.WriteLine("Congradulations! You've escaped the DARK DUNGEON with the treasure in hand. Press ENTER to restart!");
            Main();
        }
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
}