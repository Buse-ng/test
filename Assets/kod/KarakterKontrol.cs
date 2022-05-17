using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    public GameObject patlama;


    // bu kisim oyun kontrolundeki skor sayisi icin yaptigimiz kisim
    OyunKontrol oyunkontrolScripti;
    //Oncelikle scriptin bagli oldugu oyun objesine erismemiz gerekiyor bu yuzden Find komutunu kullanacagiz.
    void Start()
    {
        oyunkontrolScripti = GameObject.Find("Scripts").GetComponent<OyunKontrol>();
    }
    // buraya kadar.


    void OnMouseDown()
    {
        GameObject gobj= Instantiate(patlama, transform.position, transform.rotation) as GameObject; // gameobj gobj bi sure sonra patlama kaybolsun diye
        Destroy(this.gameObject); // tikladigimizda kaybolmasini sagliyor.
        Destroy(gobj, 0.2f);
        oyunkontrolScripti.SkorArtir();  //buradan skor artirma scriptimize erismis olacagiz.
    }
}
