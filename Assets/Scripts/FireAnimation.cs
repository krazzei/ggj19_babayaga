using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    public GameObject fire1;

    public GameObject fire2;

    private bool _isOneActive;
    
    // Update is called once per frame
    private void Update()
    {
        if (Time.frameCount % 10 == 0)
        {
            _isOneActive = !_isOneActive;
            
            fire1.SetActive(_isOneActive);
            fire2.SetActive(!_isOneActive);
        }
    }
}
