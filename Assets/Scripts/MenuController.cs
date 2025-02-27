using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Animator menuAnimator;
    public GameObject levelSelectButton1;
    public GameObject levelSelectButton2;

    // Start is called before the first frame update
    void Start()
    {
        FirstGameStart();

        if (PlayerPrefs.GetInt("Tutorial") == 1)
        {
            levelSelectButton1.GetComponent<Button>().interactable = false;
            levelSelectButton2.GetComponent<Button>().interactable = false;
        }
    }

    void FirstGameStart()
    {
        if (PlayerPrefs.HasKey("FirstGame"))
        {
            Debug.Log("First Game key exists!");
        }
        else
        {
            Debug.Log("First Game key does not exist!");
            PlayerPrefs.SetInt("FirstGame", 1);

            PlayerPrefs.SetInt("Tutorial", 1);
            PlayerPrefs.SetInt("CurrentLevel", 0);

            PlayerPrefs.Save();
        }
    }

    // Update is called once per frame
    void Update() { }

    public void StartGame()
    {
        Debug.Log("Start Game!");
        Debug.Log("Start loader animation");
        SceneManager.LoadScene("LevelScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }

    public void LoadLevelSelect()
    {
        Debug.Log("Load Level Select!");
        menuAnimator.SetBool("Level Select", true);
    }

    public void LoadSettings()
    {
        Debug.Log("Load Settings!");
    }

    public void LoadMainMenu()
    {
        Debug.Log("Load Main Menu!");
        menuAnimator.SetBool("Level Select", false);
    }
}
