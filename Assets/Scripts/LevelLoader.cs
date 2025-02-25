using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class LevelLoader : MonoBehaviour
{
    private GameObject controller = GameObject.Find("Controller");
    private PlayerMovement playerMovement_script;

    private TileMap tileMap_script = new TileMap();

    public TileBase winTile;
    public GameObject playerLeft;
    public GameObject playerRight;

    public Tilemap tileMap;

    public LevelInfo currentLevel;

    public struct LevelInfo
    {
        public string name;
        public Vector3 goalPositionLeft; // X (-21 to 0)
        public Vector3 goalPositionRight;
        public Vector3 startPositionLeft;
        public Vector3 startPositionRight;

        public Vector3[] obstaclePositions;
        public Vector3[] dangerPositions;

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

    public static LevelInfo[] levels = new LevelInfo[]
    {
        // Tutorial
        new LevelInfo(
            "Tutorial",
            new Vector3(-1, -10, 0), // Goal position left
            new Vector3(1, 10, 0), // Goal position right
            new Vector3(-1, -3, 0), // Start position left
            new Vector3(1, 3, 0), // Start position right
            new Vector3[] { new Vector3(0, 0, 0) },
            new Vector3[] { new Vector3(0, 0, 0) },
            10
        ),
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
        playerMovement_script = controller.GetComponent<PlayerMovement>();

        currentLevel = levels[0];
        LoadLevel(currentLevel);
    }

    void Update() { }

    public void LoadLevel(LevelInfo level)
    {
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

        tileMap_script.PlaceTile(tileMap, level.goalPositionLeft, winTile);
        tileMap_script.PlaceTile(tileMap, level.goalPositionRight, winTile);

        print("Loaded level: " + level.name);
        print("Goal position left: " + level.goalPositionLeft);
        print("Goal position right: " + level.goalPositionRight);
        print("Start position left: " + level.startPositionLeft);
        print("Start position right: " + level.startPositionRight);
        print("Max moves: " + level.maxMoves);
    }
}
