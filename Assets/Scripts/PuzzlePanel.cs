using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePanel : MonoBehaviour
{
    Vector3 _xPositionShowPos = new Vector3(1,0,0);
    Vector3 _xPositionHidePos = new Vector3(7,0,0);
    [SerializeField] bool _isShown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(MoveToPosition(_isShown));
    }

    IEnumerator MoveToPosition(bool isShown)
    {
        if (isShown == false)
            this.transform.position = Vector3.Lerp(_xPositionHidePos, _xPositionShowPos, 0.0001f * Time.deltaTime);
        else
            this.transform.position = Vector3.Lerp(_xPositionShowPos, _xPositionHidePos, 0.0001f * Time.deltaTime);
        _isShown = !isShown;
        yield return new WaitForSeconds(1f);
    }
}
