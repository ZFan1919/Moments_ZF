using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public void Pick()
    {
        PlayerPickBehaviour.instance.Pick(this);
    }
}
