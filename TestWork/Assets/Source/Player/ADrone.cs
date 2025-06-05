using Data;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;
using Random = UnityEngine.Random;

namespace Player
{
    public abstract class ADrone : MonoBehaviour
    {
        public float speed;
        [SerializeField] private NavMeshAgent agent;
        public Transform _targetResource;
        protected Transform _base;
        private float _radius=50f;
        protected Score _score;
        private ISound _sound;
        protected ParticleSystem _parti;

        [Inject]
        public virtual void Construct(TransformData transformData, Score score, ISound sound, ParticleData particleData)
        {
            _sound = sound;
        }
 void Start()
        {
            agent.speed = speed;
            StartCoroutine(DroneRoutine());
        }
 

 IEnumerator DroneRoutine()
        {
            while (true)
            {
                Vector3 randomPosition = GetRandomPosition();
                agent.SetDestination(randomPosition);
                Debug.Log(randomPosition);
                Debug.Log(transform.position+ gameObject.name);
                yield return new WaitUntil(() => Vector3.Distance(transform.position, randomPosition) < 4f);

                FindResource();
                _radius += _radius;
                if (_targetResource != null)
                {
                    _targetResource.GetComponent<Stone>().SetOccupied(true);
                    agent.SetDestination(_targetResource.position);
                    yield return new WaitUntil(() => Vector3.Distance(transform.position, _targetResource.position) < 4f);
                    yield return new WaitForSeconds(2f);
                    Destroy(_targetResource.gameObject);
                    _targetResource = null;
                    _radius = 50f;
                    ReturnToBase();
                    yield return new WaitUntil(() => Vector3.Distance(transform.position, _base.position) < 4f);
                    GetScore();
                    _sound.PlayPutSound();
                    _parti.Play();
                }
            }
        }
        private Vector3 GetRandomPosition()
        {
            float fixedY = transform.position.y;
            Vector3 randomDirection = Random.insideUnitSphere * 30f;
            randomDirection += transform.position;
            randomDirection.y = fixedY;
            NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, 30f, NavMesh.AllAreas);
            return new Vector3(hit.position.x, fixedY, hit.position.z);
        }
        void FindResource()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, _radius);
            foreach (var hit in hits)
            {
                if (hit.CompareTag("Resource"))
                {
                    var resource = hit.GetComponent<Stone>();
                    if (resource != null && !resource.IsOccupied) 
                    {
                        _targetResource = hit.transform;
                        break;
                    }
                }
            }
        }
        private void ReturnToBase()
        {
            agent.SetDestination(_base.position);
        }

        public virtual void GetScore()
        {
            
        }
    }
}
