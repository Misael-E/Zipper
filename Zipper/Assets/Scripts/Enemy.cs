using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	private float healthPoint;
	[SerializeField] private float maxHealthPoint;
	[SerializeField] private float distance;

	private Transform target; //Target is player

	private void Start()
	{
		healthPoint = maxHealthPoint;
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		Introduction();
	}

	private void Update()
	{
		if (healthPoint <= 0)
		{
			Death();
		}
		Attack();
	}
	private void FixedUpdate()
	{
		Move();
	}
	protected virtual void Introduction()
	{
		Debug.Log("HP: " + healthPoint + "moveSpeed: " + moveSpeed);
	}

	protected virtual void Move()
	{
		if (Vector2.Distance(transform.position, target.position) < distance)
		{

			transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
		}
	}

	protected virtual void Attack()
	{
	}

	protected virtual void Death()
	{
		Destroy(gameObject);
	}
}
