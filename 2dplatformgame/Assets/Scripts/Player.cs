using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D player;
    private Arrow arrow = new Arrow();
    
    public float movementSpeed;
    
    bool grounded = true;
    
    bool firing;
    public float jumpspeed;
    Vector3 jump;
    // Start is called before the first frame update
    void Start()
    {
        jump = new Vector2(0.0f, 2.0f);
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
    }
    void CheckForInput()
    {
        
        if (Input.GetKey("a"))  
        {
            Move("a");
        }
        if (Input.GetKey("d"))
        {
            Move("d");
        }
        if (Input.GetKey("space"))
        {
            Move("space");
        }
        if (Input.GetMouseButtonUp(0))
        {
            arrow.CreateArrow();
        }
    }
    void Move(string direction)
    {
        movementSpeed -= player.velocity.x; 
        if (direction == "a")
        {
            player.transform.position -= new Vector3(movementSpeed,0,0);
        }
        if (direction == "space" && grounded == true)
        { 
            player.AddForce(jump * jumpspeed, ForceMode2D.Impulse);
            Debug.Log("yo");
            grounded = false;
        }
        if (direction == "d")
        {
            player.transform.position += new Vector3(movementSpeed, 0, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        grounded = true;
    }

    
    
}
