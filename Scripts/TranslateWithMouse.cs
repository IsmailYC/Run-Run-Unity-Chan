using UnityEngine;
using System.Collections;

public class TranslateWithMouse : MonoBehaviour {
    public float mouseSensetivity;
	
    void Awake()
    {
        transform.position = PlayerPrefManager.GetCameraPosition();
    }

	// Update is called once per frame
	void Update () {
        if(MenuManager.instance.state == MenuManager.State.Position && Input.GetMouseButton(0))
        {
            transform.Translate(-mouseSensetivity * Time.deltaTime * Input.GetAxis("Mouse X"),
                -mouseSensetivity * Time.deltaTime * Input.GetAxis("Mouse Y"), 0);
        }
	}

    void OnDisable()
    {
        PlayerPrefManager.SetCameraPosition(transform.position);
    }
}
