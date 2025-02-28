using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI; // To interact with UI elements
using TMPro;  // Ensure you have this namespace if you're using TMP.
using UnityEngine.SceneManagement; // To handle scene transitions
using FMODUnity; // To use FMOD Studio for audio


public class GameManager : MonoBehaviour
{
    public StudioEventEmitter DropTick;

    public GameObject Player; // Reference to the player object
    public TMP_Text countText;
    public TMP_Text winText;
    public List<GameObject> pickUps = new List<GameObject>();

    public GameObject winPanel; // Reference to the "You Win!" panel
    public Button nextLevelButton; // Button to move to the next level
    public Button mainMenuButton; // Button to go back to the main menu
    public GameObject pausePanel; // Reference to the pause menu panel
    public Button resumeButton;
    public Button mainMenuButtonPause;
    public Button quitButton;

    public GameObject exitMessagePanel; // New panel for "Now get out!" message
    public TMP_Text exitMessageText;

    public DoorController[] frontDoors;
    public DoorController[] backDoors;

    public bool gameWon = false;
    private bool canExit = false; // Controls when the player can exit

    public StudioEventEmitter CyclesMusic; // Reference to the FMOD sound event

    private bool isPaused = false;

    // List to keep track of required objects
    private List<string> requiredObjects = new List<string> { "Cello", "Viola", "Voilin", "Piano", "Bell" };
    private List<string> collectedObjects = new List<string>(); // To track collected objects by name

    // At the start of the game..
    void Start()
    {
        CyclesMusic.Play(); // Play the FMOD sound event

        // Initialize the countText to show 0 / 5 when the game starts
        countText.text = "Objects Collected: 0 / 5";

        winPanel.SetActive(false); // Hide the "You Win!" panel at the start
        exitMessagePanel.SetActive(false); // Hide exit message initially

        // Add listeners to buttons
        nextLevelButton.onClick.AddListener(NextLevel);
        mainMenuButton.onClick.AddListener(BackToMainMenu);
       
        
        // Hide the pause menu initially
        pausePanel.SetActive(false);

        // Add listeners to buttons
        resumeButton.onClick.AddListener(ResumeGame);
        mainMenuButtonPause.onClick.AddListener(BackToMainMenu);
        quitButton.onClick.AddListener(QuitGame);

        // Keep front doors open at the start
        foreach (var door in frontDoors)
        {
            door.OpenDoor();
        }

        // Keep back doors closed initially
        foreach (var door in backDoors)
        {
            door.CloseDoor();
        }
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


    void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

        // Check if the object is the right tag and not kinematic
        if (other.tag == "CanPickUp" && !rb.isKinematic)
        {
            GameObject pickedObject = other.gameObject;
            string objectName = pickedObject.name;

            // Check if the object is one of the required objects and hasn't been collected yet
            if (requiredObjects.Contains(objectName) && !collectedObjects.Contains(objectName))
            {
                Debug.Log("Object picked up: " + objectName);

                DropTick.Play(); // Play the FMOD sound event

                // Add the object name to the collectedObjects list
                collectedObjects.Add(objectName);

                // Update the count text and win conditions
                SetCountText();

                // Adjust the Mix parameter for the specific object that was collected
                SwitchObjectTo2DSound(pickedObject);

                // Check if all required objects have been collected
                if (collectedObjects.Count == requiredObjects.Count)
                {
                    Debug.Log("Congratulations! You've collected all the objects.");
                    ShowWinPanel(); // Show win panel when all objects are collected
                }
            }
            else
            {
                Debug.Log("Object already collected: " + objectName);
            }
        }

    }

    // Switch the sound of the picked object to 2D
    void SwitchObjectTo2DSound(GameObject pickedObject)
    {
        // Find the appropriate audio manager script on the object and switch its sound
        var celloAudioManager = pickedObject.GetComponent<CelloAudioManager>();  // Change this to match the actual object
        var violaAudioManager = pickedObject.GetComponent<ViolaAudioManager>();
        var voilinAudioManager = pickedObject.GetComponent<VoilinAudioManager>();
        var pianoAudioManager = pickedObject.GetComponent<PianoAudioManager>();
        var bellAudioManager = pickedObject.GetComponent<BellAudioManager>();

        if (celloAudioManager != null)
        {
            celloAudioManager.SwitchTo2DSound();
        }
        else if (violaAudioManager != null)
        {
            violaAudioManager.SwitchTo2DSound();
        }
        else if (voilinAudioManager != null)
        {
            voilinAudioManager.SwitchTo2DSound();
        }
        else if (pianoAudioManager != null)
        {
            pianoAudioManager.SwitchTo2DSound();
        }
        else if (bellAudioManager != null)
        {
            bellAudioManager.SwitchTo2DSound();
        }
        else
        {
            Debug.LogWarning("No audio manager found on " + pickedObject.name);
        }
    }


    void SetCountText()
    {
        // Update the text field of our 'countText' variable
        countText.text = "Objects Collected: " + collectedObjects.Count.ToString() + " / " + requiredObjects.Count.ToString();

        // Optional: Change winText if necessary
        if (collectedObjects.Count == requiredObjects.Count)
        {
            winText.text = "You Win!";
        }
        else
        {
            winText.text = ""; // Clear win text until all objects are collected
        }
    }

    void ShowWinPanel()
    {
        // Show the "You Win!" panel
        winPanel.SetActive(true);
        Time.timeScale = 0f; // Pause the game

        // Optionally, add any extra effects or delay before showing the menu

        // Unlock the mouse and make it visible
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible

        gameWon = true; // Player has won
    }

    // Loads the next scene (replace with actual scene names)
    void NextLevel()
    {
        Time.timeScale = 1f;
        winPanel.SetActive(false); // Close win panel

        exitMessagePanel.SetActive(true); // Show "Now get out!" message
        exitMessageText.text = "Now get out from the office!";
        canExit = true; // Allow player to exit
    }

    void OpenBackDoors()
    {
        if (gameWon) // Only open doors after winning
        {
            foreach (var door in backDoors)
            {
                door.OpenDoor();
            }
        }
        else
        {
            Debug.Log("Back doors remain locked until you win!");
        }
    }

    // Returns to the main menu
    void BackToMainMenu()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene("MainMenu"); // Replace with your main menu scene name
    }

}

