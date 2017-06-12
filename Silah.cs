using UnityEngine;
using System.Collections;

public class Silah : MonoBehaviour
{

    public float hasar1, hasar2, mesafe;
    RaycastHit hit;
    Kodlar kr;

    public float maxzaman, zaman;
    public bool aktif;

    void Start()
    {
        kr = GameObject.FindGameObjectWithTag("Kodlar").GetComponent<Kodlar>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !aktif)
        {
            aktif = true;
            zaman = maxzaman;
            GetComponent<Animation>().Play();
            GetComponent<AudioSource>().Play();
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, mesafe))
            {
                if (hit.transform.tag == "Agac")
                {
                    Bitki bi = hit.transform.gameObject.GetComponent<Bitki>();
                    bi.can -= Random.Range(hasar1, hasar2);
                    kr.er.items[GetComponent<ItemEl>().slotsayi].itemkullanim -= Random.Range(3, 6);
                }
                if (hit.transform.tag == "Canavar")
                {
                    Bitki bi = hit.transform.gameObject.GetComponent<Bitki>();
                    bi.can -= Random.Range(hasar1, hasar2);
                    kr.er.items[GetComponent<ItemEl>().slotsayi].itemkullanim -= Random.Range(3, 6);
                }
            }

        }
        if (aktif)
        {
            if (zaman > 0)
            {
                zaman -= Time.deltaTime;
            }
            else
            {
                aktif = false;
            }
        }
    }
}
