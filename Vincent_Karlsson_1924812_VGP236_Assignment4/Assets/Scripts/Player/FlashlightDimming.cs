using UnityEngine;

public class FlashlightDimming : MonoBehaviour
{
    [SerializeField] private Light _flashlight = null;

    private void FixedUpdate()
    {
        _flashlight.intensity -= 0.005f;
    }
}
