using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed_Script : MonoBehaviour
{

    private Main_Scripts _mainScript;

    void Start()
    {
        _mainScript = GameObject.FindGameObjectWithTag("Main").GetComponent<Main_Scripts>();
    }

    void Update()
    {
        if (transform.position.y <= -5.5f){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            _mainScript.TakeLife();
            Destroy(gameObject);
        }else if (collision.gameObject.tag != "Nut" || collision.gameObject.tag != "Player"){
            Destroy(gameObject);
        }
    }
}
