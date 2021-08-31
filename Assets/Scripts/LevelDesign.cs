using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDesign : MonoBehaviour
{

    void Update()
    {
        // DÜŞMANLARIN HEPSİNİN DÜŞTÜĞÜNÜ GÖREBİLMEK İÇİN
        if (GameManager.Instance.FailedEnemy == 7)
        {
            GameManager.Instance.GameWin = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            //HER DÜŞEN İÇİN 1 ARTIYOR
            GameManager.Instance.FailedEnemy += 1;
        }

        if (other.gameObject.tag == "Player")
        {
            //OYUNCU DÜŞERSE BİTİYOR
            GameManager.Instance.GameOver = true;
        }
    }

    public void ChangeScene()
    {
        // RETRY VEYA NEXT İÇİN
        SceneManager.LoadScene("SampleScene");
    }
}
