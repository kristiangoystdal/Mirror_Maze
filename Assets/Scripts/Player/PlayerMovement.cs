using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private GameObject controller;
    private LevelLoader levelLoader_script;
    private TileMapController tileMap_script;
    public GameObject playerRight;
    public GameObject playerLeft;
    public TMP_Text movesText;

    public Tilemap tilemap;

    public int currentMove = 0;
    public int maxMoves;

    void Start()
    {
        controller = GameObject.Find("Controller"); // Find the GameObject with the name "Controller"
        levelLoader_script = controller.GetComponent<LevelLoader>(); // Get the LevelLoader script from the controller GameObject
        tileMap_script = controller.GetComponent<TileMapController>(); // Get the TileMapController script from the controller GameObject
    }

    void Update()
    {
        PlayerController();

        if (levelLoader_script.currentLevel.maxMoves != maxMoves)
        {
            maxMoves = levelLoader_script.currentLevel.maxMoves;
            Debug.Log("Max moves: " + maxMoves);
            movesText.text = "Moves left: " + (maxMoves);
        }
    }

    bool keyReleased = true;

    void PlayerController()
    {
        if (keyReleased && currentMove < maxMoves)
        {
            movePlayer(playerRight, false);
            movePlayer(playerLeft, true);
        }

        if (
            Input.GetKeyUp(KeyCode.RightArrow)
            || Input.GetKeyUp(KeyCode.LeftArrow)
            || Input.GetKeyUp(KeyCode.UpArrow)
            || Input.GetKeyUp(KeyCode.DownArrow)
        )
        {
            keyReleased = true;
            currentMove++;
        }
    }

    void movePlayer(GameObject player, bool mirrored)
    {
        if (tileMap_script == null)
        {
            Debug.LogError("TileMap script reference is missing!");
            return;
        }

        if (Input.anyKey)
        {
            Vector3 newPosition = player.transform.position;

            if (Input.GetKey(KeyCode.RightArrow))
                newPosition.x += mirrored ? -1 : 1;
            else if (Input.GetKey(KeyCode.LeftArrow))
                newPosition.x += mirrored ? 1 : -1;
            else if (Input.GetKey(KeyCode.UpArrow))
                newPosition.y += mirrored ? -1 : 1;
            else if (Input.GetKey(KeyCode.DownArrow))
                newPosition.y += mirrored ? 1 : -1;

            if (
                !tileMap_script.IsTileAt(tilemap, newPosition)
                || tileMap_script.GetTileName(tilemap, newPosition) == "Win Tile"
            )
            {
                player.transform.position = newPosition;
                keyReleased = false;
                movesText.text = "Moves left: " + (maxMoves - currentMove - 1);
            }
        }
    }
}
