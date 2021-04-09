using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class entity : MonoBehaviour
{
    // Start is called before the first frame update

    public int damageMultiplier;
    public int deathTimer;
    [SerializeField]
    private int _health;
    public int health {
        get { return _health; }
        set {
            _health = value;
            if(_health <= 0) 
            {
                _health = 0; // force zero as min value
                this.Die();
            }
        }
    }
    private bool markedForDeath;


    public void Die() {
        Die(deathTimer);
    }
    public void Die(int timer) {
        if (!markedForDeath) {
            Debug.Log("Requested " + this.name + " death in " + timer + " seconds");
            markedForDeath = true;
        }
        
        Destroy(this.gameObject, timer);
    }

    public void TakeDamage(int damage) {
        Debug.Log(this.name + " took "+ damage + " damage.");
        health -= damage;
    }
    protected void Start()
    {
        markedForDeath = false;
    }

    // Update is called once per frame
    protected void Update()
    {
    }
}
