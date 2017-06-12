using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class YanPanel : MonoBehaviour
{

    public List<GameObject> slotlar;

    public int slotsayi;

    public Sprite seciliSlot, boslot;

    Envanter er; El el;

    void Start()
    {
        er = GameObject.FindGameObjectWithTag("Envanter").GetComponent<Envanter>();
        el = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<El>();
    }


    void Update()
    {
        iconBelirle();
        slotsayiBelirle();
        itemSec(er.items[slotsayi]);
    }


    void slotsayiBelirle()
    {


        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            slotsayi--;

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            slotsayi++;

        }

        if (slotsayi < 0)
        {
            slotsayi = 5;
        }
        if (slotsayi > 5)
        {
            slotsayi = 0;
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotsayi = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotsayi = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotsayi = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slotsayi = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            slotsayi = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            slotsayi = 5;
        }
    }
    void iconBelirle()
    {
        for (int i = 0; i < slotlar.Count; i++)
        {
            slotlar[i].GetComponent<Image>().sprite = boslot;
        }

        slotlar[slotsayi].GetComponent<Image>().sprite = seciliSlot;
    }

    void itemSec(Item item)
    {
        for (int i = 0; i < el.objeler.Count; i++)
        {
            if (el.objeler[i].name == item.itemismi)
            {
                el.objeler[i].SetActive(true);
                el.objeler[i].GetComponent<ItemEl>().slotsayi = slotsayi;
            }
            else
            {
                el.objeler[i].SetActive(false);
            }
        }
    }
}

