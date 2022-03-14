using UnityEngine;
namespace GSP.UI
{
    public class Billboard : MonoBehaviour
    {
        //TODO: Have it not get fucked up when there are multiple cameras
        private UnityEngine.Camera m_camera;
        
        private void Awake()
        {
            m_camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UnityEngine.Camera>();
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + m_camera.transform.forward);
        }
    }
}
