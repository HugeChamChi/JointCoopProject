using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrayCatBulletController : MonoBehaviour
{
    private ObjectPool _bulletPool;
    [SerializeField] private PooledObject _bullet;
    private float _bulletSpd = 8f;

    private void Awake() => Init();

    private void Init()
    {
        _bulletPool = new ObjectPool(transform, _bullet, 8);
    }

    public void ShootFire(Vector2 shootDir, int damage)
    {
        StrayCatBullet fire = GetBullet();
        fire._damage = damage;
        fire.transform.position = transform.position;
        // �߻� ���⿡ ���� ȭ���� roatation ����
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        fire.transform.rotation = Quaternion.Euler(0, 0, angle);

        fire.Shoot(shootDir, _bulletSpd, damage);
    }

    public StrayCatBullet GetBullet()
    {
        PooledObject po = _bulletPool.PopPool();
        return po as StrayCatBullet;
    }
}
