using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class WaipointFollower : MovingObject
{
    [SerializeField] private GameObject[] _waipoints;
    private int _currentWainpointIndex = 0;

    [SerializeField] private float speed = 2f;
    
    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if (Vector2.Distance(_waipoints[_currentWainpointIndex].transform.position, transform.position) < 0.1f)
            {
                _currentWainpointIndex++;
                if (_currentWainpointIndex >= _waipoints.Length)
                {
                    _currentWainpointIndex = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, _waipoints[_currentWainpointIndex].transform.position, Time.deltaTime*speed);
        }
    }
}
