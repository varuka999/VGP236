using UnityEngine;

public class FlashlightDimming : MonoBehaviour
{
    [SerializeField] private Light _flashlight = null;

    private void Update()
    {
        _flashlight.intensity -= 0.001f;
    }
}
