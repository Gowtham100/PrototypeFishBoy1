using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

    //Detection Distance
    private float distance;
    private float moveDistance; //distance from player to activate
    private float attackDistance;

    private int speed;
    private int health;
    private GameObject target;
    private Collider2D collider;

	// Use this for initialization
	void Start () {
        target = GameObject.Find("Player");
        collider = GetComponent<Collider2D>();
        if (!collider.isTrigger)  //SETS TRIGGER ON FOR COLLIDER
            collider.isTrigger = true;
	}

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(target.transform.position, transform.position); //transform is this
        if (distance<attackDistance)
            Attack();
        if (distance < moveDistance)
            Move();
        else { Idle(); }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Hit();
    }

    protected void Hit()
    {
        health--;
        if (health <= 0)
            Death();
    }

    protected abstract void Death();
    protected abstract void Move();
    protected abstract void Attack();
    protected abstract void Idle();
   
}
