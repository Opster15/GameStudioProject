using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP
{
    public class LoadingAnimRandom : MonoBehaviour
    {
        private Animator anim;
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();

            anim.SetInteger("Random", Random.Range(0, 2));
        }
    }
}
