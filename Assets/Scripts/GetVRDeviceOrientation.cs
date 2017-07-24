using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

// Attach this script to a vive controller to get the servo to move with the controller

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class GetVRDeviceOrientation : MonoBehaviour
{
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;

    public String host = "192.168.1.208";
    public Int32 port = 5005;

    IPEndPoint remoteEndPoint;
    UdpClient client;

    // Use this for initialization
    void Start()
    {
        client = new UdpClient(host, port);
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
        int val = (int)device.transform.rot.eulerAngles.y * 2;
        if (val < 50)
        {
            val = 50;
        }

        if (val > 550)
        {
            val = 550;
        }
        val = 550 - val;
        string data = (val).ToString() + "\n";
        //Debug.Log(data);
        byte[] text = Encoding.UTF8.GetBytes(data);
        client.Send(text, text.Length);
    }


    void OnGUI()
    {

        string shootBtnDisplay = "";
        if (device != null)
        {
            shootBtnDisplay =
                (int)device.transform.rot.eulerAngles.x + " " +
                (int)device.transform.rot.eulerAngles.y + " " +
                (int)device.transform.rot.eulerAngles.z;
        }

        GUI.Label(new Rect(10, 10 + 1 * 50, 500, 100), shootBtnDisplay);
    }
}