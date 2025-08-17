using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PlayerControls : MonoBehaviour
{
    Rigidbody rb;

    public GameObject AoEpivot;
    public GameObject characterSprite;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isStunned) StartCoroutine(ClearStun(stunDuration));

        Movement();

        Gravity();
    }


    public bool northBounds;
    public bool southBounds;
    public bool westBounds;
    public bool eastBounds;

    int speed = 3;

    bool isJumping;
    int jumpHeight = 1;
    float jumpTimer = 0;
    float jumpTime = 1.5f;

    void Movement()
    {
        Vector3 velocity = rb.linearVelocity;

        if (!isJumping) // Walking
        {
            // Forward/back (Z axis)
            if (Input.GetKey(KeyCode.W) && !northBounds && !isStunned)
                velocity.z = 1;

            else if (Input.GetKey(KeyCode.S) && !southBounds && !isStunned)
                velocity.z = -1;

            else
                velocity.z = 0;


            // Left/right (X axis)
            if (Input.GetKey(KeyCode.A) && !westBounds && !isStunned)
                velocity.x = -1;

            else if (Input.GetKey(KeyCode.D) && !eastBounds && !isStunned)
                velocity.x = 1;

            else
                velocity.x = 0;

        }


        else // Jumping
        {
            if (Input.GetKey(KeyCode.W))
                velocity.z = 1;

            else if (Input.GetKey(KeyCode.S))
                velocity.z = -1;

            else
                velocity.z = 0;


            if (Input.GetKey(KeyCode.A))
                velocity.x = -1;

            else if (Input.GetKey(KeyCode.D))
                velocity.x = 1;

            else
                velocity.x = 0;

            jumpTimer += Time.deltaTime;

            if (jumpTimer < jumpTime / 2)
            {
                float jumpHeightStep = Mathf.Lerp(-jumpHeight, 0, jumpTimer / jumpTime);
                characterSprite.transform.localPosition =
                    new Vector3(characterSprite.transform.localPosition.x, jumpHeightStep + jumpHeight, characterSprite.transform.localPosition.z);
            }
            else
            {
                float jumpHeightStep = Mathf.Lerp(0, jumpHeight, jumpTimer / jumpTime);
                characterSprite.transform.localPosition =
                    new Vector3(characterSprite.transform.localPosition.x, -jumpHeightStep + jumpHeight, characterSprite.transform.localPosition.z);
            }
        }

        
        Vector3 horizontalVelocity = new Vector3(velocity.x, 0, velocity.z).normalized * speed;

        rb.linearVelocity = new Vector3(horizontalVelocity.x, rb.linearVelocity.y, horizontalVelocity.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            StartCoroutine(Jump(jumpTime));
        }
    }


    private IEnumerator Jump(float time)
    {
        yield return new WaitForSeconds(time);
        jumpTimer = 0;
        isJumping = false;
    }


    void Gravity()
    {
        if (northBounds && southBounds && eastBounds && westBounds && !isJumping) rb.useGravity = true;
        else rb.useGravity = false;
    }


    [SerializeField] float stunDuration = 2.5f;
    
    public bool isStunned = false;

    public IEnumerator ClearStun(float time)
    {
        yield return new WaitForSeconds(time);
        isStunned = false;
    }
}
