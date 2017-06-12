using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    Vector3 poz;
    public float yukseklik;

    public GameObject obje;
    Kodlar kr;

    void Start()
    {
        kr = GameObject.FindGameObjectWithTag("Kodlar").GetComponent<Kodlar>();
    }

    // Update is called once per frame
    void Update()
    {
        poz = transform.position;
        poz.y = Terrain.activeTerrain.SampleHeight(transform.position);
        poz.y = poz.y + yukseklik;
        transform.position = poz;

        if (Input.GetKeyDown(KeyCode.H))
        {
            Instantiate(obje, transform.position, transform.rotation);
            kr.er.items[GetComponent<ItemEl>().slotsayi].itemmiktar -= 1;
        }
    }
}