using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour {

	public GameObject tailPrefab;

	private Vector2 dir = Vector2.right;
	private List<Transform> tail = new List<Transform>();
	private bool ate = false;

	void Start () {
		InvokeRepeating ("Move", 0.04f, 0.04f);
	}

	void Update (){
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.D)){
			dir = Vector2.right;
		} else if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)){
			dir = Vector2.left;
		} else if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)){
			dir = Vector2.up;
		} else if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)){
			dir = Vector2.down;
		}

		if (Input.GetAxis ("LeftJoystickVertical") < 0){
			dir = Vector2.up;
		} else if (Input.GetAxis ("LeftJoystickVertical") > 0){
			dir = Vector2.down;
		}

		if (Input.GetAxis ("LeftJoystickHorizontal") > 0){
			dir = Vector2.right;
		} else if (Input.GetAxis ("LeftJoystickHorizontal") < 0){
			dir = Vector2.left;
		}
	}

	private void Move (){
		
		Vector2 v = transform.position;
		transform.Translate (dir);

		if (ate) {
			GameObject g = (GameObject)Instantiate (tailPrefab, v, Quaternion.identity);
			tail.Insert (0, g.transform);
			ate = false;
		}

		if (tail.Count > 0){
			tail.Last ().position = v;
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.name.StartsWith("food")) {
			ate = true;
			Destroy(coll.gameObject);
		}
		else if (coll.name.StartsWith("parede")) {
			SceneManager.LoadScene("main") ;
		}
	}
}
