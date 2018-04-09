using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
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
        Terminal.WriteLine("Press 3 for the NASA\n");
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
        if (input == passwords[level - 1][0]) // TODO: Make random later
        {
            Terminal.WriteLine("Congrasturbations!");
        }
        else
        {
            Terminal.WriteLine("Wrong again, buffalo breath!");
        }
    }

    private void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
        }
        if (input == "1")
        {
            level = 1;
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level, Mr. Bond.");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }
}
