using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
    [SerializeField] private GameObject _roadFab;
    private CarMoveForward _car;

    private Vector3 _lastNodePos = Vector3.zero;
    private float _lastSpawnTime;
    private GameObject lastNode = null;

    // Start is called before the first frame update
    void Start()
    {
        _car = GameObject.FindObjectOfType<CarMoveForward>();    
        if (_car == null)
        {
            Debug.LogWarning("No CarMoveForward behaviour found in Scene!! :(");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(_car.transform.position, _lastNodePos) <= 50f && Time.time - _lastSpawnTime >= 0.2f)
        {
            //Destroy(lastNode);
            GameObject newNode = GameObject.Instantiate(_roadFab);
            lastNode = newNode;

            newNode.transform.position = _lastNodePos + (Vector3.forward * 100);
            newNode.transform.SetParent(transform);
            _lastNodePos = newNode.transform.position;
            _lastSpawnTime = Time.time;
        }
    }
}
