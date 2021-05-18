using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main_Scripts : MonoBehaviour
{
    
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _NutMg;

    [SerializeField] private Text _timerText;
    [SerializeField] private Text _scoreText;

    [SerializeField] private Sprite _playBtnSprite;
    [SerializeField] private Sprite _pauseBtnSprite;
    [SerializeField] private Image _pausebtnImage;
    [SerializeField] private Sprite _musicPlayBtnSprite;
    [SerializeField] private Sprite _musicPauseBtnSprite;
    [SerializeField] private Image _musicbtnImage;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private AudioSource _gameOverSfx;
    [SerializeField] private AudioSource _pointUpSfx;
    [SerializeField] private AudioSource _music;

    [SerializeField] private float _gameTimer = 32;
    [SerializeField] private int _score;
    private bool _isGameOver = false;
    private bool _isPaused = false;
    private bool _musicPaused = false;

    void Update()
    {
        GameTimer();
        PressPToPause();
    }

    public void Reset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
            _gameOverPanel.active = true;
        }
        _isGameOver = true;
    }

    private void PressPToPause(){
        if(Input.GetKeyDown("p"))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if(_isPaused){
            Time.timeScale = 1;
            _isPaused = false;
            _pausebtnImage.sprite = _pauseBtnSprite;
        } else {
            Time.timeScale = 0;
            _isPaused = true;
            _pausebtnImage.sprite = _playBtnSprite;
        }
    }

    public void PauseMusic()
    {
        if(_musicPaused){
            _music.Play();
            _musicPaused = false;
            _musicbtnImage.sprite = _musicPauseBtnSprite;
        } else {
            _music.Pause();
            _musicPaused = true;
            _musicbtnImage.sprite = _musicPlayBtnSprite;
        }
    }

    public void Exit(){
        Application.Quit();
    }

    public void NextLevel(){
        if (SceneManager.GetActiveScene().buildIndex <3)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
