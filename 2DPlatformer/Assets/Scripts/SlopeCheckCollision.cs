using UnityEngine;

public class SlopeCheckCollision : MonoBehaviour
{
    private int slopeContact = 0;
    public bool IsOnSlope { get { return slopeContact > 0; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ++slopeContact;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        --slopeContact;
    }
}
