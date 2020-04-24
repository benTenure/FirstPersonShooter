using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movement_speed;

    private CharacterController player_controller;
    private Transform player_transform;


    // Start is called before the first frame update
    private void Start()
    {
        player_transform = GetComponent<Transform>();
        player_controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Movement controls
        var x_axis = Input.GetAxisRaw("Horizontal");
        var z_axis = Input.GetAxisRaw("Vertical");

        var movement = (player_transform.right * x_axis) + (player_transform.forward * z_axis);

        player_controller.Move(movement * (movement_speed * Time.deltaTime));
    }
}
