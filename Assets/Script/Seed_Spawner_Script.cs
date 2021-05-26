using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed_Spawner_Script : MonoBehaviour
{
    
    [SerializeField] private float _timerTime = 1;
    private float _timerCount;
    [SerializeField] private GameObject _seed;

    void Update(){
        SpawnTimer();
    }

    void SpawnTimer(){
        if (_timerTime >= 0)
        {
            _timerTime -= Time.deltaTime;
        }
        else
        {
            Instantiate(_seed, new Vector3(Random.Range(-8.3f,8.3f), 5.5f, 0), Quaternion.identity, transform);
            _timerTime = Random.Range(2.5f,5.0f);
        }
    }
}
