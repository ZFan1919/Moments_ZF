using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{   
    public float openAngle = -105;
    public bool reverse;
    private bool doorOpen = false;
    private bool isAnimating = false;

    private GameManager gameManager; // Reference to GameManager

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); // Get reference to GameManager
    }

    public bool Interact()
    {
        // Prevent back doors from opening until game is won
        if (!gameManager.gameWon && IsBackDoor())
        {
            Debug.Log("Back doors remain locked until you win!");
            return false;
        }

        if (!isAnimating)
        {
            GetComponent<DoorController>()?.OpenDoor();
            return true;
        }
        return false;
    }

    private IEnumerator ToggleDoor()
    {
        isAnimating = true;
        float alpha = 0;
        float targetY = transform.localEulerAngles.y + (doorOpen ? -openAngle : openAngle);

        while (alpha < 1)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, targetY, 0), alpha);
            alpha += Time.deltaTime * 2;
            yield return null;
        }

        doorOpen = !doorOpen;
        isAnimating = false;
    }

    private bool IsBackDoor()
    {
        return gameObject.CompareTag("BackDoor"); // Ensure back doors have tag "BackDoor"
    }

    public void CloseDoor()
    {
        if (doorOpen && !isAnimating) // Only close if it's open
        {
            StartCoroutine(ToggleDoor());
        }
    }
}
