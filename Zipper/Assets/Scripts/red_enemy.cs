using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_enemy : Enemy
{
	private float shotRate = 2.0f;
	private float shotTimer;
	private float range;
	private Transform target;
	private int damage;

	public GameObject projectile;
	public GameObject deathEffect;

	private void Awake()
	{
		target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}

	protected override void Introduction()
	{
	}

	protected override void Move()
	{
		base.Move();
	}

	protected override void Attack()
	{
		base.Attack();

		shotTimer += Time.deltaTime;

		if (shotTimer > shotRate) 
		{
			if (Vector2.Distance(transform.position, target.position) < range)
			{
				Instantiate(projectile, transform.position, Quaternion.identity);
			}
			shotTimer = 0;
		}
	}

	protected override void Death()
	{
		base.Death();

		Instantiate(deathEffect, transform.position, Quaternion.identity);
	}
}
