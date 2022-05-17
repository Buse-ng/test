using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterOlusturucu : MonoBehaviour
{
    public GameObject karakter;
    float olusturmaSuresi = 1f;
    float zamanSayaci = 0f;

    OyunKontrol okscripti;
    void Start()
    {
        okscripti = this.gameObject.GetComponent<OyunKontrol>(); //okscritpti: oyun kontrol scrpti
    }
    void Update()
    {
        zamanSayaci -= Time.deltaTime;

        int katsayi = ( int)(okscripti.zamanSay / 10) - 6; // hiz her 10 da bir hizini artiricak. 60 sn yaptigimiz icin 6 yaptik sonuc -1 gelisn diye.
        katsayi *= -1; // katsayi zamansayaci=50 ken 1 40 ken 2 .. seklinde deger ureticek gittikce hizimiz articak. 

        if (zamanSayaci<0 && okscripti.zamanSay>0)  // artik 0 in altina dustugunde balon uretmeyecek.
        {
            // buna erisebilmek icin gameobject gobj -------- as gameobject yaptik.
            GameObject gobj= Instantiate(karakter, new Vector3(Random.Range(-2.3f,2.3f), -6f, 0), Quaternion.Euler(0, 0, 0)) as GameObject; // karakter olusuturuyoruz. karakter, nerede olusacagi, dongusel degerleri
            gobj.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, Random.Range(30f*katsayi, 60f*katsayi), 0));   // hýz eklemek istedik.
            zamanSayaci = olusturmaSuresi;
        }
    }
}
