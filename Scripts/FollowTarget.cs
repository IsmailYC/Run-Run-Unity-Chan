using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {
    public bool useInitial, xAxis, yAxis, zAxis;
    public Transform offset;
    public Transform target;

    Vector3 iniOffset;
	// Use this for initialization
	void Start () {
        if (useInitial)
            iniOffset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(GameManager.instance.isAlive)
        {
            if (useInitial)
            {
                if (zAxis)
                {
                    Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z + iniOffset.z);
                    transform.position = newPosition;
                }
                if (yAxis)
                {
                    Vector3 newPosition = new Vector3(transform.position.x, target.position.y + iniOffset.y, transform.position.z);
                    transform.position = newPosition;
                }
                if (xAxis)
                {
                    Vector3 newPosition = new Vector3(target.position.x + iniOffset.x, transform.position.y, transform.position.z);
                    transform.position = newPosition;
                }
            }
            else
            {
                if (zAxis)
                {
                    Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, target.position.z + offset.position.z);
                    transform.position = newPosition;
                }
                if (yAxis)
                {
                    Vector3 newPosition = new Vector3(transform.position.x, target.position.y + offset.position.y, transform.position.z);
                    transform.position = newPosition;
                }
                if (xAxis)
                {
                    Vector3 newPosition = new Vector3(target.position.x + offset.position.x, transform.position.y, transform.position.z);
                    transform.position = newPosition;
                }
            }
        }
    }
}
