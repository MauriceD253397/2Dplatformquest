using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private GameObject arrow;
    private GameObject player;
    bool arrowCreated = false;
    bool arrowFlying = false;
    public float arrowRange;
    public float arrowSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("MainCharacter");
        arrow = GameObject.Find("arrow"); 
    }

    // Update is called once per frame
    void Update()
    {
        FireArrow();
    }
    public void FireArrow()
    {
        arrow = GameObject.Find("arrow");
        // TODO:: Rotate arrow, make arrow fly
        // creating the arrow

        //  arrow.AddComponent<Rigidbody2D>();
        //  arrow.AddComponent<CapsuleCollider2D>();


        //  arrow.gameObject.name = "arrow";


        if (arrowFlying == true)
        {
            arrow.transform.TransformDirection(new Vector3(arrowSpeed, -1, 10));
            Debug.Log("te");
        }
        

    }
    public void CreateArrow()
    {

        player = GameObject.Find("MainCharacter");
        GameObject arrow = GameObject.Find("Arrow");

        arrow.transform.position = player.transform.position;

        arrow.transform.rotation = new Quaternion(0, 0, 90, 90);
        arrowCreated = true;
        arrowFlying = true;

        if (arrowCreated == true && arrowFlying == true)
        {
            Update();
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        arrowFlying = false;
    }
}
