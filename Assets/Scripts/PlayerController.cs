using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidbody;
    public float jumpPower = 10;
    public float jumpInterval = 0.2f;
    private float jumpCooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpCooldown -= Time.deltaTime;
        var isGameActive = GameManager.Instance.IsGameActive();
        var canJump = jumpCooldown <= 0 && isGameActive;

        if(canJump)
        {
            var JumpPlayer = Input.GetKey(KeyCode.Space);
            if(JumpPlayer)
            {
                Jump();
            }
        }
        thisRigidbody.useGravity = isGameActive;
    }

    void OnCollisionEnter(Collision other)
    {
        onCustomCollisionEnter(other.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        onCustomCollisionEnter(other.gameObject);
    }

    private void onCustomCollisionEnter(GameObject other)
    {
        var isSensor = other.CompareTag("Sensor");
        if(isSensor)
        {
            GameManager.Instance.Score++;
            Debug.Log("Score: " + GameManager.Instance.Score);
        }
        else
        {
            GameManager.Instance.EndGame();
        }
    }
    private void Jump()
    {
        jumpCooldown = jumpInterval;

        thisRigidbody.velocity = Vector3.zero;
        thisRigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
    }
}
