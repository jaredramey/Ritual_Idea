using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float MoveSpeed;

    private float MoveVelocity;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        MoveVelocity = 0.0f;

        switch(Input)
        {

        }
    }
}
