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

    private int hpIndex;
    private int levlComplete = 0;

    void OnEnable()
    {
        hpIndex = HP.Length-1;
        TrapScript.damage += TrapScript_Damage;
        ThingsScript.collect += ThingsScript_Collect;
        BulletScript.damege += TrapScript_Damage;

    }

    private void TrapScript_Damage()
    {
        if (hpIndex>=0)
        {
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
            Debug.Log("Level");
        }

        levlComplete++;
    }

    void OnDisable()
    {
        TrapScript.damage -= TrapScript_Damage;
        ThingsScript.collect -= ThingsScript_Collect;
        BulletScript.damege -= TrapScript_Damage;

    }
}
