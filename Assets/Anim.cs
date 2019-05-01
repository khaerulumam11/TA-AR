using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour {

    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void animWalk() {
        animator.Play("walk",-1,0f);
    }

    public void animjump() {
        animator.Play("jump", -1, 0f);
    }

    public void animhit() {
        animator.Play("hit", -1, 0f);
    }

 

}
