using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] float maxSpeed;
    private int playerDirection;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        playerDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //This is where we add forces that move the charcter
        playerDirection = 0;
        if (Input.GetKey(KeyCode.D))
        {
            playerDirection += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerDirection += -1;
        }
        rigidBody.AddForce(Vector3.right * playerSpeed * playerDirection);
        //This is where we add the force need to make our player jump
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddForce(Vector3.up * jumpForce);
        }
        //put in max speed
        if (rigidBody.velocity.sqrMagnitude > maxSpeed * maxSpeed) ;        {
            Vector3 norm = rigidBody.velocity.normalized;
            rigidBody.velocity = new Vector3(norm.x * maxSpeed, norm.y * maxSpeed, norm.z * maxSpeed);
        }
    }
}
