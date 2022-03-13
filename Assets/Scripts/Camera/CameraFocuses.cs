using System.Collections.Generic;
using UnityEngine;
namespace GSP.Camera
{
    public class CameraFocuses : MonoBehaviour
    {
        /// <summary>
        /// All possible focus states' camera positions.
        /// </summary>
        private List<Transform> m_cameraPositions;
        
        /// <summary>
        /// All possible focus states' focus points.
        /// </summary>
        private List<Transform> m_focusPoints;

        /// <summary>
        /// The order of camera positions in the object hierarchy.
        /// </summary>
        [SerializeField] private int m_cameraPositionOrder;
        
        /// <summary>
        /// The order of focus points in the object hierarchy.
        /// </summary>
        [SerializeField] private int m_focusPointOrder;

        private void Awake()
        {
            m_cameraPositions = new List<Transform>();
            m_focusPoints = new List<Transform>();
            
            for (var i = 0; i < transform.childCount; i++)
            {
                m_cameraPositions.Add(transform.GetChild(i).GetChild(m_cameraPositionOrder));
                m_focusPoints.Add(transform.GetChild(i).GetChild(m_focusPointOrder));
            }
        }

        /// <summary>
        /// Get a focus state's camera position.
        /// </summary>
        /// <param name="_index">The focus state to get the position of.</param>
        /// <returns>The focus state's camera position</returns>
        public Transform GetCameraPosition(int _index)
            => m_cameraPositions[_index];

        /// <summary>
        /// Get a focus state's focus point.
        /// </summary>
        /// <param name="_index">The focus state to get the focus point of.</param>
        /// <returns>The focus state's focus point.</returns>
        public Transform GetFocusPoint(int _index)
            => m_focusPoints[_index];
    }
}
