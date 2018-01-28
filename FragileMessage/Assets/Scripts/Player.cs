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
    public AudioClip launch;
    public AudioClip crash;

    private Rigidbody rigidBody;
    private Animator animator;
    private AudioSource audioSource;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Game.Instance.playing)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);

            rigidBody.velocity = movement * speed;
            rigidBody.position = new Vector3(Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax), rigidBody.position.y, rigidBody.position.z);
            rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            audioSource.PlayOneShot(crash);
            rigidBody.constraints =  RigidbodyConstraints.FreezePositionY;
            Game.Instance.GameOver();
        }
    }

    public void Restart()
    {
        rigidBody.constraints =  RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        animator.enabled = true;
        animator.SetTrigger("restart");
    }
    
    public void PlayIntro()
    {
        animator.SetTrigger("playIntro");
    }

    public void PlayLauchAudio()
    {
        audioSource.PlayOneShot(launch);
    }
    
    public void ReadyToPlay()
    {
        animator.enabled = false;
        rigidBody.isKinematic = false;
        Game.Instance.StartGame();
    }
}