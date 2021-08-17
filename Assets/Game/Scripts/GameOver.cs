using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(RestartScene);
    }

    void RestartScene()
    {
        SceneManager.LoadScene("FirstDungeon"); // loads current scene
    }
}
