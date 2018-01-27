using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax;
}

public class Player : MonoBehaviour
{
    public Boundary boundary;
    public float speed;
    public float tilt;
    public Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

        rigidBody.velocity = movement * speed;
        rigidBody.position = new Vector3(Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax), 0, 0);
        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
    }
}