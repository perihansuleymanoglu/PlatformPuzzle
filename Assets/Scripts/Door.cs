using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderer;

    //gelinen ve gidilecek kapıları tutmak için kullandığımız değişkenler
    public Door previous, next;

    //Kapı daha önce seçilmiş mi diye kontrol etmek için kullanacağımız değişken
    public bool selected;

    //Kapının üstüne tıklayınca çalışacak fonksiyon
    private void OnMouseDown()
    {
        //Kapı daha önce seçilmişse temizle fonksiyonunu çalıştırıyor.
        if (selected)
            Clean();

        //Doormanager'da tuttuğumuz kapı boşsa veya tıklanan kapı tutulan kapıysa onu giriş kapısı yapmak için manager'da atıyoruz
        if (DoorManager.instance.door == null || DoorManager.instance.door == this)
        {
            DoorColorChange(Color.green);
            DoorManager.instance.door = this;
        }
        //doormanager'da tuttuğumuz kapı doluysa bir giriş var demek. Yani şimdi tıklanan kapı çıkış kapısı olacak
        else
        {
            //tıklanan kapının öncekine managerda tutulan kapı atılıyor.
            previous = DoorManager.instance.door;
            //tıklanan kapının öncekinin ilerisine managerda tutulan kapı atılıyor.
            previous.next = this;
            DoorColorChange(Color.red);
            //managerda tuttuğumuz kapıyı boşaltıyoruz ki yeni kapıları seçebilelim
            DoorManager.instance.door = null;
        }
        selected = true;
    }

    public void Clean()
    {
        if (previous != null)
        {
            previous.DoorColorChange(Color.white);
            previous.Clean();
        }
        else if (next != null)
        {
            next.previous = null;
            next.DoorColorChange(Color.white);
            // next.Clean();
            next = null;
        }
        selected = false;
    }
    void DoorColorChange(Color c)
    {
        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            spriteRenderer[i].color = c;
        }
    }
}
