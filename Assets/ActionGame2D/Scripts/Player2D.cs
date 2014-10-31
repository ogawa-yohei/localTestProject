using UnityEngine;
using System.Collections;
public class Player2D : MonoBehaviour {
    public GameObject hitPrefab;
    Animator animator;
    GameObject enemy;
    public float pos = 0f;
    public float speed = 0f;
    int direction = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        enemy = GameObject.Find("Enemy2D");
	}

    void OnDeal()
    {
        if (hitPrefab) Instantiate(hitPrefab, transform.position+Vector3.right*2.5f-Vector3.up*0.5f, Quaternion.identity);
        float dist = enemy.transform.position.x - transform.position.x;
        if (dist > 5f || dist < 1) return;
        enemy.SendMessage("Damage", SendMessageOptions.DontRequireReceiver);
    }

    void GotoState(string some)
    {
        //animator.SetTrigger(some);
        animator.Play(some);
    }

    void Attack()
    {
        GotoState("Attack");
    }

    void Attack2()
    {
        GotoState("Attack2");
    }

    void Attack3()
    {
        GotoState("Attack3");
    }

    void Jump()
    {
        GotoState("Jump");
    }

    void Run()
    {
        Debug.Log("Run");
        direction = 1;
    }
    void Idle()
    {
        Debug.Log("Idle");
        direction = 0;
    }

    /*
    void OnGUI()
    {
        Event e = Event.current;
        Rect area = new Rect(10, 0, 90 * Screen.width / 600f, 100 * Screen.width / 800f);
        int gap = 5;
        float gridHeight = area.height + gap;

        GUI.BeginGroup(new Rect(Screen.width - area.width - gap, 0, area.width, Screen.height));
        if (GUI.Button(new Rect(0, Screen.height - gridHeight * 1, area.width, area.height), "Attack1")) GotoState("Attack");
        if (GUI.Button(new Rect(0, Screen.height - gridHeight * 2, area.width, area.height), "Attack2")) GotoState("Attack2");
        if (GUI.Button(new Rect(0, Screen.height - gridHeight * 3, area.width, area.height), "Attack3")) GotoState("Attack3");
        GUI.EndGroup();

        Rect btArea = new Rect(gap, Screen.height - gridHeight * 1, area.width, area.height);
        if (btArea.Contains(e.mousePosition) && e.isMouse)
        {
            if (e.type == EventType.MouseDown) direction = 1;
            if (e.type == EventType.MouseUp) direction = 0;
        }
        GUI.BeginGroup(new Rect(gap, 0, area.width, Screen.height));
        GUI.Button(new Rect(0, Screen.height - gridHeight * 1, area.width, area.height), "Run");
        if (GUI.Button(new Rect(0, Screen.height - gridHeight * 2, area.width, area.height), "Jump")) GotoState("Jump");
        GUI.EndGroup();
    }
     */

    void Stop()
    {
        speed = 0f;
        animator.SetFloat("Speed", speed);
    }

    void Move(float delta)
    {
        speed = Mathf.Clamp(speed + delta, -1f, 1f);
        animator.SetFloat("Speed", speed);
    }

    void UpdateMovement()
    {
        if (direction != 0) Move(direction * 0.01f);
        else Stop();
        pos += speed * Time.deltaTime;
    }
    
    void Update()
    {
        if (animator == null) return;
        if (Input.GetKey(KeyCode.Escape)) Application.Quit();
        if (Input.GetKeyDown(KeyCode.Q)) GotoState("Attack");
        if (Input.GetKeyDown(KeyCode.W)) GotoState("Attack2");
        if (Input.GetKeyDown(KeyCode.E)) GotoState("Attack3");
        if (Input.GetKeyDown(KeyCode.Space)) GotoState("Jump");
        if (Input.GetKeyDown(KeyCode.RightArrow)) direction = 1;
        if (Input.GetKeyUp(KeyCode.RightArrow)) direction = 0;
        UpdateMovement();
    }
}
