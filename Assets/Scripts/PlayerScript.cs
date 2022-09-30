using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Vector3 Groundnormal;
    public GameObject Planet;
    public GameObject PlayerPlaceholder;
    public float speed = 4;
    public float JumpHeight = 1.2f;
    float gravity = 100;
    float distanceToGround;
    bool OnGround = false;
    private Vector2 mousePos;
    private Rigidbody rb;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
 
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerRotation();
        Jump();
        GroundControl();
        GravityAndRotation();
    }

    void PlayerRotation()
    {
        // Rotation of the player to the mouse
        mousePos = Input.mousePosition;
        Vector2 lookDirection = mousePos - new Vector2(Screen.width / 2, Screen.height / 2);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, -angle, 0);
    }
    
    void PlayerMovement()
    {
        // Movement of the player
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(x, 0, z);
    }
    
    void Jump()
    {
        // Jump of the player
        if (Input.GetKeyDown(KeyCode.Space) && OnGround == true)
        {
            rb.AddForce(transform.up * 40000 * JumpHeight * Time.deltaTime);
 
        }
    }

    void GroundControl()
    {
        //GroundControl
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10)) {
 
            distanceToGround = hit.distance;
            Groundnormal = hit.normal;
 
            if (distanceToGround <= 0.2f)
            {
                OnGround = true;
            }
            else {
                OnGround = false;
            }
            
        }
    }

    void GravityAndRotation()
    {
        //GRAVITY and ROTATION
        Vector3 gravDirection = (transform.position - Planet.transform.position).normalized;
        if (OnGround == false)
        {
            rb.AddForce(gravDirection * -gravity);
        }
        
        // Rotation of the player to the planet
        Quaternion toRotation = Quaternion.FromToRotation(transform.up, Groundnormal) * transform.rotation;
        transform.rotation = toRotation;
    }
}
