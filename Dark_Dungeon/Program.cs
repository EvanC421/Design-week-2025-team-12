Main();
void Main()
{
    string message = "";
    string[,] map = new string[4, 4];
    int playerX = 1;
    int playerY = 1;

    Movement();

    void DrawMap()
    {
        //Fill the players location with an X
        map[playerY, playerX] = "[x]";

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
        if (input.Contains("South"))
        {
            if (playerY == 3)
            {
                Console.Clear();
                DrawMap();
                Console.Beep();
                Console.WriteLine("Dead end!");
                Movement();
            }
            playerY += 1;
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
        DrawMap();

        //Set message for all rooms
        message = $"You are in {playerX}, {playerY}.";
        //Check specific room
        if (playerX == 2 && playerY == 1)
        {
            message = "You are in room 2,1";
        }
        Console.WriteLine("\n" + message);
        Movement();
    }
}


