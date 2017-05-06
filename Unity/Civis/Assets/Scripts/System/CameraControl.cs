using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float ZoomSpeed;
    public float PanSpeed = 3;
    public float MaxRotSpeed = 1;
    public GameObject Target;

    public Vector3 SnapOffset = new Vector3(3, 3, 3);

    private Camera _cam;
    private Vector3 _lastDrag;
    private int _screenWidth, _screenHeight;

    private bool _isZooming;

    void Start()
    {
        _cam = Camera.main;
        _isZooming = false;
        _lastDrag = Vector3.zero;
        _screenHeight = Display.main.systemHeight;
        _screenWidth = Display.main.renderingWidth;
    }

    public void ZoomTo(GameObject gm)
    {
        Target = gm;
        ZoomSpeed = Vector3.Distance(transform.position, Target.transform.position) * Time.deltaTime;
        _cam.transform.LookAt(Target.transform);
    }

    public void SnapTo(GameObject gm)
    {
        var tPos = gm.transform.position;
        _cam.transform.position = new Vector3
            (
            tPos.x+SnapOffset.x,
            tPos.y+SnapOffset.y,
            tPos.z+SnapOffset.z
            );

        _cam.transform.LookAt(gm.transform);
    }

    void Update()
    {
        if (_isZooming)
        {
            _cam.transform.position = Vector3.MoveTowards(
                _cam.transform.position, 
                Target.transform.position, 
                ZoomSpeed);

            if (Vector3.Distance(_cam.transform.position, Target.transform.position) <= SnapOffset.magnitude)
                _isZooming = false;
            return;
        }

        //movement vectors
        float x=0, z=0, y=0, rx=0, ry=0;

        if (Input.GetKey(KeyCode.W))
            z-=PanSpeed;
        if (Input.GetKey(KeyCode.S))
            z+=PanSpeed;
        if (Input.GetKey(KeyCode.D))
            x-=PanSpeed;
        if (Input.GetKey(KeyCode.A))
            x+=PanSpeed;
        y-= Input.GetAxis("Mouse ScrollWheel");

        if (Input.GetMouseButton(2))
        {
            if (_lastDrag != Vector3.zero)
            {
                var dr = Vector3.Distance(_lastDrag, Input.mousePosition);

                ry = (Input.mousePosition.x - (_screenWidth / 2f)) * MaxRotSpeed;
                rx = (Input.mousePosition.y - (_screenHeight / 2f)) * MaxRotSpeed * -1;
            }

            _lastDrag = Input.mousePosition;

        }
        else
        {
            _lastDrag = Vector3.zero;
        }

        var delta = new Vector3(x, y, z);

        transform.Translate(delta, Space.Self);
        transform.Rotate(rx, ry, 0);
        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x, 
            transform.rotation.eulerAngles.y, 
            0);


    }

}
