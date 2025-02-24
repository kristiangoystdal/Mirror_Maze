using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    private TileMap tileMap = new TileMap();
    public Tilemap tilemap;
    public GameObject playerRight;
    public GameObject playerLeft;

    // Start is called before the first frame update
    void Start()
    {
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

    void LevelComplete()
    {
        if (
            tileMap.GetTileName(tilemap, playerRight.transform.position) == "Win Tile"
            && tileMap.GetTileName(tilemap, playerLeft.transform.position) == "Win Tile"
        )
        {
            Debug.Log("Level Complete!");
        }
    }
}
