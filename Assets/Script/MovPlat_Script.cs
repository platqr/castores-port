using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlat_Script : MonoBehaviour
{
    
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private bool _isVertical;
    [SerializeField] private bool _reachLimit = false;
    [SerializeField] private int _direction = 1;

    void FixedUpdate()
    {
        if(_isVertical){
            VerMov();
        }else{
            HorMov();
        }
    }

    private void VerMov(){
        _rb.velocity = new Vector2(_rb.velocity.x, _direction * _speed * Time.fixedDeltaTime);

        if (!_reachLimit && transform.position.y >= 2.15f){
            _reachLimit = true;
            _direction = -1;
        }else if (_reachLimit && transform.position.y <= -2.5){
            _reachLimit = false;
            _direction = 1;
        }
    }

    private void HorMov(){
        _rb.velocity = new Vector2(_direction * _speed * Time.fixedDeltaTime, _rb.velocity.y);

        if (!_reachLimit && transform.position.x >= 5.3){
            _reachLimit = true;
            _direction = -1;
        }else if(_reachLimit && transform.position.x <= -5.6){
            _reachLimit = false;
            _direction = 1;
        }
            
    }
}
