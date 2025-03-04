using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    Animator animator;
    [SerializeField] Collider collider;
    [SerializeField] bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponentInChildren<Collider>();
    }

    public void Interact()
    {
        isOpened = !isOpened;
        collider.isTrigger = isOpened;
        animator.SetBool("Open", isOpened);
    }

    public void Close()
    {
        isOpened = false;
        collider.isTrigger = isOpened;
        animator.SetBool("Open", isOpened);
    }
}
