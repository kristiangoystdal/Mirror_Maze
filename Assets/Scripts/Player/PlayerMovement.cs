using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private TileMap tileMap_script = new TileMap();
    public GameObject playerRight;
    public GameObject playerLeft;

    public Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInit();
    }

    void PlayerInit()
    {
        playerRight.transform.position = new Vector3(3.5f, 3.5f, 0);
        playerLeft.transform.position = new Vector3(-3.5f, -3.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController();
    }

    bool keyReleased = true;

    void PlayerController()
    {
        if (keyReleased)
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
        }
    }

    void movePlayer(GameObject player, bool mirrored)
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (!mirrored)
                {
                    Vector3 newPosition = new Vector3(
                        player.transform.position.x + 1,
                        player.transform.position.y,
                        0
                    );
                    if (
                        !tileMap_script.IsTileAt(tilemap, newPosition)
                        || tileMap_script.GetTileName(tilemap, newPosition) == "Win Tile"
                    )
                    {
                        player.transform.position = newPosition;
                        keyReleased = false;
                    }
                }
                else
                {
                    Vector3 newPosition = new Vector3(
                        player.transform.position.x - 1,
                        player.transform.position.y,
                        0
                    );
                    if (
                        !tileMap_script.IsTileAt(tilemap, newPosition)
                        || tileMap_script.GetTileName(tilemap, newPosition) == "Win Tile"
                    )
                    {
                        player.transform.position = newPosition;
                        keyReleased = false;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (!mirrored)
                {
                    Vector3 newPosition = new Vector3(
                        player.transform.position.x - 1,
                        player.transform.position.y,
                        0
                    );
                    if (
                        !tileMap_script.IsTileAt(tilemap, newPosition)
                        || tileMap_script.GetTileName(tilemap, newPosition) == "Win Tile"
                    )
                    {
                        player.transform.position = newPosition;
                        keyReleased = false;
                    }
                }
                else
                {
                    Vector3 newPosition = new Vector3(
                        player.transform.position.x + 1,
                        player.transform.position.y,
                        0
                    );
                    if (
                        !tileMap_script.IsTileAt(tilemap, newPosition)
                        || tileMap_script.GetTileName(tilemap, newPosition) == "Win Tile"
                    )
                    {
                        player.transform.position = newPosition;
                        keyReleased = false;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                if (!mirrored)
                {
                    Vector3 newPosition = new Vector3(
                        player.transform.position.x,
                        player.transform.position.y + 1,
                        0
                    );
                    if (
                        !tileMap_script.IsTileAt(tilemap, newPosition)
                        || tileMap_script.GetTileName(tilemap, newPosition) == "Win Tile"
                    )
                    {
                        player.transform.position = newPosition;
                        keyReleased = false;
                    }
                }
                else
                {
                    Vector3 newPosition = new Vector3(
                        player.transform.position.x,
                        player.transform.position.y - 1,
                        0
                    );
                    if (
                        !tileMap_script.IsTileAt(tilemap, newPosition)
                        || tileMap_script.GetTileName(tilemap, newPosition) == "Win Tile"
                    )
                    {
                        player.transform.position = newPosition;
                        keyReleased = false;
                    }
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if (!mirrored)
                {
                    Vector3 newPosition = new Vector3(
                        player.transform.position.x,
                        player.transform.position.y - 1,
                        0
                    );
                    if (
                        !tileMap_script.IsTileAt(tilemap, newPosition)
                        || tileMap_script.GetTileName(tilemap, newPosition) == "Win Tile"
                    )
                    {
                        player.transform.position = newPosition;
                        keyReleased = false;
                    }
                }
                else
                {
                    Vector3 newPosition = new Vector3(
                        player.transform.position.x,
                        player.transform.position.y + 1,
                        0
                    );
                    if (
                        !tileMap_script.IsTileAt(tilemap, newPosition)
                        || tileMap_script.GetTileName(tilemap, newPosition) == "Win Tile"
                    )
                    {
                        player.transform.position = newPosition;
                        keyReleased = false;
                    }
                }
            }
        }
    }
}
