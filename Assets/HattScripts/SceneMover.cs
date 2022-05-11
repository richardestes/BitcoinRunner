using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMover : MonoBehaviour
{
    public string sceneName;

    public void SceneMove()
    {
        SceneManager.LoadScene(sceneName);

    }
}
