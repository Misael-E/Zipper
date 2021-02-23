using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public GameObject hitEffect;
	public float lifeTime;
	private void Start()
	{
		Invoke("DestroyProjectile", lifeTime);
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{

		GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
		Destroy(effect, 0.5f);
		Destroy(gameObject);
	}

	private void DestroyProjectile()
	{
		GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
		Destroy(effect, 0.5f);
		Destroy(gameObject);
	}
}
