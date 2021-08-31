using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{   
    
    public float Speed;
    public float CollisionDistance;
    bool Timer=true;
    public GameObject Coin;
    public float CrashPower;

    void Start()
    {
        CrashPower = 2f;
    }

  


    void Update()
    {
        // Hareket Mekaniği
        Vector3 Target = new Vector3(Input.mousePosition.x -(Screen.width/2), transform.position.y, Input.mousePosition.y- (Screen.height / 4));

        transform.position = Vector3.MoveTowards(transform.position, Target, Speed * Time.deltaTime );
        transform.LookAt(Target);
       
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y + 14.49f, transform.position.z - 17.18f);


        // Haritada rastgele saniyede 1 coin objesi oluşturuyor.
        if (Timer)
        {
            Timer = false;
            StartCoroutine("CoinInstantiate");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Enemy")
        {

            // Çarptığımız anda aradaki farktan bir vector çiziyoruz.
            Vector3 Distance = collision.gameObject.transform.position - transform.position;

            // Çarptığımız düşmanı bu vector yönünde hareket ettiriyoruz.
            // Coin topladıkça güçlendiğimiz için CrahsPower değişkeni ekledim. Karşı düşman büyüdükçe savrulması zor olması içinde CrashPower'dan scale değerini çıkardım.
            collision.gameObject.transform.DOMove(new Vector3(transform.position.x + Distance.x * 2*(CrashPower- collision.gameObject.transform.localScale.x), collision.transform.position.y, transform.position.z + Distance.z * 2 * (CrashPower - collision.gameObject.transform.localScale.x)), 0.3f);

            // Kendi geri tepmemiz bulduğumuz vectorün tersinde oluyor. Düşman güçlendikçe savrulmamız artsın diye Scale değerini vectörle çarptım.
            transform.DOMove(new Vector3(transform.position.x - (Distance.x * (collision.transform.localScale.x/2)), transform.position.y, transform.position.z - (Distance.z * (collision.transform.localScale.x/2))), 0.3f);
        }
    }

    IEnumerator CoinInstantiate()
    {
        // Haritanın belirli aralığında Random coin clonluyor.
        Vector3 CoinPosition = new Vector3(Random.Range(-14f, 14f), 0.3f, Random.Range(-14f, 14f));
        GameObject NewCoin = Instantiate(Coin, CoinPosition, Quaternion.identity);
        // LİSTEYE EKLİYORUZ.
        GameManager.Instance.EnemyList.Add(NewCoin);
        yield return new WaitForSeconds(1);
        Timer = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Coin")
        {

            // Coin topladıkça Scale ve CrashPower artıyor.
            Vector3 Scale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
            transform.DOScale(Scale, 0.1f);
            Destroy(other.gameObject);
            CrashPower += 0.2f;
        }
    }
}
