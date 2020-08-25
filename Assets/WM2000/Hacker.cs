using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data

    string[] levelOnePasswords = {"books", "aisle", "self", "password", "font", "borrow"};
    string[] levelTwoPasswords = {"prisoner", "handcuffs", "holster", "uniform", "arrest"};

    //Game State
    int level;
    enum Screen {
        MainMenu,
        Password,
        Win
    }
    Screen currentScreen;
    string password;





    void Start()
    {
        
        ShowMainMenu();

    }




    void ShowMainMenu(){
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the Police Station");
        Terminal.WriteLine("Enter Your Selection");
    }


    void OnUserInput(string input){
     if (input == "menu") //we cam always go direct to menu
     {
         ShowMainMenu();
     }
     else if (currentScreen == Screen.MainMenu)
    {
        RunMainMenu(input);
    }else if (currentScreen == Screen.Password)
    {
        CheckPassword(input);
    }         
     
    }


     void RunMainMenu(string input){
        
         bool isValidNumber = (input == "1" || input == "2");

        if (input == "1")
        {
            int index = Random.Range(0, levelOnePasswords.Length);
            level = 1;
            password = levelOnePasswords[index];// TODO: make random later
            StartGame();
        }
        else if (input == "2")
        {
            int index = Random.Range(0, levelTwoPasswords.Length);
            level = 2;
            password = levelTwoPasswords[index];
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond!");

        }
        else
        {
            Terminal.WriteLine("Plese select a valid option");
        }
     }


     void StartGame(){
         currentScreen = Screen.Password;
         Terminal.WriteLine("You have chosen level "+ level);
         Terminal.WriteLine(" Enter your password. "+password.Anagram());
     }


    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Sorry, Wrong Password");
        }
    }

    void DisplayWinScreen(){
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward(){
        switch(level)
        {
            case 1:
                Terminal.WriteLine("have a book");
                Terminal.WriteLine(@"
      _ _
 .-. | | |
 |M|_|A|N|
 |A|a|.|.|<\
 |T|r| | | \\
 |H|t|M|Z|  \\      
 | | !| | |   \>
 ''''''''''

                ");
                break;
            case 2:
                Terminal.WriteLine("have a gun");
                Terminal.WriteLine(@"
      __,_____
     / __.==--'
    /#(-'
    `-' ");
                break;
            default:
                Debug.Log("invalid level");
                break;
        }
        
    }
}

