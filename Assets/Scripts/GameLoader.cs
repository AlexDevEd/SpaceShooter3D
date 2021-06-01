using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoader : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadFirstLevel", 2f);
    }

    void LoadFirstLevel()
    {
        SceneManager.LoadScene(1);
    }
}
