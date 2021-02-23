using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_projectile : MonoBehaviour
{
	private Transform target;
	[SerializeField] private float shotSpeed;
	[SerializeField] private float maxLife = 2.0f;
	private float lifeBtwTimer;
	public GameObject destroyEffect;

	private void Awake()
	{
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	private void Update()
	{

		transform.position = Vector2.MoveTowards(transform.position, target.position, shotSpeed * Time.deltaTime);

		lifeBtwTimer += Time.deltaTime;

		if (lifeBtwTimer >= maxLife)
		{
			Instantiate(destroyEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player") 
		{
			Instantiate(destroyEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
