using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewer_rotator : MonoBehaviour
{
    [SerializeField] KeyCode rotateKey = KeyCode.Mouse0;
    [SerializeField] float rotSpeed = 500f;
    public Viewer_object obj;

    private void Start() {
        if (obj == null) obj = FindObjectOfType<Viewer_object>();
    }

    // Update is called once per frame
    void Update()
    {
        if (obj == null) obj = ItemViewer.instance.viewedItem.GetComponent<Viewer_object>();

        if (obj.isRotateable && Input.GetKey(rotateKey)) {
            var x = -Input.GetAxis("Mouse X");
            var y = Input.GetAxis("Mouse Y");

            var newRot = new Vector3(x * rotSpeed * Time.deltaTime, y * rotSpeed * Time.deltaTime, 0);
            obj.transform.Rotate(Vector3.up, x * rotSpeed * Time.deltaTime, Space.World);
            obj.transform.Rotate(Vector3.right, y * rotSpeed * Time.deltaTime, Space.World);
        } else if(obj.isRotateable) {
            var h = -Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            var newRot = new Vector3(h * rotSpeed * Time.deltaTime, v * rotSpeed * Time.deltaTime, 0);
            obj.transform.Rotate(Vector3.up, h * rotSpeed * Time.deltaTime, Space.World);
            obj.transform.Rotate(Vector3.right, v * rotSpeed * Time.deltaTime, Space.World);
        }
    }
}
