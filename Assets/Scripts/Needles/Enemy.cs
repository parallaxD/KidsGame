using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Enemy : MonoBehaviour
{
    private Transform _target;

    [SerializeField] private float _speed = 5.0f;
    private NeedlesUIController _UIManager;

    private Rigidbody2D _rb;
    private Vector3 _moveDirection;
    private Vector3 _lookDirection;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _destroyClip;
    [SerializeField] private AudioClip _playerTouchClip;

    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private TextMeshProUGUI _scoreText;

    [SerializeField] private WaveController _waveController;

    private void Awake()
    {
        _waveController = GameObject.Find("WaveController").GetComponent<WaveController>();
        if (!_waveController.IsEndlessGame)
        {
            _progressBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();
            _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        }
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = _destroyClip;
        _audioSource.outputAudioMixerGroup = SoundManager.OutputMixer;
    }

    private void Start()
    {
        if (!_waveController.IsEndlessGame)
        {
            if (WaveController.KillsCount == 0)
            {
                _scoreText.text = $"0/10";
            }
        }
        _UIManager = GameObject.Find("UIManager").GetComponent<NeedlesUIController>();
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Vector3 direction = _target.position - transform.position;
        direction.Normalize();
        _moveDirection = direction;

        _lookDirection = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);

        print(_lookDirection);
    }
    private void MoveToTarget()
    {
        _rb.MovePosition((Vector3)transform.position + (_moveDirection * _speed * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        if (!GameManager.IsGamePaused) MoveToTarget();
        if (GameManager.IsGamePaused)
        {
            _rb.bodyType = RigidbodyType2D.Static;
        }
        if (!GameManager.IsGamePaused && _rb.bodyType != RigidbodyType2D.Dynamic)
        {
            _rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnMouseDown()
    {
        if (GameManager.IsGamePaused)
        {
            return;
        }
        if (!_waveController.IsEndlessGame) DestroyWithIncreaseScore();
        else DestroyWithoutIncreaseScore();
    }

    private void DestroyWithoutIncreaseScore()
    {
        AudioSource.PlayClipAtPoint(_audioSource.clip, Camera.main.transform.position);
        WaveController.KillsCount++;
        WaveController.Enemies.Remove(gameObject);
        Destroy(gameObject);
    }

    private void DestroyWithIncreaseScore()
    {
        AudioSource.PlayClipAtPoint(_audioSource.clip, Camera.main.transform.position);
        WaveController.Enemies.Remove(gameObject);

        Destroy(gameObject);
        WaveController.KillsCount++;

        _progressBar.CurrentValue++;
        _scoreText.text = $"{WaveController.KillsCount}/10";
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (WaveController.KillsCount >= 10)
        {
            if (PlayerPrefs.GetInt("Победить в мини-игре 1 раз") == 0)
            {
                PlayerPrefs.SetInt("Победить в мини-игре 1 раз", 1);
            }
        }
        if (collision.tag == "Player")
        {
            DestroyWithoutIncreaseScore();
            AudioSource.PlayClipAtPoint(_playerTouchClip, Camera.main.transform.position);
            if (!_waveController.IsEndlessGame)
            {
                _progressBar.CurrentValue = 0;
                _scoreText.text = "0/10";
            }
            GameManager.IsGamePaused = true;
            _UIManager.ShowGameOverPanel();
        }
    }
}
