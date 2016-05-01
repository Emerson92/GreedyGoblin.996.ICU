using UnityEngine;
using System.Collections;

public class DestoryGlaive : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("glaive")) {
            Destroy(other.gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {

    }
}
