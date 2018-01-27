using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public float speed;

	void Start () {
		
	}
	
	void Update () {
		float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		
		transform.Translate(translation, 0, 0);
	}
}
