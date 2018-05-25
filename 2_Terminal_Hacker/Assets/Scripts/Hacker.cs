using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    string[] level1Passwords = { "table", "chair", "pencil", "mug", "mouse"};
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
    }

    void RunMainMenu(string input)
    {
        if (input == "1")
        {
            level = 1;
            currentScreen = Screen.Password;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            currentScreen = Screen.Password;
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            currentScreen = Screen.Password;
            StartGame();
        }
        else if (input == "load up celery man")
        {
            Terminal.WriteLine("Certainly, Paul :) ");
        }
        else
        {
            Terminal.WriteLine("Please enter a valid selection");
        }
    }

    void StartGame()
    {
        if (level == 1)
        {
            password = level1Passwords[0]; // todo: random number generator
        }
        else if (level == 2)
        {
            password = level2Passwords[0];
        }
        else if (level == 3)
        {
            password = level3Passwords[0];
        }
        Terminal.WriteLine("You chose level " + level);
        Terminal.WriteLine("Please enter password");
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            currentScreen = Screen.Win;
            Terminal.WriteLine("");
            Terminal.WriteLine("Correct password!Congratulations");
            Terminal.WriteLine("Hit enter to play again!");
        }
        else
        {
            Terminal.WriteLine("");
            Terminal.WriteLine("Incorrect password!");
            Terminal.WriteLine("You have infinite tries remaining!");
            Terminal.WriteLine("Please enter password");
        }
    }
}


