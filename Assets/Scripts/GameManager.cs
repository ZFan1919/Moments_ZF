using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI; // To interact with UI elements
using TMPro;  // Ensure you have this namespace if you're using TMP.
using UnityEngine.SceneManagement; // To handle scene transitions


public class GameManager : MonoBehaviour
{
    public TMP_Text countText;
    public TMP_Text winText;

    public GameObject winPanel; // Reference to the "You Win!" panel
    //public Button nextLevelButton; // Button to move to the next level
    public Button mainMenuButton; // Button to go back to the main menu
    public GameObject pausePanel; // Reference to the pause menu panel
    public Button resumeButton;
    public Button mainMenuButtonPause;
    public Button quitButton;

    private bool isPaused = false;


    // At the start of the game..
    void Start()
    {
        winPanel.SetActive(false); // Hide the "You Win!" panel at the start

        // Add listeners to buttons
        //nextLevelButton.onClick.AddListener(NextLevel);
        mainMenuButton.onClick.AddListener(BackToMainMenu);
       
        
        // Hide the pause menu initially
        pausePanel.SetActive(false);

        // Add listeners to buttons
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButtonPause.onClick.AddListener(BackToMainMenu);
        quitButton.onClick.AddListener(QuitGame);
    }


    private void Update()
    {
        // Check for the pause key (e.g., Escape)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game
        pausePanel.SetActive(true); // Show the pause menu

        // Unlock the mouse and make it visible
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game
        pausePanel.SetActive(false); // Hide the pause menu

        // Lock the cursor and hide it when resuming the game
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center
        Cursor.visible = false; // Hide the cursor
    }

    void QuitGame()
    {
        Time.timeScale = 1f; // Resume the game before quitting
        Application.Quit(); // Exit the application (useful for builds)
    }


        
    //void SetCountText()
    //{
        // Update the text field of our 'countText' variable
        //countText.text = "Objects Collected: " + collectedObjects.Count.ToString() + " / " + requiredObjects.Count.ToString();

        // Optional: Change winText if necessary
        //if (collectedObjects.Count == requiredObjects.Count)
        //{
            //winText.text = "You Win!";
        //}
        //else
        //{
            //winText.text = ""; // Clear win text until all objects are collected
        //}
    //}

    // void ShowWinPanel()
    //{
        // Show the "You Win!" panel
        //winPanel.SetActive(true);
        //Time.timeScale = 0f; // Pause the game

        // Optionally, add any extra effects or delay before showing the menu

        // Unlock the mouse and make it visible
        //Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        //Cursor.visible = true; // Make the cursor visible

        //gameWon = true; // Player has won
    //}

    // Loads the next scene (replace with actual scene names)
    //void NextLevel()
    //{
        //Time.timeScale = 1f;
        //winPanel.SetActive(false); // Close win panel

        //exitMessagePanel.SetActive(true); // Show "Now get out!" message
        //exitMessageText.text = "Now get out from the office!";
        //canExit = true; // Allow player to exit
    //}


    // Returns to the main menu
    void BackToMainMenu()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene("MainMenu"); // Replace with your main menu scene name
    }

}

