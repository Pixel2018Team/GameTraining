using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider collision)
    {

        var obj = collision.gameObject;
        if (obj.tag == TagsRef.PLAYER_TAG)
        {
            var playerController = obj.GetComponent<PlayerController>();
            Debug.Log("col with player");
            if (playerController != null)
            {
                playerController.FreeTheAis(gameObject);
            }
        }
    }
}
