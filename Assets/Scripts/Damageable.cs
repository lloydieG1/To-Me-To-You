using UnityEngine;

public interface Damageable {
    public float Health { set; get; }
    public void OnHit(float damage, Vector2 knockback);

}
