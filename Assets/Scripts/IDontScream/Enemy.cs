using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float _speed = 5.0f;

    private Rigidbody2D _rb;
    private Vector2 _moveDirection;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void MoveToTarget()
    {
        _rb.MovePosition((Vector2)transform.position + (_moveDirection * _speed * Time.deltaTime));
    }

    private void FixedUpdate()
    {
        MoveToTarget();
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        _moveDirection = direction;
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        WaveController.Enemies.Remove(gameObject);
        WaveController.KillsCount++;
    }
}
