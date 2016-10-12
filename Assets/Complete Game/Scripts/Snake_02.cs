using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class Snake_02 : MonoBehaviour {

	public GameObject tailPrefab;
	public TextMesh player2_text;

	private Vector2 dir = Vector2.right;
	private List<Transform> tail = new List<Transform>();
	private bool ate = false;

	void Start () {
		InvokeRepeating ("Move", 0.04f, 0.04f);
	}

	void Update (){

		player2_text.text = tail.Count.ToString();

		if (Input.GetKey (KeyCode.D)){
			if (dir != Vector2.left) {
				dir = Vector2.right;
			}
		} else if (Input.GetKey (KeyCode.A)){
			if (dir != Vector2.right) {
				dir = Vector2.left;
			}
		} else if (Input.GetKey (KeyCode.W)){
			if (dir != Vector2.down) {
				dir = Vector2.up;
			}
		} else if (Input.GetKey (KeyCode.S)){
			if (dir != Vector2.up){
				dir = Vector2.down;	
			}
		}

		if (Input.GetAxis ("LeftJoystick2Vertical") < 0){
			if (dir != Vector2.down) {
				dir = Vector2.up;
			}
		} else if (Input.GetAxis ("LeftJoystick2Vertical") > 0){
			if (dir != Vector2.up) {
				dir = Vector2.down;
			}
		}

		if (Input.GetAxis ("LeftJoystick2Horizontal") > 0){
			if (dir != Vector2.left) {
				dir = Vector2.right;
			}
		} else if (Input.GetAxis ("LeftJoystick2Horizontal") < 0){
			if (dir != Vector2.right) {
				dir = Vector2.left;
			}
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
		} else if (coll.name.StartsWith("parede")) {
			SceneManager.LoadScene("main") ;
		}  else if (coll.name.StartsWith("tail")){
			SceneManager.LoadScene("main");
		}
	}
}
