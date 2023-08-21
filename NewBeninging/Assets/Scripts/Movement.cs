using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    int maxJump = 1;
    public float jumpForce;
    public float horizontal;
    float slamJumpTimer = 0f;
    public float slamJumpMultiplier;
    bool slamming = false;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        slamJumpTimer -= Time.deltaTime;
        horizontal = Input.GetAxis("Horizontal");

        gameObject.transform.Translate(Vector3.right * speed * horizontal *Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && maxJump > 0)
        {
            if (slamJumpTimer > 0f)
            {
                rb.AddRelativeForce(Vector3.up * jumpForce * slamJumpMultiplier, ForceMode.Impulse);
            }
            else
            {
                rb.AddRelativeForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            maxJump--;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            rb.AddRelativeForce(Vector3.down * 20f, ForceMode.Impulse);
            slamming = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            maxJump = 1;
            if (slamming == true)
            {
                slamJumpTimer = 0.25f;
                slamming = false;
            }
        }
    }
}
