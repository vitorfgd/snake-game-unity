using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {

	public GameObject food;

	public Transform leftWall;
	public Transform rightWall;
	public Transform upWall;
	public Transform bottomWall;

	void Start () {
		InvokeRepeating ("CreateFood", 1f, 2.5f);
	}

	private void CreateFood (){

		int x = (int)(Random.Range (leftWall.position.x + 1f, rightWall.position.x -1f));
		int y = (int)(Random.Range (upWall.position.y - 1f, bottomWall.position.y +1f));

		Instantiate (food, new Vector2 (x, y), Quaternion.identity);
	}
}
