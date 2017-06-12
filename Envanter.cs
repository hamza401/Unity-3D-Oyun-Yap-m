using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Envanter : MonoBehaviour
{

    public List<Item> items;
    public int baslangicmiktar, slotmiktar;
    public GameObject slot, bilgiPanel, tasimaPanel;

    public bool bilgiacik, tasimaacik;

    DataItem dataitem;
    BilgiPanel bp;
    public Item bilgiitem, tasinanitem;

    void Start()
    {
        dataitem = GameObject.FindGameObjectWithTag("DataItem").GetComponent<DataItem>();
        bp = bilgiPanel.GetComponent<BilgiPanel>();
        for (int i = baslangicmiktar; i < slotmiktar; i++)
        {
            GameObject slotobj = (GameObject)Instantiate(slot);
            slotobj.transform.SetParent(gameObject.transform);
            slotobj.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            slotobj.GetComponent<EnvanterSlot>().slotsayi = i;
        }

        for (int i = 0; i < slotmiktar; i++)
        {
            items.Add(new Item());
        }

        itemEkle(1, 1);
        itemEkle(2, 1);
        itemEkle(3, 1);
        itemEkle(4, 0);
        itemEkle(5, 0);
        itemEkle(6, 0);

    }

    public void itemEkle(int id, int miktar)
    {
        for (int i = 0; i < dataitem.items.Count; i++)
        {
            if (dataitem.items[i].itemid == id)
            {
                Item yeniitem = new Item(dataitem.items[i].itemismi, dataitem.items[i].itembilgi, dataitem.items[i].itemid,
                    miktar, dataitem.items[i].itemdepomiktar, dataitem.items[i].itemhasar, dataitem.items[i].itemdefans,
                    dataitem.items[i].itemaclik, dataitem.items[i].itemsu, dataitem.items[i].itemkullanim, dataitem.items[i].itemtipi);


                if (yeniitem.itemtipi == Item.ItemType.Yiyecek || yeniitem.itemtipi == Item.ItemType.Malzeme)
                {
                    SlotunUzerineEkle(yeniitem);
                }
                else if (yeniitem.itemmiktar > 1)
                {
                    int deger = yeniitem.itemmiktar - 1;
                    Item yeniItem2 = new Item(yeniitem.itemismi, yeniitem.itembilgi, yeniitem.itemid,
                        deger, yeniitem.itemdepomiktar, yeniitem.itemhasar, yeniitem.itemdefans, yeniitem.itemaclik, yeniitem.itemsu, yeniitem.itemkullanim, yeniitem.itemtipi);
                    yeniitem.itemmiktar = 1;

                    BosSlotitemEkle(yeniitem);

                    itemEkle(yeniItem2.itemid, yeniItem2.itemmiktar);
                }
                else
                {
                    BosSlotitemEkle(yeniitem);
                }

            }
        }

    }

    public void BosSlotitemEkle(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemismi == null)
            {
                items[i] = item;
                break;
            }
        }
    }

    public void SlotunUzerineEkle(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].itemismi == item.itemismi)
            {
                items[i].itemmiktar += item.itemmiktar;
                break;
            }
            if (i == items.Count - 1)
            {
                BosSlotitemEkle(item);
            }
        }
    }


    public void bilgipanelAc(Item item)
    {
        bilgiacik = true;
        bilgiitem = item;
        bilgiPanel.SetActive(true);


    }

    public void bilgipanelKapat()
    {
        bilgiacik = false;
        bilgiitem = null;
        bilgiPanel.SetActive(false);
    }

    public void tasimapanelAc(Item item)
    {
        tasimaacik = true;
        tasinanitem = item;
        tasimaPanel.SetActive(true);
    }

    public void tasimapanelKapat()
    {
        tasimaacik = false;
        tasinanitem = null;
        tasimaPanel.SetActive(false);
    }


    void Update()
    {

        if (bilgiacik)
        {
            bilgiPanel.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            bp.itemisim.GetComponent<Text>().text = bilgiitem.itemismi;
            bp.itemhasar.GetComponent<Text>().text = "Hasar : " + bilgiitem.itemhasar;
            bp.itemDefans.GetComponent<Text>().text = "Defans : " + bilgiitem.itemdefans;
            bp.itemAclik.GetComponent<Text>().text = "Açlık : " + bilgiitem.itemaclik;
            bp.itemSu.GetComponent<Text>().text = "Su : " + bilgiitem.itemsu;
            bp.itemBilgi.GetComponent<Text>().text = bilgiitem.itembilgi;
            bp.itemicon.sprite = bilgiitem.itemicon;
        }

        if (tasimaacik)
        {
            tasimaPanel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = tasinanitem.itemicon;
            tasimaPanel.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            if (tasinanitem.itemmiktar > 1)
            {
                tasimaPanel.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = true;
                tasimaPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = tasinanitem.itemmiktar.ToString();
            }
            else
            {
                tasimaPanel.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = false;
            }
        }
    }
}
