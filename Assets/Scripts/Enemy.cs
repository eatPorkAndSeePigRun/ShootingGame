using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyGame/Enemy")]
public class Enemy : MonoBehaviour
{
    public float m_speed = 1;
    public int m_life = 10;
    protected float m_rotSpeed = 30;


    void Update()
    {
        UpdateMove();
    }

    protected virtual void UpdateMove()
    {
        float rx = Mathf.Sin(Time.time) * Time.deltaTime;
        transform.Translate(new Vector3(rx, 0, -m_speed * Time.deltaTime));
    }
}
