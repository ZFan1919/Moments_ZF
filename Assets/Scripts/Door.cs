using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{   
    public float openAngle = -105;
    public bool reverse;
    private bool doorOpen = false;
    private bool isAnimating = false;

    public bool Interact()
    {
        if (!isAnimating)
        {
            StartCoroutine(ToggleDoor());
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
}
