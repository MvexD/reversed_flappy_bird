using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracksPlayer : MonoBehaviour {



    Transform player;

    float offsetY;



	// Use this for initialization
	void Start () {
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");

        if(player_go == null)
        {
            Debug.LogError("Nie mozna znalezc obiektu z tagiem player");
            return;
        }

        player = player_go.transform;

        offsetY = transform.position.y - player.position.y;

		
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            Vector3 pos = transform.position;
           // transform.position.x = player.position.x + offsetX;
            pos.y = player.position.y + offsetY;
            transform.position = pos;
        }
		
	}
}
