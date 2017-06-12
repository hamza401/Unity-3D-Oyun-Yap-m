using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class EnvanterSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{


    public Item item;
    public int slotsayi;
    Kodlar kr;

    public Image itemicon;
    public Text itemmiktar;
    public GameObject itemkullanim;


    void Start()
    {
        kr = GameObject.FindGameObjectWithTag("Kodlar").GetComponent<Kodlar>();
    }

    void Update()
    {
        item = kr.er.items[slotsayi];

        if (item.itemismi != null)
        {
            itemicon.enabled = true;
            itemicon.sprite = item.itemicon;
            if (item.itemmiktar > 1)
            {
                itemmiktar.enabled = true;
                itemmiktar.text = item.itemmiktar.ToString();
            }
            else
            {
                itemmiktar.enabled = false;
            }
            if (item.itemkullanim <= 0)
            {
                kr.er.items[slotsayi].itemmiktar -= 1;
            }
            if (item.itemmiktar <= 0)
            {
                kr.er.items[slotsayi] = new Item();
            }
            if (item.itemtipi == Item.ItemType.Silah)
            {
                itemkullanim.SetActive(true);
                itemkullanim.transform.localScale = new Vector2(item.itemkullanim / 100, 1);
                if (item.itemkullanim > 75)
                {
                    itemkullanim.GetComponent<Image>().color = Color.green;
                }
                else if (item.itemkullanim > 25)
                {
                    itemkullanim.GetComponent<Image>().color = Color.yellow;
                }
                else if (item.itemkullanim > 0)
                {
                    itemkullanim.GetComponent<Image>().color = Color.red;
                }
            }
            else
            {
                itemkullanim.SetActive(false);
            }
        }
        else
        {
            itemicon.enabled = false;
            itemmiktar.enabled = false;
            itemkullanim.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if (item.itemismi != null)
        {
            kr.er.bilgipanelAc(item);
        }
    }
    public void OnPointerDown(PointerEventData data)
    {
        if (data.button.ToString() == "Left")
        {
            if (!kr.er.tasimaacik && item.itemismi != null)
            {
                kr.er.tasimapanelAc(item);
                kr.er.items[slotsayi] = new Item();
            }
            else if (kr.er.tasimaacik)
            {
                if (item.itemismi == null)
                {
                    kr.er.items[slotsayi] = kr.er.tasinanitem;
                    kr.er.tasimapanelKapat();
                }
                else
                {
                    if (item.itemismi == kr.er.tasinanitem.itemismi)
                    {
                        if (item.itemtipi == Item.ItemType.Yiyecek || item.itemtipi == Item.ItemType.Malzeme)
                        {
                            kr.er.items[slotsayi].itemmiktar += kr.er.tasinanitem.itemmiktar;
                            kr.er.tasimapanelKapat();
                        }
                    }
                    else
                    {
                        Item yeniItem = kr.er.items[slotsayi];
                        kr.er.items[slotsayi] = kr.er.tasinanitem;
                        kr.er.tasinanitem = yeniItem;
                    }
                }

            }
        }

        if (data.button.ToString() == "Right")
        {
            if (!kr.er.tasimaacik)
            {
                if (item.itemtipi == Item.ItemType.Yiyecek || item.itemtipi == Item.ItemType.Malzeme)
                {
                    if (item.itemmiktar > 1)
                    {
                        int deger = item.itemmiktar / 2;
                        Item yeniItem = new Item(item.itemismi, item.itembilgi, item.itemid, deger, item.itemdepomiktar, item.itemhasar, item.itemdefans, item.itemaclik, item.itemsu, item.itemkullanim, item.itemtipi);
                        kr.er.tasimapanelAc(yeniItem);
                        int deger2 = item.itemmiktar - deger;
                        kr.er.items[slotsayi].itemmiktar = deger2;
                    }
                }
            }
        }


    }
    public void OnPointerExit(PointerEventData data)
    {
        kr.er.bilgipanelKapat();
    }
}
