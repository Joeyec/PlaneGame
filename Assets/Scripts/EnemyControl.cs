using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {
    public float speed = 2f;
    public GameObject ExplosionGO;
    GameObject scoreUITextGO;
	// Use this for initialization
	void Start () {
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        transform.position = position;
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }

	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            scoreUITextGO.GetComponent<GameScore>().Score += 100;
            Destroy(gameObject);
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = Instantiate(ExplosionGO);
        explosion.transform.position = transform.position;
    }
}
