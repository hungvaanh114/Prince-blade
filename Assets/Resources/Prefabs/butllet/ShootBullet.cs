using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab của viên đạn
    public Transform firePoint; // Vị trí mà viên đạn sẽ được bắn ra
    public float bulletSpeed = 10f;
    public GameObject knight;
    void Shoot()
    {
        Vector2 direction = (knight.transform.position - firePoint.position).normalized;

        // Tạo viên đạn tại vị trí firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        // Lấy Rigidbody2D của viên đạn và gán vận tốc cho nó
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = direction * bulletSpeed;

        // Nếu bạn muốn viên đạn quay theo hướng của nó
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
