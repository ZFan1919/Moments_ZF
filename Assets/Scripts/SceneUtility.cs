using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneUtility : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Teleport(Transform point)
    {
        var player = FindObjectOfType<FirstPersonController>().transform;
        player.position = point.position;
        player.rotation = point.rotation;
    }
}
