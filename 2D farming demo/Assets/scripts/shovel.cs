using UnityEngine;
using UnityEngine.Tilemaps;

public class shovel : MonoBehaviour
{
    [SerializeField] Transform plants;
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile dirtTile;
    [SerializeField] Transform highlight;
    Vector3 inputOffset;
    Vector3Int highlightedTilePos;

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(input!= Vector2.zero)
        {
            inputOffset = input;
        }
        Vector3Int tileStandingOn = tilemap.WorldToCell(transform.position);

        highlightedTilePos = new Vector3Int(tileStandingOn.x + (int)inputOffset.x, tileStandingOn.y + (int)inputOffset.y, 0);

        highlight.position = tilemap.GetCellCenterWorld(highlightedTilePos);
        if (Input.GetMouseButtonDown(0))
        {
            tilemap.SetTile(highlightedTilePos, dirtTile);
        }

        if (Input.GetMouseButtonDown(1))
        {
            plant();
        }
    }
    void plant()
    {
        bool isDirtTile = tilemap.GetTile<Tile>(highlightedTilePos) == dirtTile;
        bool isEmpty = !Physics2D.OverlapCircle(highlight.position, 0.1f);
        if (isDirtTile && isEmpty)
        {
            Instantiate(plants, highlight.position, Quaternion.identity);
        }
    }
}
