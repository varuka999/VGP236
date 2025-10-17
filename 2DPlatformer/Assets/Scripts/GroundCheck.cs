using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    //private bool _isGrounded = false;
    private int groundContacts = 0;
    //public bool IsGrounded {  get { return _isGrounded; } }
    public bool IsGrounded {  get { return groundContacts > 0; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //_isGrounded = true;
        ++groundContacts;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //_isGrounded = false;
        --groundContacts;
    }
}
