using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Car : MonoBehaviour {

	public float speed;
	public float minSpeedMultiplier = 1.0f;
	public float maxSpeedMultiplier = 2.0f;

	private AudioSource horn;
	private int points;
	
	void Start () {
		speed = Game.Instance.planeSpeed * Random.Range(minSpeedMultiplier, maxSpeedMultiplier);
		horn = GetComponent<AudioSource>();

		points = (int) (speed * 10);
	}
	
	void Update () {
		transform.Translate(Vector3.back * speed * Time.deltaTime);

		if (transform.position.z < -8  || !Game.Instance.playing)
		{
			Destroy(this.gameObject);
			Game.Instance.AddScore(points);
			
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Car"))
		{
			horn.Play();
			speed = other.gameObject.GetComponent<Car>().speed + 1.0f;
		}
	}
}
