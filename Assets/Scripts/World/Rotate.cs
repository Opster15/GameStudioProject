using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP
{
    public class Rotate : MonoBehaviour
    {
        public float speed;

        public void Update()
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }
}
