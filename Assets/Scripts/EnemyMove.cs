using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMove : MonoBehaviour
{
    public float Speed;
    public float ShortestDist;
    public GameObject TargetCoin;
    public float CrashPowerEnemy;
    

    void Start()
    {
        ShortestDist = 10000f;
        CrashPowerEnemy = 2f;
    }


    void Update()
    {

        // EN YAKIN COINE HAREKET ETTİREN YAPAY ZEKA
        for (int i = 0; i < GameManager.Instance.EnemyList.Count; i++)
        {

            if (GameManager.Instance.EnemyList[i] != null)
            {
                float dist = Vector3.Distance(GameManager.Instance.EnemyList[i].gameObject.transform.position, transform.position);
                if (dist < ShortestDist)
                {
                    ShortestDist = dist;
                    TargetCoin = GameManager.Instance.EnemyList[i];
                }
            }
        }
        if (TargetCoin != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetCoin.transform.position, Speed * Time.deltaTime);
             transform.LookAt(TargetCoin.gameObject.transform);
        }
        if (TargetCoin == null)
        {
            // TargetCoin yok olduğunda döngüye tekrar girmesi için
            ShortestDist = 10000f;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Vector3 Scale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f, transform.localScale.z + 0.1f);
            transform.DOScale(Scale, 0.1f);
            Destroy(other.gameObject);
            ShortestDist = 10000f;
            CrashPowerEnemy += 0.2f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            // Düşmanların kendi aralarında çarpması için Playyer da kullanılan aynı işlemler uygulanıyor.
            // Karşı tarafı kendi gücüne göre hareket ettiriyor.
            Vector3 Distance = collision.gameObject.transform.position - transform.position;

            collision.gameObject.transform.DOMove(new Vector3(transform.position.x + Distance.x * CrashPowerEnemy, transform.position.y, transform.position.z + Distance.z * CrashPowerEnemy), 0.3f);

        }
    }
}
