using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class OyunAyarlari : MonoBehaviour
{

    public GameObject envanterPanel, konsolekran, karakter,menuPanel;

    public bool envanter, konsol,menu;
    Kodlar kr;
    void Start()
    {
        envanter = false;
        kr = GameObject.FindGameObjectWithTag("Kodlar").GetComponent<Kodlar>();
        karakter = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            envanter = !envanter;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu = !menu;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            konsol = !konsol;
        }
        if (konsol)
        {
            konsolekran.SetActive(true);
        }
        else
        {
            konsolekran.SetActive(false);
        }
        if (envanter)
        {
            envanterPanel.SetActive(true);

        }
        else
        {
            envanterPanel.SetActive(false);

        }
        if (menu)
        {
            menuPanel.SetActive(true);

        }
        else
        {
            menuPanel.SetActive(false);

        }

        if (envanter || konsol || menu)
        {
            karakter.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
            Screen.lockCursor = false;
        }
        else
        {
            karakter.GetComponent<FirstPersonController>().enabled = true;
            Cursor.visible = false;
            Screen.lockCursor = true;
        }
    }
}

