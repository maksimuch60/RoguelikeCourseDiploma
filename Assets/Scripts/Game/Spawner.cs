using System.Collections.Generic;
using UnityEngine;

namespace RogueLike.Game
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private List<GameObject> _enemyPrefabs;
        
        public void SpawnPlayer(Room.Room room)
        {
            Vector3 roomCenterPosition = (room.StartSpawnTransform.position + room.EndSpawnTransform.position) * 0.5f;
            Instantiate(_playerPrefab, roomCenterPosition, Quaternion.identity);
        }

        public void EnemySpawn(Room.Room room, int enemyAmount)
        {
            for (int i = 0; i < enemyAmount; i++)
            {
                int randomIndex = Random.Range(0, _enemyPrefabs.Count);
                Instantiate(_enemyPrefabs[randomIndex], 
                    GetRandomPosition(room.StartSpawnTransform.position, room.EndSpawnTransform.position), 
                    Quaternion.identity);
            }
        }

        private Vector3 GetRandomPosition(Vector3 startSpawnPosition, Vector3 endSpawnPosition)
        {
            float randomXPosition = Random.Range(startSpawnPosition.x, endSpawnPosition.x);
            float randomYPosition = Random.Range(startSpawnPosition.y, endSpawnPosition.y);
            return new Vector3(randomXPosition, randomYPosition, 0);
        }
    }
}