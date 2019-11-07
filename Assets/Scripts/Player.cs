using System.Collections;
using UnityEngine;

[AddComponentMenu("MyGame/Player")]
public class Player : MonoBehaviour
{
    public float m_speed = 1;
    public float m_life = 3;

    Transform m_transform;

    public AudioClip m_shootClip;
    protected AudioSource m_audio;
    public Transform m_explosionFX;

    public Transform m_rocket;
    float m_rocketTimer = 0;

    void Start()
    {
        m_transform = this.transform;
        m_audio = this.GetComponent<AudioSource>();
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
            {
                Instantiate(m_rocket, m_transform.position, m_transform.rotation);
                m_audio.PlayOneShot(m_shootClip);
            }

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PlayerRocket")
        {
            m_life -= 1;
            GameManager.Instance.ChangeLife((int)m_life);
            if (m_life <= 0)
            {
                Instantiate(m_explosionFX, m_transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }

        }
    }
}
