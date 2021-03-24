using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMousePos : MonoBehaviour
{
    public Camera _camera;
    RaycastHit _hit;
    Ray _ray;
    Vector3 _mousePos, _smoothPoint;
    public float _radius, _softness, _smoothSpeed, _scaleFactor;
    // Start is called before the first frame update
    void Start()
    {
        //_camera = GetComponent<Camera>();
        _camera = GameObject.FindWithTag("playercamera").GetComponent<Camera>();
        _radius = Mathf.Clamp(_radius, 0, 100);
        _softness = Mathf.Clamp(_softness, 0, 100);
        Shader.SetGlobalFloat("GLOBALmask_Radius", _radius);
        Shader.SetGlobalFloat("GLOBALmask_Softness", _softness);

    }

    // Update is called once per frame
    void Update()
    {
        
        
        _mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        _ray = _camera.ScreenPointToRay(_mousePos);

        if (Physics.Raycast(_ray, out _hit))
        {
            _smoothPoint = Vector3.MoveTowards(_smoothPoint, _hit.point, _smoothSpeed * Time.deltaTime);
            Vector4 pos = new Vector4(_smoothPoint.x, _smoothPoint.y, _smoothPoint.z, 0);
            Shader.SetGlobalVector("GLOBALmask_Position", pos);
        }
        
    }
}