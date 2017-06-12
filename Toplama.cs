using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Toplama : MonoBehaviour {

	RaycastHit hit;
	Envanter er;Obje oe;BuildSpawner bs;YanPanel yp;Kodlar kr;


	public Text raycastYazi;

	void Start () {
		er = GameObject.FindGameObjectWithTag ("Envanter").GetComponent<Envanter> ();
		kr = GameObject.FindGameObjectWithTag ("Kodlar").GetComponent<Kodlar> ();
		yp = kr.yp;
	}
	

	void Update () {
		if (Physics.Raycast (Camera.main.transform.position, Camera.main.transform.forward, out hit, 5)) {
			if (hit.transform.gameObject.tag == "Obje") {
				oe = hit.transform.gameObject.GetComponent<Obje> ();
				if (oe.item.itemmiktar > 1) {
					raycastYazi.text = oe.item.itemismi + " x" + oe.item.itemmiktar;
				} else {
					raycastYazi.text = oe.item.itemismi;
				}

				if (Input.GetKeyDown (KeyCode.F)) {
					er.itemEkle (oe.item.itemid, oe.item.itemmiktar);
					Destroy (hit.transform.gameObject);

				}
			
			}

			if (hit.transform.gameObject.tag == "Spawner") {
				bs = hit.transform.gameObject.GetComponent<BuildSpawner> ();
				if (Input.GetKeyDown (KeyCode.F)) {
					if (er.items [yp.slotsayi].itemid == bs.id1) {
						if (bs.verilenmiktar1 < bs.istenenmiktar1) {
							bs.verilenmiktar1 += 1;
							er.items [yp.slotsayi].itemmiktar -= 1;
						}
					}
					if (er.items [yp.slotsayi].itemid == bs.id2) {
						if (bs.verilenmiktar2 < bs.istenenmiktar2) {
							bs.verilenmiktar2 += 1;
							er.items [yp.slotsayi].itemmiktar -= 1;
						}
					}
					if (er.items [yp.slotsayi].itemid == bs.id3) {
						if (bs.verilenmiktar3 < bs.istenenmiktar3) {
							bs.verilenmiktar3 += 1;
							er.items [yp.slotsayi].itemmiktar -= 1;
						}
					}
				}
			}
		} else {
			raycastYazi.text = "";
		}
		}
	}
