using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour {

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 FlapVelocity;
    public float maxSpeed = 5f;
    public float forwardSpeed = 2f;
    public Vector2 direction;
    public Vector3 mousePosition;
    public float Points;
    public Vector3 speed;

    

    public bool didFlap;



	// Use this for initialization
	void Start () {
        didFlap = false;

    }
    // graphics and imput updates.
    void Update()
    {
       
        if (Input.GetMouseButton(0))
        {
  
           mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           direction = (mousePosition - transform.position).normalized;
           // velocity += direction.x + gravity * Time.deltaTime;
           velocity = new Vector3(direction.x * forwardSpeed, velocity.y);


        }
        if (didFlap != true && Input.GetMouseButtonDown(0))
        {
            didFlap = true;
            didFlap = false;
        }
//        if (direction.x < 0)
//        {
//            Vector3 obrot = new Vector3(transform.localScale.x, transform.localScale.y);
//            transform.localScale = obrot;


//        }
        if (direction.x > 0)
        {
            Vector3 obrot = new Vector3(transform.localScale.x * 1, transform.localScale.y);
            transform.localScale = obrot;



        }
    }






        // physics calcs here.
        // Update is called once per frame
        void FixedUpdate()
    {
        velocity += (gravity * Time.deltaTime);

        if (didFlap == true)
        {
            didFlap = false;
            if (velocity.y < 0)
            {
                velocity.y = 0;
            }
            if (velocity.y > 5)
            {
                velocity.y = 5;
            }

            velocity = FlapVelocity;
        }
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);



        transform.position += (velocity * Time.deltaTime);
        float angle = 0;
        if (velocity.y < 0 && direction.x > 0)
        {
            angle = Mathf.Lerp(0, -90, -velocity.y / maxSpeed*2);
        }
        else if (velocity.y < 0 && direction.x < 0)
        {
            angle = Mathf.Lerp(0, 90, -velocity.y / maxSpeed*2);
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
        speed = velocity;

        if (direction.x < 0)
        {
            Vector3 obrot = new Vector3(-1.0f, transform.localScale.y);
            transform.localScale = obrot;
        }
        else if (direction.x > 0)
        {
            Vector3 obrot = new Vector3(1.0f, transform.localScale.y);
            transform.localScale = obrot;
        }




    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coins"))
        {
            Points += 1;
            didFlap = true;
            Destroy(other.gameObject);
        }
        
    }

}
