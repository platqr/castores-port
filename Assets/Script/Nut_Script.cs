using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut_Script : MonoBehaviour
{

    private Main_Scripts _mainScript;
    
    private float _timerTime = 10;

    void Start()
    {
        _mainScript = GameObject.FindGameObjectWithTag("Main").GetComponent<Main_Scripts>();
    }

    void Update()
    {
        if (transform.position.y <= -5.5f){
            _mainScript.ScoreUp();
            Destroy(gameObject);
        }
        DestroyTimer();
    }

    void DestroyTimer(){
        if (_timerTime >= 0)
        {
            _timerTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
