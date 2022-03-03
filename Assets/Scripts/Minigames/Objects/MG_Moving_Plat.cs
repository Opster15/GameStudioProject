using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_Moving_Plat : MonoBehaviour
{
    public Transform m_startPos, m_endPos,m_origParent;
    public float speed;
    Vector3 m_nextPos;

    private void Start()
    {
        transform.position = m_startPos.position;
    }

    public void Update()
    {
        if(transform.position == m_startPos.position)
        {
            m_nextPos = m_endPos.position;
        }
        else if (transform.position == m_endPos.position)
        {
            m_nextPos = m_startPos.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, m_nextPos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(m_origParent);
        }
    }


}
