using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePanel : MonoBehaviour
{
    Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            _anim.SetTrigger("ShowGate");
        if (Input.GetKeyDown(KeyCode.V))
            _anim.SetTrigger("HideGate");
            
    }

}
