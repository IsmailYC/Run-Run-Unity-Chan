using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject.transform.parent.gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject.transform.parent.gameObject);
    }
}
