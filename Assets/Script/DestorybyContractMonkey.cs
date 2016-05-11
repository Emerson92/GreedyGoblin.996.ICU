using UnityEngine;
using System.Collections;

public class DestorybyContractMonkey : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("wall")) {
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}
