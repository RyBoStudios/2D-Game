using UnityEngine;
using System.Collections;

public class InteractionRay : MonoBehaviour {

	public float rayHeight;
	public float rayLength;
	
	// Update is called once per frame
	void Update () {
		RaycastHit rayhit;
		
		if( Physics.Raycast(
				transform.position + Vector3.up *rayHeight, 
				transform.forward, 
				out rayhit, 
				rayLength )
			){
			
			gameObject.SendMessage(
				"Interact", 
				null, 
				SendMessageOptions.DontRequireReceiver
				);
		}
	}
}
