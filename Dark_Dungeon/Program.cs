Main();
void Main()
{
    string message = "";
    string[,] map = new string[4, 4];
    int torch = 3;
    int playerX = 1;
    int playerY = 1;
    //Player's previous coordinates
    int playerPX = 1;
    int playerPY = 1;
    //Enemy's coordinates
    int enemyX = 3;
    int enemyY = 3;
    Movement();



    void DrawMap()
    {
        //Fill the players location with an X
        map[playerY, playerX] = "[x]";
        map[enemyY, enemyX] = "[!]";
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

    //Allows the player to move
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
            //Set message for all rooms
            message = $"You are in {playerX}, {playerY}.";
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
            //Set message for all rooms
            message = $"You are in {playerX}, {playerY}.";
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
            //Set message for all rooms
            message = $"You are in {playerX}, {playerY}.";
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
            //Set message for all rooms
            message = $"You are in {playerX}, {playerY}.";
        }

        //Makes torches functional
        else if(input.Contains("torch"))
        {
            if (torch > 0)
            {
                message = "you used a torch!";
                torch -= 1;
            }
            else
            {
                message = "torch not found!";
            }
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
        //Enemy();
        Reaction();
    }

    //Prints a response depending on the player's actions
    void Reaction()
    {
        Walls();
        Enemy();
        DrawMap();

        //Check specific room
        if (playerX == 2 && playerY == 1)
        {
            message = "There is a bunch of glowing blue mushrooms on the floor";
        }
        Console.WriteLine("\n" + message);
        Console.WriteLine("Monster is in " + (enemyY) + (enemyX));
        Console.WriteLine("torches: x" + torch);
        Movement();
    }

    void Enemy()
    {
        Random rand = new Random();
        int directionE = rand.Next(0, 3);
        if (directionE == 0)
        {
            if (enemyY != 0)
            {
                enemyY -= 1;
            }
            else
            {
                Enemy();
            }
        }

        else if (directionE == 1)
        {
            if (enemyY != 3)
            {
                enemyY += 1;
            }
            else
            {
                Enemy();
            }
        }

        else if (directionE == 2)
        {
            if (enemyX != 0)
            {
                enemyX -= 1;
            }
            else
            {
                Enemy();
            }
        }

        else if (directionE == 3)
        {
            if (enemyX != 3)
            {
                enemyX += 1;
            }
            else
            {
                Enemy();
            }
        }
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


