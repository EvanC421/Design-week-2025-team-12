Main();
void Main()
{
    string message = "";
    string[,] map = new string[4, 4];
    int playerX = 1;
    int playerY = 1;
    //The player's previous coordinates
    int playerPX = 1;
    int playerPY = 1;
    Movement();



    void DrawMap()
    {
        //Fill the players location with an X
        map[playerY, playerX] = "[x]";
        map[2, 2] = "[O]";
        map[3, 2] = "[O]";

        //Display every coordinate of the map
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write(map[i, j]);
            }
            Console.WriteLine();
        }
    }

    //The method that allows the player to move
    void Movement()
    {
        String input = Console.ReadLine();
        if (input.Contains("south"))
        {
            if (playerY == 3)
            {
                Console.Clear();
                DrawMap();
                Console.Beep();
                Console.WriteLine("Dead end!");
                Movement();
            }
            playerPY = playerY;
            playerY += 1;
        }

        else if (input.Contains("north"))
        {
            if (playerY == 0)
            {
                Console.Clear();
                DrawMap();
                Console.Beep();
                Console.WriteLine("Dead end!");
                Movement();
            }
            playerPY = playerY;
            playerY -= 1;
        }

        else if (input.Contains("east"))
        {
            if (playerX == 3)
            {
                Console.Clear();
                DrawMap();
                Console.Beep();
                Console.WriteLine("Dead end!");
                Movement();
            }
            playerPX = playerX;
            playerX += 1;
        }

        else if (input.Contains("west"))
        {
            if (playerX == 0)
            {
                Console.Clear();
                DrawMap();
                Console.Beep();
                Console.WriteLine("Dead end!");
                Movement();
            }
            playerPX = playerX;
            playerX -= 1;
        }

            //Set every space on the map to empty
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    map[i, j] = "[ ]";
                }
            }

        Console.Clear();
        Reaction();
    }

    //This method prints a response depending on the player's actions
    void Reaction()
    {
        Walls();
        DrawMap();

        //Set message for all rooms
        message = $"You are in {playerX}, {playerY}.";
        //Check specific room
        if (playerX == 2 && playerY == 1)
        {
            message = "There is a bunch of glowing blue mushrooms on the floor";
        }
        Console.WriteLine("\n" + message);
        Movement();
    }

    void Walls()
    {
        //wall 1
        if (playerX == 2 && playerY >= 2)
        {
            playerY = playerPY;
            playerX = playerPX;
            Console.Beep();
            DrawMap();
            Console.WriteLine("Dead End!");
            Movement();
        }
        else
        {
            playerPY = playerY;
            playerPX = playerX;
        }
    }
}


