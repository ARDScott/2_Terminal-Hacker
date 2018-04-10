using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string menuHint = "You may type menu at any time.";
    string[][] passwords = {
        new string[] { "books", "aisle", "shelf", "password", "font", "borrow" },
        new string[] { "prisoner", "handcuffs", "holster", "uniform", "arrest", "criminal" },
        new string[] { "starfield", "telescope", "environment", "exploration", "astronauts", "cosmonauts" }
    };

    // Game state
    enum Screen
    {
        MainMenu,
        Password,
        Win
    };
    int level;
    Screen currentScreen = Screen.MainMenu;
    string password;

    // Use this for initialization
    void Start ()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for NASA\n");
        Terminal.WriteLine("Enter your selection:");
    }
    
    void OnUserInput(string input)
    {
        if (input.ToLower() == "menu") // We can always go directly to main menu
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            RunPassword(input);
        }
    }

    private void RunPassword(string input)
    {
        if (input == password) // TODO: Make random later
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    private void ShowLevelReward()
    {
        switch (level)
        {
            case 0:
                Terminal.WriteLine("No more overdue books...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /______//
(______(/
"
                );
                Terminal.WriteLine("Play again for a greater challenge!");
                break;
            case 1:
                Terminal.WriteLine("Good work, you've earned this!");
                Terminal.WriteLine(@"
   ____
.'` __ `'.
|  '--'  |
\`------`/
 `------`
"
                );
                Terminal.WriteLine("Play again for a greater challenge!");
                break;
            case 2:
                Terminal.WriteLine("Welcome to NASA's internal system!");
                Terminal.WriteLine(@"
 ()    .-.,='``'=.      |  
       '=/_       \   - o -
    *   | '=. _    |    |
         \     `=./`, '
      .   '=.__.=' `= '      *
"
                );
                Terminal.WriteLine("Play again for a greater challenge!");
                break;
            default:
                Debug.Log("Invalid level reached");
                break;
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input) - 1;
            AskForPassword();
        }
        else if (input == "007") // Easter Egg
        {
            Terminal.WriteLine("Please select a level, Mr. Bond.");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    private void SetRandomPassword()
    {
        int index = Random.Range(0, passwords[level].Length);
        password = passwords[level][index];
    }
}
