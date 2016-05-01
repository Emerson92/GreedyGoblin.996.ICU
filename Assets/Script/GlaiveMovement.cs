using UnityEngine;
using System.Collections;

public class GlaiveMovement : MonoBehaviour
{
    public bool isMoving = false;

    public Vector3 moveDirection;
    private Transform _transform;

    // Use this for initialization
    void Start()
    {
        _transform = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FixedUpdate()
    {
        if (isMoving) {
            _transform.position += moveDirection;
        }
    }
}
