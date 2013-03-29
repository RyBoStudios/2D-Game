using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// This script allows an object to know what it within it's trigger zone.
public class SeeWhatsInMyTrigger : MonoBehaviour {
	
	// This list holds the colliders within the trigger zone of the object.
	public List<Collider> collidersInThisTrigger;
	
	// When a collider enters the trigger zone add this collider to the list.
	public void OnTriggerEnter(Collider collider){
		if(!collidersInThisTrigger.Contains(collider)){
			collidersInThisTrigger.Add(collider);
		}
	}
	
	// When a collider exits the trigger zone add this collider to the list.
	public void OnTriggerExit(Collider collider){
		if(collidersInThisTrigger.Contains(collider)){
			collidersInThisTrigger.Remove(collider);
		}
	}
}