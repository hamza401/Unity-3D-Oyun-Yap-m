using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{

    public string itemismi, itembilgi;
    public int itemid, itemmiktar, itemdepomiktar, itemhasar, itemdefans, itemaclik, itemsu;
    public float itemkullanim;
    public Sprite itemicon;
    public GameObject itemmodel;
    public ItemType itemtipi;


    public enum ItemType
    {

        Silah,
        Malzeme,
        Yiyecek,
        Build,
        Bos

    }

    public Item(string isim, string bilgi, int id, int miktar, int depo, int hasar, int defans, int aclik, int su, float kullanim, ItemType tip)
    {
        itemismi = isim;
        itembilgi = bilgi;
        itemid = id;
        itemmiktar = miktar;
        itemdepomiktar = depo;
        itemhasar = hasar;
        itemdefans = defans;
        itemaclik = aclik;
        itemsu = su;
        itemtipi = tip;
        itemkullanim = kullanim;
        itemicon = Resources.Load<Sprite>(id.ToString());
        itemmodel = Resources.Load<GameObject>(itemismi);
    }

    public Item()
    {

    }
}
