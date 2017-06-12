using UnityEngine;
using System.Collections;

public class Bitki : MonoBehaviour
{

    public float can, odundegeri, elmadegeri;
    public Transform[] odunlarsp;
    public Transform elmasp;
    public GameObject odun, elma;
    DataItem dataitem;

    Rigidbody agirlik;

    void Start()
    {
        dataitem = GameObject.FindGameObjectWithTag("DataItem").GetComponent<DataItem>();
        agirlik = GetComponent<Rigidbody>();
        agirlik.isKinematic = true;
        agirlik.useGravity = false;
        can = 100;
        odundegeri = Random.Range(2, 5);
    }


    void Update()
    {
        if (can <= 0)
        {
            agirlik.useGravity = true;
            agirlik.isKinematic = false;
            Invoke("Sil", Random.Range(4, 5));

        }
    }

    void OdunlariCikar()
    {
        elmadegeri = Random.Range(0, 2);
        if (elmadegeri == 1)
        {
            GameObject elmam = Instantiate(elma, elmasp.position, Quaternion.identity) as GameObject;
            elmam.GetComponent<Obje>().item = dataitem.items[6];
        }
        for (int i = 0; i < odundegeri; i++)
        {
            GameObject odunum = Instantiate(odun, odunlarsp[i].position, Quaternion.identity) as GameObject;
            odunum.GetComponent<Obje>().item = dataitem.items[4];
        }
    }

    void Sil()
    {
        OdunlariCikar();
        Destroy(gameObject);
    }
}
