using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class YereAtma : MonoBehaviour,IPointerDownHandler {

	Envanter er;
	public GameObject objem,objesp;

	void Start () {
		er = GameObject.FindGameObjectWithTag ("Envanter").GetComponent<Envanter> ();
		objesp = GameObject.FindGameObjectWithTag ("Objesp");
	}
	

	void Update () {
	
	}


	public void OnPointerDown(PointerEventData data){
		if (data.button.ToString () == "Left") {
			if (er.tasimaacik) {
				yereat (er.tasinanitem);
				er.tasimapanelKapat ();
			}
		}
	}

	public void yereat(Item item){
		GameObject obje = Instantiate (Resources.Load<GameObject>(item.itemismi), objesp.transform.position, Quaternion.identity) as GameObject;
		obje.GetComponent<Obje> ().item = item;
	}
}
