﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
		
	}

	private void Move()
	{
        var deltaX = Input.GetAxis("Horizontal");
        var newXpos = transform.position.x + deltaX;
        transform.position = new Vector2(newXpos, transform.position.y);

	}
}
