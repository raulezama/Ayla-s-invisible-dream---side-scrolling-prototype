using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AylaAnim : MonoBehaviour {

	public Animator anim;
	public Rigidbody rb;
	private float inputH;
	public int walkSpeed;
	public int runSpeed;
	private bool run;
	private bool facingRight;
    public AudioClip jumpSound;
    AudioSource playerAS;

	//Fire PowerUp
	public bool firePower;

	//For Jumping
	public float jumpPower;
	private bool jump;
	private bool grounded = false;
	private Collider[] groundCollisions;
	private float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rb = GetComponent<Rigidbody>();
        playerAS = GetComponent<AudioSource>();
		facingRight = true;
		run = false;
		firePower = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.LeftShift))
		{
			run = true;
		}
		else
		{
			run = false;
		}

		groundCollisions = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer);
		
		if(Input.GetKeyDown(KeyCode.Space) && groundCollisions.Length>0)
		{
			anim.SetBool("jump", true);
			rb.AddForce(new Vector3(0, jumpPower, 0));
			anim.Play("JUMP01", -1, 0.3f);
            playerAS.clip = jumpSound;
            playerAS.Play();
		}
		else
		{
			anim.SetBool("jump", false);
		}
	}

	void FixedUpdate()
	{

		inputH = Input.GetAxis("Horizontal");

		anim.SetFloat("inputH", Mathf.Abs(inputH));
		anim.SetBool("run", run);

		float moveX = inputH * walkSpeed * Time.deltaTime;
		if(run)moveX *= runSpeed;

		rb.velocity = new Vector3(moveX, rb.velocity.y, 0);
		if(moveX > 0 && !facingRight) 
			Flip();
		else if(moveX < 0 && facingRight) 
			Flip();
	}

	/// <summary>
    /// Invierte la dirección del personaje
    /// </summary>
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 faceDirection = transform.localScale;
		faceDirection.z *= -1;
		transform.localScale = faceDirection;
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag == "Ground"){
			anim.SetBool("grounded", true);
		}
	}

	void OnCollisionExit(Collision other)
	{
		if(other.collider.tag == "Ground"){
			anim.SetBool("grounded", false);
		}
	}

    /// <summary>
    /// Obtiene el valor de la dirección del personaje
    /// </summary>
    /// <returns></returns>
	public float GetFacing()
	{
		if(facingRight) 
			return 1;
		else 
			return -1;
	}

    /// <summary>
    /// Obtiene el valor del estado del personaje, si este esta corriendo o no
    /// </summary>
    /// <returns></returns>
	public bool GetRunning()
	{
		return run;
	}

    /// <summary>
    /// Obtiene un valor verdadero si el jugador ha adquirido un item de fuego
    /// </summary>
    /// <param name="firePowerActive"></param>
    /// <returns></returns>
	public bool IsFirePowerActive(bool firePowerActive)
	{
		firePower = firePowerActive;
		return firePower;
	}
}
