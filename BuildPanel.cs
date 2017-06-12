using UnityEngine;
using System.Collections;

public class BuildSpawner : MonoBehaviour
{

    public int id1, id2, id3;
    public int istenenmiktar1, istenenmiktar2, istenenmiktar3;
    public int verilenmiktar1, verilenmiktar2, verilenmiktar3;

    public bool sart1, sart2, sart3;


    public GameObject build;


    void Start()
    {

    }


    void Update()
    {
        if (id1 != 0)
        {
            if (verilenmiktar1 >= istenenmiktar1)
            {
                sart1 = true;
            }
        }
        else
        {
            sart1 = true;
        }

        if (id2 != 0)
        {
            if (verilenmiktar2 >= istenenmiktar2)
            {
                sart2 = true;
            }
        }
        else
        {
            sart2 = true;
        }


        if (id3 != 0)
        {
            if (verilenmiktar3 >= istenenmiktar3)
            {
                sart3 = true;
            }
        }
        else
        {
            sart3 = true;
        }

        if (sart1 && sart2 && sart3)
        {
            BuildEt();
        }
    }

    void BuildEt()
    {
        Instantiate(build, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

