using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Scripts : MonoBehaviour
{
    
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _NutMg;

    [SerializeField] private Text _timerText;
    [SerializeField] private Text _scoreText;

    [SerializeField] private AudioSource _gameOverSfx;
    [SerializeField] private AudioSource _pointUpSfx;
    [SerializeField] private AudioSource _music;

    [SerializeField] private float _gameTimer = 32;
    [SerializeField] private int _score;
    private bool _isGameOver = false;

    void Update()
    {
        Reset();
        GameTimer();
    }

    private void Reset(){
        if(Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void GameTimer(){
        if (_gameTimer >= 0)
        {
            _gameTimer -= Time.deltaTime;
            _timerText.text = "Time: " + (int)_gameTimer;
        }
        else
        {
            _timerText.text = "Time: 0";
            GameOver();
        }
    }

    public void ScoreUp(){
        _score += 10;
        _pointUpSfx.Play();
        _scoreText.text = "Score: " + _score;
    }

    public void GameOver(){
        if (!_isGameOver){
            _gameOverSfx.Play();
            _music.Stop();
            _player.active = false;
            _NutMg.active = false;
            _gameTimer=0;
        }
        _isGameOver = true;
    }
}
