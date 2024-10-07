Main();

static void Main()
{
    Menu();
    GetMenuSelection();
}

static void Menu()
{
    Console.WriteLine("Main Menu");
    Console.WriteLine("Select an option:");
    Console.WriteLine("1 - encrypt text");
    Console.WriteLine("2 - decrpyt text");
    Console.WriteLine("0 - End");
}

static void GetMenuSelection()
{
    try
    {
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 0)
        {
            // Close the console app
            Environment.Exit(0);
        }
        if (choice == 1)
        {
            Console.WriteLine("Enter a string to wish to encrypt:");
            string str = Console.ReadLine();
            Console.WriteLine("Enter number of rotations ");
            int noOfRotations = Convert.ToInt32(Console.ReadLine());
            string encrypt = Encrypt(str, noOfRotations);
            // Print sentence that was entered
            // // along with number of words
            Console.WriteLine($"The sentence you inputted is: {str}");
            Console.WriteLine($"The encrypted sentence is now : {encrypt}");
        }
        if (choice == 2)
        {
            Console.WriteLine("Enter a string to wish to decrypt:");
            string str = Console.ReadLine();
            Console.WriteLine("Enter number of rotations ");
            int noOfRotations = Convert.ToInt32(Console.ReadLine());
            string decrypt = Decrypt(str, noOfRotations);
            // Print sentence that was entered
            // // along with number of words
            Console.WriteLine($"The sentence you inputted is: {str}");
            Console.WriteLine($"The decrypted sentence is now : {decrypt}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error. {ex.Message}");
    }
}

static string Encrypt(string stringToEncrpty, int rotation)
{
    string encodedText = "";
    foreach (char c in stringToEncrpty) // for each char in the string S
    {
        // check if the current char is a letter
        {
            // If it isnt, we'll not rotate the character
            if (!char.IsLetter(c))
            {
                encodedText += c;
            }
            else // must be a letter so encrypt it
            {
                int encodedChar = c + rotation;

                // check if the character is in
                // upper or lower case
                // because we need to reset the
                // encoded value to 0 if we've reached
                // z or Z characters
                if (char.IsLower(c))
                {
                    if (encodedChar > 'z')
                    {
                        // Go back to a
                        encodedChar -= 26;
                    }
                }
                else if (char.IsUpper(c))
                {
                    if (encodedChar > 'Z')
                    {
                        // go back to A
                        encodedChar -= 26;
                    }
                }
                // concatenate char we're examining
                // in this iteration of the loop to string
                encodedText += (char)encodedChar;
            }
        }
    }
    return encodedText;
}

static string Decrypt(string stringToDecrypt, int rotation)
{
    string decodedText = "";
    foreach (char c in stringToDecrypt) // for each char in the string
    {
        // check if the current char is a letter
        if (!char.IsLetter(c))
        {
            // If it isn't, we'll not rotate the character
            decodedText += c;
        }
        else // must be a letter so decrypt it
        {
            int decodedChar = c - rotation;

            // check if the character is in
            // upper or lower case
            // because we need to reset the
            // decoded value to z or Z if we've reached
            // a or A characters
            if (char.IsLower(c))
            {
                if (decodedChar < 'a')
                {
                    // Go back to z
                    decodedChar += 26;
                }
            }
            else if (char.IsUpper(c))
            {
                if (decodedChar < 'A')
                {
                    // go back to Z
                    decodedChar += 26;
                }
            }
            // concatenate char to string
            decodedText += (char)decodedChar;
        }
    }
    return decodedText;
}