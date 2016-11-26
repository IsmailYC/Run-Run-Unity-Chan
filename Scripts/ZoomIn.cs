using UnityEngine;
using System.Collections;

public class ZoomIn : MonoBehaviour {
    public Transform target;
    public float speed;

    Vector3 dV;

    void Start()
    {
        dV = target.position-transform.position;
        dV.Normalize();
    }

	// Update is called once per frame
	void Update () {
        if(!GameManager.instance.isAlive)
        {
            if(Vector3.Distance(transform.position, target.position)>2.5)
            {
                transform.LookAt(target.position);
                transform.position += speed * Time.deltaTime * dV;
            }
        }
	}
}
