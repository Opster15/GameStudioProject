using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP.Camera
{
    public class MinigameAttachCamera : MonoBehaviour
    {
        private void Awake()
        {
            var minigameCameraObject = GameObject.FindGameObjectWithTag("MG_Cam");
            transform.position = minigameCameraObject.transform.position + minigameCameraObject.transform.forward;
            transform.LookAt(minigameCameraObject.transform);
            transform.SetParent(minigameCameraObject.transform);
        }
    }
}
