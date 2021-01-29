using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePanel : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ShowGate() => anim.SetTrigger("ShowGate");
    public void HideGate() => anim.SetTrigger("HideGate");

    public void SetNewSetOfPuzzles()
    {
        Image[] spritesInChildren = GetComponentsInChildren<Image>();
        foreach (Image sprite in spritesInChildren)
            Debug.Log(sprite.name);
    }

}
