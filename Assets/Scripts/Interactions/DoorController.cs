using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoorController : MonoBehaviour
{
    public bool isBackDoor; // Set in Inspector (true for back doors, false for front doors)
    private bool isOpen = false;
    private bool isLocked = false; // New lock variable

    public void LockDoor()
    {
        isLocked = true; // Lock the door
    }

    public void OpenDoor()
    {
        if (isLocked)
        {
            Debug.Log("Door is locked and cannot be opened!");
            return;
        }

        if (!isOpen)
        {
            StartCoroutine(OpenDoorRoutine());
            isOpen = true;
        }
    }

    public void CloseDoor()
    {
        Debug.Log("CloseDoor() was called on " + gameObject.name);
        if (isOpen)
        {
            StartCoroutine(CloseDoorRoutine());
            isOpen = false;
            LockDoor(); // Lock after closing
        }
    }

    IEnumerator OpenDoorRoutine()
    {
        float targetAngle = isBackDoor ? -105f : 105f; // Adjust for door direction
        float alpha = 0;
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0, targetAngle, 0);

        while (alpha < 1)
        {
            transform.localRotation = Quaternion.Lerp(startRotation, endRotation, alpha);
            alpha += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator CloseDoorRoutine()
    {
        float duration = 1.0f; // Time to close the door in seconds
        float elapsedTime = 0;

        // Get the initial Y rotation of the door
        float initialYRotation = transform.localRotation.eulerAngles.y;

        // Determine the correct closed rotation based on initial rotation
        Quaternion startRotation = transform.localRotation;
        Quaternion endRotation = Quaternion.Euler(0, Mathf.Round(initialYRotation / 180) * 180, 0);

        while (elapsedTime < duration)
        {
            transform.localRotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localRotation = endRotation; // Ensure it reaches exact closed position
    }
}
