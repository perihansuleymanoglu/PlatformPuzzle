using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
  /*
      Bir tane door nesnesi tutmamız gerekiyor.
      Giriş kapısını elimizde tutup
      Çıkış kapısına tıklayınca o kapının previous değişkenine atmak için
  */

  // Elimizde tutacağımız kapı nesnesine her yerden ulaşabilmek için instance oluşturduk.
  public static DoorManager instance;
  public Door door;

  // Sahne açılırken kapıyı boşaltıp, instance boşsa oluşturulmasını sağladık.
  void Awake()
  {
    if (instance == null)
      instance = this;
  }
}
