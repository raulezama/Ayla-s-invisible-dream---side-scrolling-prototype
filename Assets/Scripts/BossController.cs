using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

public GameObject flipModel;
    EnemyHealth enemyH;


    //Audio Options
    public AudioClip[] idleSounds;
    public float idleSoundTime;
    private AudioSource enemyMovementAS;
    private float nextIdleSound = 0f;

    public float detectionTime;
    private float startRun;
    private bool firstDetection;

    //Movement Options
    public float walkSpeed;
    public float runSpeed;
    public bool facingRight = true;
    private float moveSpeed;
    private bool running;
    private bool stunned;

    Rigidbody enemyRB;
    Animator enemyAnim;
    Transform detectedPlayer;

    private bool detected;

    // Use this for initialization
    void Start()
    {
        enemyRB = GetComponentInParent<Rigidbody>();
        enemyAnim = GetComponentInParent<Animator>();
        enemyMovementAS = GetComponent<AudioSource>();
        enemyH = transform.root.GetComponent<EnemyHealth>();

        running = false;
        detected = false;
        firstDetection = false;
        moveSpeed = walkSpeed;
        //stunned = false;

        if (Random.Range(0, 10) > 5) Flip();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (detected)
        {
            if (detectedPlayer.position.x < transform.position.x && facingRight) Flip();
            else if (detectedPlayer.position.x > transform.position.x && !facingRight) Flip();

            if (!firstDetection)
            {
                startRun = Time.time + detectionTime;
                firstDetection = true;
            }
        }

        if (detected && !facingRight)
            enemyRB.velocity = new Vector3((moveSpeed * -1), enemyRB.velocity.y, 0);
        else if (detected && facingRight)
            enemyRB.velocity = new Vector3(moveSpeed, enemyRB.velocity.y, 0);

        if (!running && detected)
        {
            if (startRun < Time.time)
            {
                moveSpeed = runSpeed;
                enemyAnim.SetTrigger("run");
                running = true;
            }
        }

        // if(enemyH.GetStun()){
        // 	enemyRB.velocity = Vector3.zero;
        // 	stunned = false;
        // 	enemyAnim.SetTrigger("stun");
        // }

        if (!running)
        {
            if (Random.Range(0, 10) > 5 && nextIdleSound < Time.time)
            {
                AudioClip tempClip = idleSounds[Random.Range(0, idleSounds.Length)];
                enemyMovementAS.clip = tempClip;
                enemyMovementAS.Play();
                nextIdleSound = idleSoundTime + Time.time;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !detected)
        {
            detected = true;
            detectedPlayer = other.transform;
            enemyAnim.SetBool("detected", detected);
            if (detectedPlayer.position.x < transform.position.x && facingRight) Flip();
            else if (detectedPlayer.position.x > transform.position.x && !facingRight) Flip();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            firstDetection = false;
            if (running)
            {
                enemyAnim.SetTrigger("run");
                moveSpeed = walkSpeed;
                running = false;
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scale = flipModel.transform.localScale;
        enemyRB.MoveRotation(Quaternion.Inverse(enemyRB.rotation));
    }
}

