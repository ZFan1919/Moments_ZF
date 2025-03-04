using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickBehaviour : MonoBehaviour
{
    public static PlayerPickBehaviour instance;
    public Pickable currentPickable;
    void Awake()
    {
        instance = this;
    }

    public void Pick(Pickable pickable)
    {
        if (currentPickable)
            currentPickable.transform.SetParent(null);
        else
        {
            currentPickable = pickable;
            currentPickable.transform.SetParent(transform);
        }
    }
}
