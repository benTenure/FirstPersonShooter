using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Gun")]
public class Gun : ScriptableObject
{
    public float damage;
    public float fire_rate;
    public float max_range;
    public int ammo;
    public AudioClip shoot_sound;
    public ParticleSystem muzzle_fx;
}
