using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {
    public Vector3 coinSize;
    public static int scoreValue = 0;
    public float Pointsx;
    public Vector3 localScale;
    public float a = 10;

    Transform Coins;

    // Use this for initialization
    void Start () {
        //Pointsx = 0;
        //coinSize = transform.localScale;




    }
	
	// Update is called once per frame
    // Pobieranie wartosci punktow z obiektu Player


	void Update () {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        BirdMovement huj = Player.GetComponent<BirdMovement>();

        //player.Points = Pointsx;
        Pointsx = huj.Points;
        //huj.Points = Pointsx;


        if (Pointsx >= a)
        {
            a += 10;
            Vector3 coinSizex = new Vector3(transform.localScale.x -0.05f, transform.localScale.y - 0.05f);
            transform.localScale = coinSizex;


        }
        if (Pointsx > 150)
        {
            Vector3 coinSizexx = new Vector3(0.33f, 0.5f);
            transform.localScale = coinSizexx;
        }


    }

}
