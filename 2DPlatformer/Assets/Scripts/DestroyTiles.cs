using UnityEngine;
using UnityEngine.Tilemaps;

public class DestroyTiles : MonoBehaviour
{
    private Tilemap _tilemap;

    private void Awake()
    {
        _tilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player2")
        {
            foreach (var contact in collision.contacts)
            {
                Vector3 adjustment = contact.point - contact.normal * -0.1f;
                Vector3Int tileCellPosisiton = _tilemap.WorldToCell(adjustment);

                _tilemap.SetTile(tileCellPosisiton, null);
            }
        }
    }
}
