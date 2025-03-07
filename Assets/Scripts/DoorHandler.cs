using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    Animator animator;
    [SerializeField] bool isOpened = false;
    public bool isInteractable
    {
        get => _isInteractable;
        set => _isInteractable = value;
    }
    [SerializeField] bool _isInteractable = true;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Switch(isOpened);
    }

    public void Interact()
    {
        if (!isInteractable) return;
        Switch(!isOpened);
    }

    public void Lock()
    {
        Switch(false);
        isInteractable = false;
    }

    void Switch(bool opened)
    {
        isOpened = opened;
        animator.SetBool("Open", isOpened);
    }
}
