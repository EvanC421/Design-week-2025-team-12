// See https://aka.ms/new-console-template for more information
string message = "";
string[,] map = new string[3,3];
int playerX = 0;
int playerY = 0;


    //The method that allows the player to move
    void Movement()
{

    //Set every space on the map to empty
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            map[i, j] = "[ ]";
        }
    }


    String input = Console.ReadLine();
    if (input.Contains("South"))
    {
        playerY += 1;
    }

    //Fill the players location with an X
    map[playerY, playerX] = "[x]";

    //Display every coordinate of the map
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write(map[i, j]);
        }
        Console.WriteLine();
    }

    //Set message for all rooms
    message = $"You are in {playerX}, {playerY}.";

    //Check specific room
    if (playerX == 2 && playerY == 3)
    {
        message = "You are in room 2,3";
    }


    Console.WriteLine("\n" + message);
    Console.ReadKey();
    Console.Clear();
}



