using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private Transform _ballSpawnerParent;
    [SerializeField] private Transform _ballSpawnerPoint;
    private int _ammo = 100;

    private void Update()
    {
        if (_ball != null && Input.GetKeyDown(KeyCode.Space) && _ammo > 0)
        {
            GameObject ball = Instantiate(_ball, _ballSpawnerParent);
            ball.transform.position = _ballSpawnerPoint.position;

            UpdateAmmo(-1);
        }
    }

    public void UpdateAmmo(int amount)
    {
        _ammo += amount;

        UIManager.Instance.UpdateAmmoText(_ammo);
    }
}
