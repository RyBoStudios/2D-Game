using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	// The speed at which the character moves.
	private float runSpeed = 10.0f;
	private float climbSpeed = 2.0f;
	// The amount my which to update the transform by translating it x and y.
	private float x, y;
	
	// Holds the information about the sprite and it's animations.
	private OTAnimatingSprite mySprite;
	
	private bool climbing;
	private bool moveLeft;
	private bool moveRight;
	
	private Vector3 stallVelocity = new Vector3(0.0f, 0.0f, 0.0f);
	
	void Start () {
		mySprite = GetComponent<OTAnimatingSprite>();
		// Start the player in the left facing position.
		mySprite.Play ("runLeft");
		
		// These determine which direction the player is moving and if they are in motion.
		climbing = false;
		moveLeft = false;
		moveRight = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Move Left
		if(Input.GetKey(KeyCode.LeftArrow)){ 
			Debug.Log ("Left");
			x = Input.GetAxis("Horizontal") * Time.deltaTime * runSpeed;
			if(!moveLeft) {
				mySprite.Play ("runLeft");
				moveLeft = true;
				moveRight = false;
				climbing = false;
				this.rigidbody.useGravity = true;
			}	
		}
		// Move Right
		if(Input.GetKey(KeyCode.RightArrow)){
			Debug.Log ("Right");
			
			x = Input.GetAxis("Horizontal") * Time.deltaTime * runSpeed;
			if(!moveRight) {
				mySprite.Play ("runRight");
				moveRight = true;
				moveLeft = false;
				climbing = false;
				this.rigidbody.useGravity = true;
			}
		}
		
		// Climb Ladding if there is a ladder present
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)){
			Debug.Log ("Climb");
			
			y = Input.GetAxis("Vertical") * Time.deltaTime * climbSpeed;
			if(!climbing) {
				mySprite.Play ("climb");
				climbing = true;
				moveRight = false;
				moveLeft = false;
				
				// If the player is falling then stop the fall and turn off gravity.
				this.rigidbody.velocity = stallVelocity;
				this.rigidbody.useGravity = false;
			}
		}
		
		// Stand still facing the direction you were previously moving.
		if(!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow)){
			x = 0;
			y = 0;
			moveLeft = false;
			moveRight = false;
			climbing = false;
			mySprite.ShowFrame(0);
		}
		transform.Translate(x, y, 0);
	}
}
