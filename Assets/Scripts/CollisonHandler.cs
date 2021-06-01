using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisonHandler : MonoBehaviour
{
    [SerializeField] private float LoadLevelSpeed = 1f;
    [SerializeField] private GameObject explosion;
    [SerializeField] private GameObject PlayerShip;

    void OnTriggerEnter(Collider other)
    {
        StartDeath();
        explosion.SetActive(true);
        Invoke("HideShip", 0.3f);
        Invoke("RestartLevel", LoadLevelSpeed);
    }

    void HideShip()
    {
        PlayerShip.SetActive(false);
    }
    void StartDeath()
    {
        SendMessage("OnStartDeath");
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

}
