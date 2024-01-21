using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed;

    private int _currentWaypoint = 0;

    private void Awake()
    {
        ShuffleWaypoints();
    }

    private void Update()
    {
        MoveWaypoints();
    }

    private void ShuffleWaypoints()
    {
        System.Random random = new System.Random();
        int number = _waypoints.Length;

        while (number > 1)
        {
            int k = random.Next(number--);
            Transform tempTransform = _waypoints[k];
            _waypoints[k] = _waypoints[number];
            _waypoints[number] = tempTransform;
        }
    }

    private void MoveWaypoints()
    {
        if (transform.position == _waypoints[_currentWaypoint].position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoints.Length;
        }

        
        transform.LookAt(_waypoints[_currentWaypoint].position);

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }

}
