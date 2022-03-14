using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG_Moving_Plat : MonoBehaviour
{
    public Transform m_startPos, m_endPos, m_origParent, m_startingPos;
    public float m_speed, m_randomStart;
    Vector3 m_nextPos, v;

    private void Start()
    {
        m_nextPos = m_startPos.position;

        v = m_startPos.position - m_endPos.position;

        //m_startingPos = m_startPos + Random.value * v;

        m_speed = Random.Range(1f, 3f);
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

        transform.position = Vector3.MoveTowards(transform.position, m_nextPos, m_speed * Time.deltaTime);
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
