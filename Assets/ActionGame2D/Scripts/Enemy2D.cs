using UnityEngine;
using System.Collections;
public class Enemy2D : MonoBehaviour {
    public GameObject bloodPrefab;
    public GameObject deathPrefab;
    Animator animator;
    public int life = 3;
    Player2D player;
    Transform tf;
    
    void Start()
    {
        tf = transform;
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player2D").GetComponent<Player2D>();
        InitActor();
    }

    void InitActor()
    {
        tf.position = new Vector3(12f, 0.9f, 0f);
        life = 3;
        GotoState("Idle");
    }
    
    void GotoState(string some)
    {
        //animator.SetTrigger(some);
        animator.Play(some);
    }
    
    void Damage()
    {
        if (life < 1) return;
        if (bloodPrefab) Instantiate(bloodPrefab, transform.position, Quaternion.identity);
        GotoState("Damage");
        life--;
        if (life < 1)
        {
            GotoState("Death");
        }
    }
    
    void OnDeath()
    {
        if (deathPrefab) Instantiate(deathPrefab, transform.position, Quaternion.identity);
    }
    
    void Update()
    {
        if (animator == null) return;

        float dist = player.speed * Time.deltaTime * 4f;
        tf.position += new Vector3(dist * -1, 0, 0);
        if (tf.position.x < -12f) InitActor();
    }

}
