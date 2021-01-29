using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzlePanel : MonoBehaviour
{
    public Animator anim;
    [SerializeField] List<SO_Stage> stages;
    [SerializeField] SpriteRenderer gateQsprite;
    [SerializeField] SpriteRenderer gateWsprite;
    [SerializeField] SpriteRenderer gateEsprite;

    public void ShowGate() => anim.SetTrigger("ShowGate");
    public void HideGate() => anim.SetTrigger("HideGate");

    public int GetAndSetWinner(int winningIndex, int stageNumber)
    {
        Debug.Log("GetSetWinnerRan");
        int placeA;
        int placeB;
        if(winningIndex > 1)
        {
            placeA = 1;
            placeB = 0;
            gateQsprite.sprite = stages[stageNumber - 1].sprites[winningIndex];
            gateWsprite.sprite = stages[stageNumber - 1].sprites[placeA];
            gateEsprite.sprite = stages[stageNumber - 1].sprites[placeB];
            return 1;
        }
        else if (winningIndex == 1)
        {
            placeA = 0;
            placeB = 2;
            gateWsprite.sprite = stages[stageNumber - 1].sprites[winningIndex];
            gateQsprite.sprite = stages[stageNumber - 1].sprites[placeA];
            gateEsprite.sprite = stages[stageNumber - 1].sprites[placeB];
            return 2;
        }
        else
        {
            placeA = 1;
            placeB = 2;
            gateEsprite.sprite = stages[stageNumber - 1].sprites[winningIndex];
            gateQsprite.sprite = stages[stageNumber - 1].sprites[placeB];
            gateWsprite.sprite = stages[stageNumber - 1].sprites[placeA];
            return 3;
        }  
    }

}
