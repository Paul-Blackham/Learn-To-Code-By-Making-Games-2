using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    const string menuHint = ("Type 'menu' at any time to return to main menu");
    string[] level1Passwords = { "table", "chair", "pencil", "mug", "mouse", "poop"};
    string[] level2Passwords = { "magnetic", "massive", "keyboard", "speaker", "controller" };
    string[] level3Passwords = { "argonaut", "phylosophy", "explosion", "corsair", "impartial" };

    // Game State
    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

	// Use this for initialization
	void Start ()
    {
        ShowMainMenu("Good morning Paul");
    }

    // only handles user input, not what to do with it
    void OnUserInput(string input)
    {
        if (input == "menu")// correct
        {
            ShowMainMenu("Certainly, Paul");
        }
        else if ( currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
        else if (currentScreen == Screen.Win)
        {
            ShowMainMenu("Play again!");
        }
        
    }

    void ShowMainMenu (string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine(" ");
        Terminal.WriteLine("What game related low value target would you like to hack today?");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Press 1 for   -   My home PC");
        Terminal.WriteLine("Press 2 for   -   GAME store");
        Terminal.WriteLine("Press 3 for   -   My dev server");
        Terminal.WriteLine(" ");
        Terminal.WriteLine("Enter your selection:");
        Terminal.WriteLine(" ");
        Terminal.WriteLine(menuHint);
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "load up celery man")
        {
            Terminal.WriteLine("Yes, Paul :) "); // easter egg
        }
        else
        {
            Terminal.WriteLine("Please enter a valid selection");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine(menuHint);
        SetRandomPassword();
        Terminal.WriteLine("Enter your password: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Correct password!Congratulations... just don't look at my search history :S");
                Terminal.WriteLine(@"
.______________
| ___________ |
| |         | |
| |         | |
| |_________| |
|_____________|
      ) (
     |___|

 /#######|     |
/########|     0");
                Terminal.WriteLine("Hit enter to play again!");
                break;
            case 2:
                Terminal.WriteLine("Correct password!Congratulations... Here, have this controller! Be sure to get GAMEcare!");
                Terminal.WriteLine(@"


 _   _
/*o o#\

^ is that a controler?...");
                Terminal.WriteLine("Hit enter to play again!");
                break;
            case 3:
                Terminal.WriteLine("Correct password!Congratulations... All our dirty secrets");
                Terminal.WriteLine(@"
1010110001101100
1010001 0010101010
101010 0010101 1010
1010010100 01010101
01010100 10101010
10010101010101010");
                Terminal.WriteLine("Hit enter to play again!");
                break;
        }
    }
}


