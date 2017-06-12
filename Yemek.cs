using UnityEngine;
using System.Collections;

public class Yemek : MonoBehaviour {

	public float aclik1,aclik2;
	Kodlar kr;
	void Start () {
		kr = GameObject.FindGameObjectWithTag ("Kodlar").GetComponent<Kodlar> ();
	}
	

	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			GetComponent<Animation> ().Play ();
			GetComponent<AudioSource> ().Play ();
			Invoke ("Sil", 0.5f);

		}
	}

	void Sil(){
		transform.root.gameObject.GetComponent<Karakter> ().aclik += Random.Range (aclik1, aclik2);
		kr.er.items [GetComponent<ItemEl> ().slotsayi].itemmiktar -= 1;
	}
}
