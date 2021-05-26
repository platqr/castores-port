using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nut_3_Script : MonoBehaviour
{

    private Main_Scripts _mainScript;

    [SerializeField] private SpriteRenderer _crackedNutSR;
    [SerializeField] private Sprite _crackedNutSprite;

    private bool _isBroken = false;

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
        if (collision.gameObject.tag == "Player" && !_isBroken){
            _isBroken = true;
            _crackedNutSR.sprite = _crackedNutSprite;
            _mainScript.CrackSfx();
        }else if (collision.gameObject.tag == "Player" && _isBroken){
            _mainScript.ScoreUp();
            Destroy(gameObject);
        }else if (collision.gameObject.tag != "Nut" && !_isBroken){
            Destroy(gameObject);
        }
    }
}
