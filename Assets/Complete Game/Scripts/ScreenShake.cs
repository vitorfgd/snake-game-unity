using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {

	private bool shakeit = false;
	public float shakeAmount;
	public GameObject cam;
	public GameObject [] background;


	void Start (){
		InvokeRepeating ("doShake", 0.2f, 0.5f);
	}

	private void doShake(){
		
		int x = (int)Random.Range (0, 4);
		shakeit = true;
		
		iTween.ShakePosition (this.gameObject, new Vector3 (1, 0, 0), 0.3f);

		for (int i = 0; i < 4; i++){
			background[i].SetActive (false);
		}

		background[x].SetActive (true);
	}

	void StopShaking(){
		shakeit = false;
	}

}