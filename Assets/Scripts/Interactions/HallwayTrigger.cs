using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayTrigger : MonoBehaviour
{
    public GameManager gameManager; // Reference to GameManager

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>(); // Auto-assign if not set in Inspector
        }

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found! Make sure it's assigned in the Inspector.");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered the trigger: " + other.name);

        if (gameManager == null)
        {
            Debug.LogError("GameManager reference is missing in HallwayTrigger!");
            return;
        }

        if (gameManager.gameWon && other.CompareTag("Player"))
        {
            Debug.Log("Player exited through the back doors.");
            CloseBackDoors(); // Close doors directly from HallwayTrigger
            gameManager.exitMessagePanel.SetActive(false);
        }
    }

    private void CloseBackDoors()
    {
        Debug.Log("Closing all back doors...");

        DoorController[] doors = FindObjectsOfType<DoorController>();

        foreach (DoorController door in doors)
        {
            if (door.isBackDoor) // Only close back doors
            {
                Debug.Log("Closing door: " + door.gameObject.name);
                door.CloseDoor();
            }
        }
    }

}
