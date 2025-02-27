using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private GameObject controller;
    private TileMapController tileMap_script;
    public Tilemap tilemap;
    public GameObject playerRight;
    public GameObject playerLeft;

    public TMP_Text levelTitle;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Controller");
        tileMap_script = controller.GetComponent<TileMapController>();

        PlayerInit();
    }

    void PlayerInit()
    {
        playerRight = GameObject.Find("Player Right");
        playerLeft = GameObject.Find("Player Left");
    }

    // Update is called once per frame
    void Update()
    {
        LevelComplete();
    }

    public void ResetLevel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    void LevelComplete()
    {
        if (
            tileMap_script.GetTileName(tilemap, playerRight.transform.position) == "Win Tile"
            && tileMap_script.GetTileName(tilemap, playerLeft.transform.position) == "Win Tile"
        )
        {
            Debug.Log("Level Complete!");
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);

            // Set current level to 0 if tutorial is done
            // if (PlayerPrefs.GetInt("Tutorial") == 1 && PlayerPrefs.GetInt("CurrentLevel") >= 3)
            // {
            //     PlayerPrefs.SetInt("CurrentLevel", 0);
            //     PlayerPrefs.SetInt("Tutorial", 0);
            // }

            PlayerPrefs.Save();
        }
    }
}
