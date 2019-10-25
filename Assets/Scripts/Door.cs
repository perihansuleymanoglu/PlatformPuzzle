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
        //Önceki boş değilse içine giriyor
        if (previous != null)
        {
            //Önceki kapının rengini beyaz yapıyor
            previous.DoorColorChange(Color.white);
            //öncekinin Clean metodunu çağırıyor.
            previous.Clean();
            
        }
        //Sonraki boş değilse içine giriyor
        else if (next != null)
        {
            //Sonrakinin öncesini null yapıyor
            next.previous = null;
            //Sonraki kapının rengini beyaz yapıyor
            next.DoorColorChange(Color.white);
            //next i boşaltıyor
            next = null;
        }
        selected = false;
    }

/*
Topluca açıklayayım satır satır beceremedim.

Öncelikle ışınlanma olayı gerçekleşirken karakterin girdiği kapının next değişkeninin Clean metodu çağrılıyor. Yani gideceğimiz kapının.
Ardından o Clean metodunun içinde önceki kapıyı tutan previous kapısının boş olup olmadığı kontrol ediliyor. Işınlanma anında boş olma durumu zaten yok.
Ama farklı durumlarda boş olabilir.
Previous burada geldiğimiz kapıyı belirtiyor. rengini beyaz yapıp o kapının Clean metodunu çağırıyoruz.

Bu durumda geldiğimiz kapının tuttuğu bir previous değeri yok yani previous boş ama next dolu çünkü gittiğimiz kapıyı tutuyor.
Yani else if'e giriyor.
Burada gidilen kapının önceki kapısı yani portala girdiğimiz kapıyı tutan değişken boşaltılıyor.
Ardından gittiğimiz kapının rengi beyaz yapılıyor.
En son da geldiğimiz kapıda gittiğimiz kapıyı tutan next değişkeni boşaltılıyor.


 */

    void DoorColorChange(Color c)
    {
        for (int i = 0; i < spriteRenderer.Length; i++)
        {
            spriteRenderer[i].color = c;
        }
    }
}
