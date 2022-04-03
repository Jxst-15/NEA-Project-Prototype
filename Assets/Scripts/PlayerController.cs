using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _speed = 2f; //Decides how fast player moves
    public float JumpForce = 1f; //Decides how high player jumps

    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); //Creates reference to Rigid Body
    }

    void Update()
    {
        var _move = Input.GetAxis("Horizontal"); //Moving left and right
        transform.position = transform.position + new Vector3(_move * _speed * Time.deltaTime, 0, 0); //Actual character moving

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f) //Jumping
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse); //Mechanic for jumping
        }
    }
}
