using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        _audioSource = gameObject.AddComponent<AudioSource>();
        _audioSource.clip = _destroyClip;
        _audioSource.outputAudioMixerGroup = SoundManager.OutputMixer;
    }

    private void Start()
    {
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
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(_audioSource.clip, Camera.main.transform.position);
        WaveController.Enemies.Remove(gameObject);
        WaveController.KillsCount++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position, _target.position);
        Gizmos.DrawLine(transform.position, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(_playerTouchClip, Camera.main.transform.position);
            Destroy(gameObject);
            _UIManager.ShowGameOverPanel();
            GameManager.IsGamePaused = true;
        }
    }
}
