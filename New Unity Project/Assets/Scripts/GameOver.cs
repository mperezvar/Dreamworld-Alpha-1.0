using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameOver : MonoBehaviour
{
    public Button[] botones;
    public string[] OPText;
    public TextMeshProUGUI texto;
    private string g = "GAMEOVER";
    SpriteRenderer spriter;
    public Sprite s1,s2,s3,s4,s5,s6,s7,s8,s9;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<botones.Length; i++)
        {
            botones[i].interactable = false;
            botones[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
        }
        spriter = GetComponent<SpriteRenderer>();
        Sprite[] sprites = {s1,s2,s3,s4,s5,s6,s7,s8,s9};
        StartCoroutine(Animacion(sprites));
    }
    // Update is called once per frame
    IEnumerator Animacion(Sprite[] sprites)
    {
        string s = "";
        for(int i=0; i<sprites.Length; i++)
        {
            spriter.sprite = sprites[i];
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.2f);
        for (int i=0; i<g.Length; i++)
        {
            s = s + g[i];
            texto.text = s;
            yield return new WaitForSeconds(0.07f);
        }
        for(int i=0; i<botones.Length; i++)
        {
            botones[i].interactable = true;
            botones[i].GetComponentInChildren<TextMeshProUGUI>().text = OPText[i];
        }
    }
}
