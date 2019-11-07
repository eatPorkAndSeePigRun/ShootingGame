using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/Enemy")]
public class Enemy : MonoBehaviour
{
    public float m_speed = 1;
    public float m_life = 10;
    protected float m_rotSpeed = 30;
    public int m_point = 10;

    internal Renderer m_renderer;
    internal bool m_isActiv = false;

    public Transform m_explosionFX;

    void Start()
    {
        m_renderer = this.GetComponent<Renderer>();
    }


    void Update()
    {
        UpdateMove();
        if (m_isActiv && !this.m_renderer.isVisible)
            Destroy(this.gameObject);
    }

    protected virtual void UpdateMove()
    {
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime));
    }

    private void OnBecameVisible()
    {
        m_isActiv = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerRocket")
        {
            Rocket rocket = other.GetComponent<Rocket>();
            if (rocket != null)
            {
                m_life -= rocket.m_power;
                if (m_life <= 0)
                {
                    GameManager.Instance.AddScore(m_point);
                    Instantiate(m_explosionFX, this.transform.position, Quaternion.identity);
                    Destroy(this.gameObject);
                }
            }
        }
        else if (other.tag == "Player")
        {
            m_life = 0;
            Destroy(this.gameObject);
        }
    }
}
