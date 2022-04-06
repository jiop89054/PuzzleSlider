using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;

    public bool IsThereMovement;

    public bool canPause = true;

    public string sceneName;

    private void Awake()
    {
        instance = this;
    }

    bool paused = false;
    public Canvas pauseCanv;
    public Canvas mainCanv;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && canPause)
        {
            pauseMenu();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadLevel(sceneName);
        }
    }
    public void pauseMenu()
    {
        if (!paused)
        {

            pauseCanv.gameObject.SetActive(true);
            mainCanv.gameObject.SetActive(false);
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;
            pauseCanv.gameObject.SetActive(false);
            mainCanv.gameObject.SetActive(true);
        }

        paused = !paused;
    }
    public void exit()
    {
        Application.Quit();
    }
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);

    }
}
