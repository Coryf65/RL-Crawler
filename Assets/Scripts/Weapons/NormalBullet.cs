using Cory.RL_Crawler.ScriptableObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Weapons
{
    public class NormalBullet : Bullet
    {
        protected Rigidbody2D rigidbody2D;

        public override BulletData_SO BulletData 
        { 
            get => base.BulletData;
            set 
            {
                base.BulletData = value;
                rigidbody2D = GetComponent<Rigidbody2D>();
                rigidbody2D.drag = BulletData.Friciton;
            }
        }

        private void FixedUpdate()
        {
            if (rigidbody2D != null && BulletData != null)
            {
                // using move position due to our bullet being Kinematic
                rigidbody2D.MovePosition(transform.position + BulletData.BulletSpeed * transform.right * Time.fixedDeltaTime);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
            {
                HitObstacle();
            }else if (collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
            {
                HitEnemy();
            }
            Destroy(gameObject);
        }

        private void HitEnemy()
        {
            // hit enemy
        }

        private void HitObstacle()
        {
            // hit wall
        }
    }
}