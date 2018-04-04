using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour {
	void Start(){
		Debug.Log ("Test sound is playing");
		AkSoundEngine.PostEvent ("test", gameObject);
	}
}
