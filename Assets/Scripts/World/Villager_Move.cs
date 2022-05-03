using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GSP
{
    public class Villager_Move : MonoBehaviour
    {
        public Transform[] positions;


        public int counter;
        // Start is called before the first frame update
        void Start()
        {
            transform.position = positions[counter].position;
            counter = 1;
        }


        private void Update()
        {
            if(transform.position == positions[counter].position)
            {
                counter++;
                if(counter == positions.Length)
                {
                    counter = 0;
                }
            }

            transform.LookAt(positions[counter].position);
            transform.position = Vector3.MoveTowards(transform.position, positions[counter].position, 0.002f);
        }
    }
}
