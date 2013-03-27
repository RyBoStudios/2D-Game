using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	// The speed at which the character moves.
	private float speed = 10.0f;
	// The amount my which to update the transform by translating it x and y.
	private float x, y;
	
	// Holds the information about the sprite and it's animations.
	private OTAnimatingSprite mySprite;
	
	private bool moveLeft;
	private bool moveRight;
	
	void Start () {
		mySprite = GetComponent<OTAnimatingSprite>();
		// Start the player in the left facing position.
		mySprite.Play ("runLeft");
		
		// These determine which direction the player is moving and if they are in motion.
		moveLeft = false;
		moveRight = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Move Left
		if(Input.GetKey(KeyCode.LeftArrow)){ 
			Debug.Log ("Left");
			x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
			if(!moveLeft) {
				mySprite.Play ("runLeft");
				moveLeft = true;
				moveRight = false;
			}	
		}
		// Move Right
		if(Input.GetKey(KeyCode.RightArrow)){
			Debug.Log ("Right");
			
			x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
			if(!moveRight) {
				mySprite.Play ("runRight");
				moveRight = true;
				moveLeft = false;
			}
		}
		// Stand still facing the direction you were previously moving.
		if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)){
			x = 0;
			y = 0;
			moveLeft = false;
			moveRight = false;
			mySprite.ShowFrame(0);
		}
		transform.Translate(x, y, 0);
	}
}
