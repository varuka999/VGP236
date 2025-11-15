using UnityEngine;
using System.Collections.Generic;


public class WaypointManager : MonoBehaviour
{
    static private WaypointManager _instance;

    [SerializeField] private List<Waypoint> _waypoints = new List<Waypoint>();

    static public WaypointManager Instance { get => _instance; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = new WaypointManager();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public Waypoint GetWaypoint(int index)
    {
        if (index < _waypoints.Count && index >= 0)
        {
            return _waypoints[index];
        }

        return null;
    }

    public Waypoint GetRandomWaypoint()
    {
        if (_waypoints.Count == 0)
        {
            return null;
        }

        int randomInex = Random.Range(0, _waypoints.Count);
        return _waypoints[randomInex];
    }

    public Waypoint GetClosestWaypoint(Vector3 position)
    {
        if(_waypoints.Count == 0)
        {
            return null;
        }

        Waypoint closestWaypoint = null;
        float closestDistanceSq = float.MaxValue;
        foreach(Waypoint waypoint in _waypoints)
        {
            float disSq = Vector3.SqrMagnitude(waypoint.transform.position - position);

            if(disSq > closestDistanceSq)
            {
                closestDistanceSq = disSq;
                closestWaypoint = waypoint;
            }
        }

        return closestWaypoint;
    }
}
