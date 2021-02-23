using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody2D rb;
	private float moveH, moveV;
	public Animator anim;
	GameObject health;
	[SerializeField] private float moveSpeed = 5.0f;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
		moveV = Input.GetAxisRaw("Vertical") * moveSpeed;

		anim.SetFloat("Horizontal", moveH);
		anim.SetFloat("Vertical", moveV);
		anim.SetFloat("Speed", moveSpeed);
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(moveH, moveV);
	}
}
