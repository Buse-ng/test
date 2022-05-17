using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    public UnityEngine.UI.Text zamantxt,skortxt;
    public float zamanSay = 60;
    float patlatilanSay = 0;

    public GameObject patlama;

    void Start()
    {
        skortxt.text = "Skor: " + patlatilanSay;
    }
    void Update()
    {
        if (zamanSay > 0) // zaman texti 0 dan buyuk oldugu surece guncellenecek. eksi degerlere dusmeyecek bu sekilde.
        {
           zamanSay -= Time.deltaTime; //saniyede 1 azaltacagiz.
           zamantxt.text = "Zaman: " + (int)zamanSay; // zamani int olarak geri dondurmesi daha guzel durur.
        }
        else  // eger zaman 0 in altina dusmusse 
        {                                   // birden fazla objeyi ayni anda bulabiliyoruz bu komutla: FindGameObjectsWithTag
            GameObject[] gobj = GameObject.FindGameObjectsWithTag("karakter");  // "" arasina oyun objesinin tag ini girmemiz gerekiyor. sahnede bulunan bu tag e sahip tum objeleri bulup bunun icine atmýs olacak.
        
            for(int i=0; i <gobj.Length; i++)
            {
                Instantiate(patlama, gobj[i].transform.position, gobj[i].transform.rotation);
                Destroy(gobj[i]);
            }
        
        }
    }
    public void SkorArtir()
    {
        patlatilanSay += 1;
        skortxt.text = "Skor: " + patlatilanSay;
    }

    // karakter her vuruldugunda(patladiginda) sayiyi 1 artiracagiz bu islemi de karakter kontrol kisminda yapacagiz.
}
