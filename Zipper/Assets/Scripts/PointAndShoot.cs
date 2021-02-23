using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PointAndShoot : MonoBehaviour
{
	public GameObject crosshairs;
	public GameObject gun;
	public GameObject bulletprefab;
	public GameObject bulletStart;

	public float bulletSpeed = 60.0f;
	private float timeBetweenShots;
	public float startTimeBetweenShots;
	private Vector3 target;

	void Start()
	{
		UnityEngine.Cursor.visible = false;
	}

	private void Update()
	{
		target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
		crosshairs.transform.position = new Vector2(target.x, target.y);

		Vector3 difference = (target - gun.transform.position).normalized;
		float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		gun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

		Vector3 aimScale = Vector3.one;
		if (rotationZ > 90 || rotationZ < -90)
		{
			aimScale.y = -1f;
		}
		else
		{
			aimScale.y = +1f;
		}
		gun.transform.localScale = aimScale;

		if (timeBetweenShots <= 0)
		{
			if (Input.GetMouseButtonDown(0))
			{
				float distance = difference.magnitude;
				Vector2 direction = difference / distance;
				direction.Normalize();
				fireBullet(direction, rotationZ);
				timeBetweenShots = startTimeBetweenShots;
			}
		}
		else {
			timeBetweenShots -= Time.deltaTime;
		}
	}

	void fireBullet(Vector2 direction, float rotationZ)
	{
		GameObject bullet = Instantiate(bulletprefab) as GameObject;
		bullet.transform.position = bulletStart.transform.position;
		bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
		bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
	}
}
