using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [Tooltip("In seconds")][SerializeField] float levelLoadDelay = 1f;
    [Tooltip("FX prefab on player")]public GameObject deathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");

        deathFX.SetActive(true);
        Invoke("LoadFirstLevel", levelLoadDelay);
    }

    private void LoadFirstLevel() // string referenced
    {
        SceneManager.LoadScene(1);
    }
}
