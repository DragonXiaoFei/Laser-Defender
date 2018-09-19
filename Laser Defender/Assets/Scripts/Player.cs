using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.05f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;

    float xMin;
    float xMax;

    float yMin;
    float yMax;

	// Use this for initialization
	void Start () {
        SetUpMoveBoundaries();
        StartCoroutine(Hey());
		
	}



    // Update is called once per frame
	void Update () {
        Move();
        FireLaser();


		
	}

    IEnumerator Hey()
    {
        Debug.Log("hey");
        yield return new WaitForSeconds(3);
        Debug.Log("HEY");
    }

	private void FireLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
           GameObject laser = Instantiate(
                laserPrefab,
                transform.position,
                Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

        }
    }

    private void Move()
	{
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYpos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXpos, newYpos);


	}

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0 + padding, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1 - padding, 0, 0)).x;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0 + padding, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1 - padding, 0)).y;
    }


}
