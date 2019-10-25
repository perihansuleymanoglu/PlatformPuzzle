using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunny : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 100;
    [SerializeField]
    private Rigidbody2D rigidbody2D;
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private int direction = 1;
    [SerializeField]
    private Sprite cheer;
    [SerializeField]
    private GameObject finish, gameOver;


    private void Update()
    {
        //Karakterin sürekli olarak sola veya sağa gitmesini sağlar
        transform.position += Vector3.right * Time.deltaTime * speed * direction;

        //Karakterin y eksenindeki konumu -5'in altındaysa oyunu bitirir
        if (transform.position.y < -5)
        {
            gameOver.SetActive(true);
            speed = 0;
        }
    }

    //OnCollisionEnter çarpışmaları takip ediyor


    private void OnCollisionEnter2D(Collision2D other)
    {
        //Duvar tagine sahip bir objeye çarptığı zaman if bloğunun içine girer.
        if (other.transform.tag == "Duvar")
        {
            //Karakterin yönünü değiştirip, x ekseninde karakteri döndürür
            direction *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        if (other.transform.tag == "Trambolin")
        {          
        //Tramboline temas ederse Yukarı doğru bir güç uyguluyor. 
            rigidbody2D.AddForce(transform.up * jumpForce);
        //Temas edilen trambolinin içindeki trambolin scriptinin jump fonksiyonu çağrılıyor
                    other.transform.GetComponent<Trambolin>().Jump();
        }
        //Engele çarpmışsa eğer game over oluyor
        if (other.transform.tag == "Engel")
        {
            gameOver.SetActive(true);
        }
    }

    //Tetiklenmelerei takip eden kod


    private void OnTriggerEnter2D(Collider2D other)
    {
        //Tetiklediği objenin içinde Door scripti varsa onu door değişkenine atıyor
        Door door = other.transform.GetComponent<Door>();

        //door değişkeni boş değilse yani tetiklenen objenin içinde door scripti varsa bu if'in içine giriyor
        if (door != null)
        {
            //Tetiklediği objenin door scriptinin next değişkeni (o da bir door nesnesi aslında) boş değilse bu ife giriyor
            if (door.next != null)
            {
                //next boş değilse karakter o next'e ışınlanıyor
                //yani pozisyonunu tetiklenen objenin içindeki tuttuğu next değişkeninin pozisyonu yapıyor
                transform.position = door.next.transform.position;

                //Door.cs de açıkladım bunu 
                door.next.Clean();
            }
        }
        //Tetiklenen objenin içinde door scripti yoksa ve objenin tagi Carrotsa bu ife giriyor
        else if (other.transform.tag == "Carrot")
        {
            //Buraya girmişse bölüm bitmiş oluyor.
            //finish objesini aktif ediyoruz ki sonraki bölüme geçişi sağlayalım
            finish.SetActive(true);
            //Tavşanın animatorünü kapatıyoruz ki yürüme animasyonu dursun.
            this.GetComponent<Animator>().enabled = false;
            //Ardından karakterin sevinme spritenı aktif ediyoruz 
            //Tavşan havuç bulunca bölüm bitiyor
            this.GetComponent<SpriteRenderer>().sprite = cheer;
            //speed değerini sıfırlıyoruz ki tavşanın sağa veya sola gidişi dursun
            speed = 0;
        }

    }
}
