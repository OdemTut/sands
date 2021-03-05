using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speedMove;

    private Vector3 moveVector;

    private Rigidbody rb;
    private CharacterController ch_controller;
    public void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    public void Update()
    {
        Vector2 xMove = new Vector2(Input.GetAxisRaw("Horizontal") * transform.right.x, Input.GetAxisRaw("Horizontal") * transform.right.z);
        Vector2 zMove = new Vector2(Input.GetAxisRaw("Vertical") * transform.forward.x, Input.GetAxisRaw("Vertical") * transform.forward.z);
        Vector2 speedVelocity = (xMove + zMove).normalized * speedMove * Time.deltaTime;
        rb.velocity = new Vector3(speedVelocity.x, rb.velocity.y, speedVelocity.y);
    }
}