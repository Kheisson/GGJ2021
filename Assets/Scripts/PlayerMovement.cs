using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 5f;
    [SerializeField] ScoreCount _scoreCountUI;
    Rigidbody _rigidbody;
    int currentScore = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            _rigidbody.AddForce(Vector3.up * _movementSpeed, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            _rigidbody.mass += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Collectable")
        {
            currentScore += 300;
            Destroy(other.gameObject);
        }

    }
    public void SetKinematic(bool isKinematic) => _rigidbody.isKinematic = isKinematic;

    public int CurrentScore()
    {
        _scoreCountUI.UpdateScore(currentScore.ToString());
        return currentScore;
    }
}
