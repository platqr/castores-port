using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut_Spawner_Script : MonoBehaviour
{
    
    [SerializeField] private float _timerTime = 1;
    private float _timerCount;
    [SerializeField] private GameObject nut;

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
            Instantiate(nut, new Vector3(Random.Range(-8.3f,8.3f), 5.5f, 0), Quaternion.identity, transform);
            _timerTime = Random.Range(0.5f,2.5f);
        }
    }
}
