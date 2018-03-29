﻿using UnityEngine;

namespace Assets.Scripts.Controllers.StateMachine
{
    class ZombieSearchState : ZombieState
    {
        private const string PLAYER_TAG = "player";

        public override void Update(GameObject gameObject)
        {
            var controller = gameObject.GetComponent<ZombieController>();
            var target = FindTarget(gameObject.transform, controller.radius);
            if (target != null)
            {
                controller.target = target;
                var stateMachine = gameObject.GetComponent<ZombieStateMachine>();
                stateMachine.currentState = ZombieStateMachine.running;
            }
        }

        private GameObject FindTarget(Transform transform, float radius)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            Collider nearestCollider = null;
            float minSqrDistance = Mathf.Infinity;

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].tag == PLAYER_TAG)
                {
                    float sqrDistanceToCenter = (transform.position - colliders[i].transform.position).sqrMagnitude;

                    if (sqrDistanceToCenter < minSqrDistance)
                    {
                        minSqrDistance = sqrDistanceToCenter;
                        nearestCollider = colliders[i];
                    }
                }
            }
            if (nearestCollider != null)
            {
                return nearestCollider.gameObject;
            }
            return null;
        }
    }
}