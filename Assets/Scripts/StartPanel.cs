using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartPanel : MonoBehaviour
{

    public float duration;
    public string mytext;
    public Text txtui;
    string txt = "";
    public string mytext1;
    public Text txtui1;
    string txt2 = "";

    public GameObject play;

    void Start()
    {
        //Oyunun ve Geliştirenin ismi efektli gelmesi için
        play.SetActive(false);
        DOTween.To(() => txt, x => txt = x, mytext, duration).OnUpdate(() => txtui.text = txt).OnComplete(() =>
        {

            DOTween.To(() => txt2, x => txt2 = x, mytext1, duration).OnUpdate(() => txtui1.text = txt2).OnComplete(() =>
            {

                play.SetActive(true);

            });




        });
    }

   
    public void Changescene()
    {
        //Start Butonu
        SceneManager.LoadScene("SampleScene");
    }
}
