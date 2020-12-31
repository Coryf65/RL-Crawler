using Cory.RL_Crawler.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Weapons
{
    public class Weapon : MonoBehaviour
    {

        // creating a bullet and giving it velocity
        [SerializeField] protected GameObject muzzlePoint;
        [SerializeField] protected int ammo = 10;
        [SerializeField] protected WeaponData_SO weaponData;

        public int Ammo 
        { 
            get => ammo;
            set 
            {
                ammo = Mathf.Clamp(value, 0, weaponData.AmmoCapacity);            
            } 
        }

        public bool AmmoFull { get => Ammo >= weaponData.AmmoCapacity; }

        protected bool isShooting = false;

        [SerializeField] protected bool reloadCoroutine = false;
        [field: SerializeField] public UnityEvent OnShoot { get; set; }
        [field: SerializeField] public UnityEvent OnShootNoAmmo { get; set; }

        private void Start()
        {
            // at the start the weapon will have max ammo
            Ammo = weaponData.AmmoCapacity;
        }

        public void TryToShoot()
        {
            isShooting = true;
        }

        public void StopShooting()
        {
            isShooting = false;
        }

        public void Reload(int ammo)
        {
            Ammo += ammo;
        }

        private void Update()
        {
            UseWeapon();
        }

        private void UseWeapon()
        {
            if (isShooting && reloadCoroutine == false)
            {
                if (Ammo > 0)
                {
                    // bullets to shoot
                    Ammo--;
                    OnShoot?.Invoke();
                    for (int i = 0; i < weaponData.GetBulletCountToSpawn(); i++)
                    {
                        ShootBullets();
                    }

                } else
                {
                    isShooting = false;
                    OnShootNoAmmo?.Invoke();
                    return;
                }
                FinishShooting();
            }
        }

        private void FinishShooting()
        {
            StartCoroutine(DelayNextShotCoroutine());

            if (weaponData.AutomaticFire == false)
            {
                // not auto so reclick shoot
                isShooting = false;
            }
        }

        protected IEnumerator DelayNextShotCoroutine()
        {
            reloadCoroutine = true;
            yield return new WaitForSeconds(weaponData.WeaponDelay);
            reloadCoroutine = false;
        }

        private void ShootBullets()
        {
            SpawnBullet(muzzlePoint.transform.position, CalculateAngle(muzzlePoint));
        }

        private void SpawnBullet(Vector3 position, Quaternion rotation)
        {
            var bulletPrefab = Instantiate(weaponData.BulletData.bulletPrefab, position, rotation);
            bulletPrefab.GetComponent<Bullet>().BulletData = weaponData.BulletData;
        }

        private Quaternion CalculateAngle(GameObject muzzlePoint)
        {
            float spread = UnityEngine.Random.Range(-weaponData.SpreadAngle, weaponData.SpreadAngle);
            Quaternion bulletSpreadRotation = Quaternion.Euler(new Vector3(0, 0, spread));
            return muzzlePoint.transform.rotation * bulletSpreadRotation;
        }
    }
}