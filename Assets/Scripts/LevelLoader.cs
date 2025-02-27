using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    private GameObject controller;
    private TileMapController tileMap_script;

    public TileBase winTile;
    public GameObject playerLeft;
    public GameObject playerRight;

    public Tilemap tilemap;

    public LevelInfo currentLevel;

    public TMP_Text levelTitle;

    public struct LevelInfo
    {
        public string name;
        public Vector3 goalPositionLeft; // X (-21 to 1) Y (-10 to 10)
        public Vector3 goalPositionRight; // X (1 to 21) Y (-10 to 10)
        public Vector3 startPositionLeft; // X (-21 to 1) Y (-10 to 10)
        public Vector3 startPositionRight; // X (1 to 21) Y (-10 to 10)

        public Vector3[] obstaclePositions; // X (-21 to 21) Y (-10 to 10)
        public Vector3[] dangerPositions; // X (-21 to 21) Y (-10 to 10)

        public int maxMoves;

        public LevelInfo(
            string name,
            Vector3 goalPositionLeft,
            Vector3 goalPositionRight,
            Vector3 startPositionLeft,
            Vector3 startPositionRight,
            Vector3[] obstaclePositions,
            Vector3[] dangerPositions,
            int maxMoves = 0
        )
        {
            this.name = name;
            this.goalPositionLeft = goalPositionLeft;
            this.goalPositionRight = goalPositionRight;
            this.startPositionLeft = startPositionLeft;
            this.startPositionRight = startPositionRight;
            this.obstaclePositions = obstaclePositions;
            this.dangerPositions = dangerPositions;
            this.maxMoves = maxMoves;
        }
    }

    public static LevelInfo[] tutorialLevels = new LevelInfo[]
    {
        // Tutorial
        new LevelInfo(
            "Tutorial 1",
            new Vector3(-14, -6, 0), // Goal position left
            new Vector3(14, 6, 0), // Goal position right
            new Vector3(-2, -3, 0), // Start position left
            new Vector3(2, 3, 0), // Start position right
            new Vector3[] { new Vector3(0, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0) },
            50
        ),
        new LevelInfo(
            "Tutorial 2",
            new Vector3(-14, -6, 0), // Goal position left
            new Vector3(14, 6, 0), // Goal position right
            new Vector3(-2, -3, 0), // Start position left
            new Vector3(2, 3, 0), // Start position right
            new Vector3[] { new Vector3(0, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0) },
            10
        ),
        new LevelInfo(
            "Tutorial 3",
            new Vector3(-14, -6, 0), // Goal position left
            new Vector3(14, 6, 0), // Goal position right
            new Vector3(-2, -3, 0), // Start position left
            new Vector3(2, 3, 0), // Start position right
            new Vector3[] { new Vector3(0, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0) },
            10
        ),
    };

    public static LevelInfo[] levels = new LevelInfo[]
    {
        // Level 1
        new LevelInfo(
            "Level 1",
            new Vector3(-1, -10, 0), // Goal position left
            new Vector3(1, 10, 0), // Goal position right
            new Vector3(-1, -3, 0), // Start position left
            new Vector3(1, 3, 0), // Start position right
            new Vector3[] { new Vector3(0, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0) },
            10
        ),
        // Level 2
        new LevelInfo(
            "Level 2",
            new Vector3(-1, -10, 0), // Goal position left
            new Vector3(1, 10, 0), // Goal position right
            new Vector3(-3, -3, 0), // Start position left
            new Vector3(3, 3, 0), // Start position right
            new Vector3[] { new Vector3(0, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0) },
            10
        ),
    };

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("Controller");
        tileMap_script = controller.GetComponent<TileMapController>();

        if (PlayerPrefs.GetInt("Tutorial") == 1)
        {
            currentLevel = tutorialLevels[PlayerPrefs.GetInt("CurrentLevel")];
        }
        else
        {
            currentLevel = levels[PlayerPrefs.GetInt("CurrentLevel")];
        }
        Debug.Log("Current level: " + currentLevel.name);
        LoadLevel(currentLevel);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // ResetLevel();
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerPrefs.SetInt("Tutorial", 1);
            PlayerPrefs.SetInt("CurrentLevel", 0);
            PlayerPrefs.Save();
        }
    }

    public void LoadLevel(LevelInfo level)
    {
        levelTitle.text = level.name;

        playerLeft.transform.position = new Vector3(
            level.startPositionLeft.x + 0.5f,
            level.startPositionLeft.y + 0.5f,
            level.startPositionLeft.z
        );
        playerRight.transform.position = new Vector3(
            level.startPositionRight.x + 0.5f,
            level.startPositionRight.y + 0.5f,
            level.startPositionRight.z
        );

        tileMap_script.PlaceTile(tilemap, level.goalPositionLeft, winTile);
        tileMap_script.PlaceTile(tilemap, level.goalPositionRight, winTile);

        // print("Loaded level: " + level.name);
        // print("Goal position left: " + level.goalPositionLeft);
        // print("Goal position right: " + level.goalPositionRight);
        // print("Start position left: " + level.startPositionLeft);
        // print("Start position right: " + level.startPositionRight);
        // print("Max moves: " + level.maxMoves);
    }
}
