using System;
using Trap;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image[] things;
    [SerializeField] private Sprite[] collectImage;
    [SerializeField] private GameObject[] HP;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject DeathUI;
    [SerializeField] private GameObject GoToDoor;

    private AudioSource collect;
    private AudioSource ouch;

    private int hpIndex;
    private int levlComplete = 0;

    public static Action win = delegate { };

    void OnEnable()
    {
        hpIndex = HP.Length-1;
        TrapScript.damage += TrapScript_Damage;
        ThingsScript.collect += ThingsScript_Collect;
        BulletScript.damege += TrapScript_Damage;
        collect = GetComponent<AudioSource>();
        var child = transform.GetChild(0);
        ouch = child.gameObject.GetComponent<AudioSource>() ;
    }

    private void TrapScript_Damage()
    {
        if (hpIndex>=0)
        {
            ouch.Play();
            HP[hpIndex].SetActive(false);
            if (hpIndex==0)
            {
                death();
            }
            hpIndex--;
        }
        
    }

    private void death()
    {
        UI.SetActive(false);
        DeathUI.SetActive(true);
    }
    private void ThingsScript_Collect(string name)
    {
        if (name=="krona")
        {
            things[1].sprite = collectImage[1];
        }
        else if (name =="koleso")
        {
            things[0].sprite = collectImage[0];
        }
        else if (name == "ball")
        {
            things[2].sprite = collectImage[2];
        }

        if (levlComplete == 2)
        {
            GoToDoor.SetActive(true);
            win();
        }

        collect.Play();
        levlComplete++;
    }

    void OnDisable()
    {
        TrapScript.damage -= TrapScript_Damage;
        ThingsScript.collect -= ThingsScript_Collect;
        BulletScript.damege -= TrapScript_Damage;

    }
}
