using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Camera))]
public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private List<Gun> player_guns;
    [SerializeField] private Gun active_gun;
    [SerializeField] private Camera player_camera;
    [SerializeField] private ParticleSystem muzzle_fx;

    private float time_to_next_shot = 0f;
    
    // Start is called before the first frame update
    private void Start()
    {
        // player_guns = new List<Gun>();
        active_gun = player_guns[0];
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time >= time_to_next_shot && Input.GetButton("Fire1"))
        {
            time_to_next_shot = Time.time + 1f / active_gun.fire_rate;
            Shoot();
        }
    }

    private void Shoot()
    {
        muzzle_fx.Play();
        player_camera.GetComponent<AudioSource>()?.PlayOneShot(active_gun.shoot_sound);

        RaycastHit hit;

        if (Physics.Raycast(player_camera.transform.position, player_camera.transform.forward, out hit, active_gun.max_range))
        {
            print($"We've hit the {hit.transform.name}");
            hit.transform.GetComponent<DestructibleObject>()?.TakeDamage(active_gun.damage);
        }
    }
}
