using UnityEngine;

public class FlashlightDimming : MonoBehaviour
{
    [SerializeField] private Light _flashlight = null;
    private float _flashlightTimer = 0.0f;

    private void Update()
    {
        //_flashlightTimer += Time.deltaTime;
        _flashlight.intensity -= 0.02f;
    }
}
