using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVCTest : MonoBehaviour
{
    void Start()
    {
        MainController.Init("UI/MainPanel", "Canvas");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MainController.ShowView();
        }
    }
}
