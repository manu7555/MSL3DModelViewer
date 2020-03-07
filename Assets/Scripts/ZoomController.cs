using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoomController : MonoBehaviour
{

    public Slider zoomSlider;
    // Start is called before the first frame update
    void Start()
    {
        zoomSlider = GetComponent<Slider>();
        zoomSlider.onValueChanged.AddListener(delegate
        {
            ChangeZoomValue(zoomSlider);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeZoomValue(Slider zoom)
    {
        Vector3 newPos = Camera.main.transform.position;
        newPos.z = zoom.value;
        Camera.main.transform.SetPositionAndRotation(newPos, Camera.main.transform.rotation);
    }
}
