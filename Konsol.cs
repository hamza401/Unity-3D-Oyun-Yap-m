using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Konsol : MonoBehaviour
{

    public InputField isim, miktar, mesaj;
    Kodlar kr;
    Envanter er;
    DataItem di;
    public int sayi;
    void Start()
    {

        kr = GameObject.FindGameObjectWithTag("Kodlar").GetComponent<Kodlar>();
        er = kr.er;
        di = kr.di;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (isim.text != "" && miktar.text != "")
            {
                int miktarim = int.Parse(miktar.text);
                Ekle(isim.text, miktarim);
                isim.text = "";
                miktar.text = "";
            }
        }
    }

    void Ekle(string itemismi, int itemmiktari)
    {
        sayi++;
        for (int i = 0; i < di.items.Count; i++)
        {
            if (itemismi == di.items[i].itemismi)
            {
                er.itemEkle(di.items[i].itemid, itemmiktari);
            }
        }
        if (sayi <= 5)
        {
            mesaj.text += "\n" + itemmiktari + " Tane " + itemismi + " Eklendi.";
        }
        else
        {
            mesaj.text = "";
            mesaj.text += "\n" + itemmiktari + " Tane " + itemismi + " Eklendi.";
        }
    }
}
