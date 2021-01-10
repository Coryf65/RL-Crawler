using Cory.RL_Crawler.Controllers;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random; // anytime I call Random I am using Unity's Implementation

namespace Cory.RL_Crawler.Feedbacks
{
    public class BulletShellGenerator : ObjectPool
    {
        [SerializeField] private float inAirDuration = 0.3f;
        [SerializeField] private float inAirStrength = 1;

        public void SpawnBulletShell()
        {
            var emptyCasing = SpawnObject();
            MoveShellInRandomDirection(emptyCasing);
        }

        private void MoveShellInRandomDirection(GameObject emptyCasing)
        {
            emptyCasing.transform.DOComplete();
            // random direction
            var randomDirection = UnityEngine.Random.insideUnitCircle; // gen a random point inside a circle
            // prevent from going upwards, if it does mak it opposite to go downwards
            randomDirection = randomDirection.y > 0 ? new Vector2(randomDirection.x, -randomDirection.y) : randomDirection;
            // move the empty bullet casing and then when done and hits the ground play our sound
            emptyCasing.transform.DOMove(((Vector2)transform.position + randomDirection) * inAirStrength, inAirDuration).OnComplete(() => emptyCasing.GetComponent<AudioSource>().Play());

            emptyCasing.transform.DORotate(new Vector3(0, 0, Random.Range(0f, 360f)), inAirDuration); // rotate the emptycasing
        }
    }
}