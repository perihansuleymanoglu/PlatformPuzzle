using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trambolin : MonoBehaviour
{
    public Sprite[] sprites;

    public void Jump()
    {
        //Burada da changesprite fonksiyonu çağırılıyor ama bu fonksiyon ienumarator yani belli bir gecikme vermemize olanak sağlıyor
        StartCoroutine(ChangeSprite());
    }
    IEnumerator ChangeSprite()
    { // üstteki satırı işliyor bir saniye bekliyor alt tarafı işliyor
    //Burada da değdiğimiz objenin üst objesinin resminim değiştiriyoruz 
        transform.parent.GetComponent<SpriteRenderer>().sprite = sprites[1];
        //burada 1 saniye bir bekle sonra devam etmesini sağlıyoruz
        yield return new WaitForSeconds(1);
        transform.parent.GetComponent<SpriteRenderer>().sprite = sprites[0];

    }
}
