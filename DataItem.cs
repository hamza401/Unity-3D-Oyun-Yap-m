using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataItem : MonoBehaviour
{

    public List<Item> items;



    void Awake()
    {
        items.Add(new Item("", "", 0, 0, 0, 0, 0, 0, 0, 0, Item.ItemType.Bos));
        items.Add(new Item("Bicak", "Çakı ile küçük taşları kırabilirsiniz", 1, 1, 1, 20, 0, 0, 0, 1, Item.ItemType.Silah));
        items.Add(new Item("Ok", "Ok ile avlanabilirsiniz", 2, 1, 1, 15, 0, 0, 0, 100, Item.ItemType.Silah));
        items.Add(new Item("Balta", "Balta iyi ağaç keser", 3, 1, 1, 25, 0, 0, 0, 1, Item.ItemType.Silah));
        items.Add(new Item("Odun", "Odun oyunu bitirmek için gerekli bir eşyadır", 4, 1, 10, 0, 0, 0, 0, 1, Item.ItemType.Malzeme));
        items.Add(new Item("Tas", "Taş oyunu bitirmek için bir eşyadır", 5, 1, 10, 0, 0, 0, 0, 1, Item.ItemType.Malzeme));
        items.Add(new Item("Elma", "Elma açlığınızı giderir", 6, 1, 10, 0, 0, 10, 0, 1, Item.ItemType.Yiyecek));
    }


}
