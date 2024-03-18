using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputTestElectricBoogaloo : MonoBehaviour
{

    UnityEngine.XR.InputDevice XRDevice;

    InputDeviceRole test; 


    // Start is called before the first frame update
    void Start()
    {
        InputDeviceCharacteristics leftTrackedControllerFilter = InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice | InputDeviceCharacteristics.Left, leftHandedControllers;

        List<InputDevice> foundControllers = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(leftTrackedControllerFilter, foundControllers);

         test = InputDeviceRole.LeftHanded;

        
    }

    // Update is called once per frame
    void Update()
    {
     
        //if(XRDevice)


    }
}
