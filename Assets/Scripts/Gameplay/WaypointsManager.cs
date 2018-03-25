using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsManager : MonoBehaviour {

    public static WaypointsManager _instance = null;
    public List<GameObject> waypoints;

    public void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static WaypointsManager GetWaypointsManager()
    {
        return _instance;
    }
}
