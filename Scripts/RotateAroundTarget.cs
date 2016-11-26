using UnityEngine;
using System.Collections;

public class RotateAroundTarget : MonoBehaviour {
    public Transform target;
    public float mouseSensetivity;
    public float zoomFactor;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(1))
        {
                transform.RotateAround(target.transform.position, 
                    target.up, 
                    Time.deltaTime*mouseSensetivity * Input.GetAxis("Mouse X"));
                transform.RotateAround(target.transform.position, 
                    target.right, 
                    Time.deltaTime*mouseSensetivity * Input.GetAxis("Mouse Y"));
        }
        else
        {
            Vector3 displacement = target.position - transform.position;
            if (displacement.magnitude<4 && Input.GetAxis("Mouse ScrollWheel")>0)
                transform.Translate(Input.GetAxis("Mouse ScrollWheel")*displacement.normalized * zoomFactor * Time.deltaTime);
            else if (displacement.magnitude > 1 && Input.GetAxis("Mouse ScrollWheel") < 0)
                transform.Translate(Input.GetAxis("Mouse ScrollWheel") * displacement.normalized * zoomFactor * Time.deltaTime);
        }
        transform.LookAt(target);
	}
}
