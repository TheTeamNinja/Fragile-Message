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
    
    private Rigidbody rigidBody;
    private Animator animator;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Game.Instance.playing)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

            rigidBody.velocity = movement * speed;
            rigidBody.position = new Vector3(Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax), 0, 0);
            rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
        }
    }

    public void PlayIntro()
    {
        animator.enabled = true;
        animator.SetTrigger("playIntro");
    }
    
    public void ReadyToPlay()
    {
        animator.enabled = false;
        rigidBody.isKinematic = false;
        Game.Instance.StartGame();
    }
}