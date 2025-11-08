using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private int _groundContacts = 0;
    public bool IsGrounded { get { return _groundContacts > 0; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground")
        {
            ++_groundContacts;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ground")
        {
            --_groundContacts;
        }
    }
}
