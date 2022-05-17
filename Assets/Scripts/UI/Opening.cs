using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace GSP
{
    public class Opening : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Invoke("Menu", 3f);
        }


        void Menu()
        {
            SceneManager.LoadScene(1);
        }
    }
}
