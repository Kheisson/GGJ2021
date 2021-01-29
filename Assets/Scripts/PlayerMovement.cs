using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 5f;
    Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            _rigidbody.AddForce(Vector3.up * _movementSpeed, ForceMode.Force);
        if (Time.realtimeSinceStartup >= 3f)
            _rigidbody.useGravity = true;  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
            Destroy(other.gameObject);
        if (other.gameObject.tag == "Collectable")
            Destroy(other.gameObject);
    }
}
