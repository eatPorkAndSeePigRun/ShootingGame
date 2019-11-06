using System.Collections;
using UnityEngine;

[AddComponentMenu("MyGame/Player")]
public class Player : MonoBehaviour
{
    public float m_speed = 1;

    Transform m_transform;

    public Transform m_rocket;
    float m_rocketTimer = 0;

    void Start()
    {
        m_transform = this.transform;
    }

    void Update()
    {
        float movev = 0;
        float moveh = 0;

        if (Input.GetKey(KeyCode.UpArrow))
            movev += m_speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            movev -= m_speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
            moveh -= m_speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            moveh += m_speed * Time.deltaTime;

        m_transform.Translate(new Vector3(moveh, 0, movev));


        m_rocketTimer -= Time.deltaTime;
        if (m_rocketTimer <= 0)
        {
            m_rocketTimer = 0.1f;
            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
                Instantiate(m_rocket, m_transform.position, m_transform.rotation);
        }

    }
}
