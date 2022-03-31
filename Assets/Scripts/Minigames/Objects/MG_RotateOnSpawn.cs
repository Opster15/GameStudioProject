using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP
{
    public class MG_RotateOnSpawn : MonoBehaviour
    {
        private void Start()
        {
            int random = Random.Range(0, 360);

            transform.rotation = Quaternion.Euler(0, 0, random);
        }
    }
}
