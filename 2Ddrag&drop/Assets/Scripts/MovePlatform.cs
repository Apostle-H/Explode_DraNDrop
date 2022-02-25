using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float MoveSpeed;
    [SerializeField] private float SmoothMovementKoef;

    private float _InputX;
    private float _InputY;
    private Vector2 _CurrentVelocity;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {
        _InputX = Input.GetAxis("Horizontal");
        _InputY = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(_InputX, _InputY) * MoveSpeed * Time.deltaTime);
    }
}
