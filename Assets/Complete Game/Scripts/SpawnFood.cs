using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {

	public GameObject food;

	public Transform leftWall;
	public Transform rightWall;
	public Transform upWall;
	public Transform bottomWall;

	void Start () {
		InvokeRepeating ("CreateFood", 3f, 4f);
	}

	private void CreateFood (){

		int x = (int)(Random.Range (leftWall.position.x, rightWall.position.x));
		int y = (int)(Random.Range (upWall.position.y, bottomWall.position.y));

		Instantiate (food, new Vector2 (x, y), Quaternion.identity);
	}
}
