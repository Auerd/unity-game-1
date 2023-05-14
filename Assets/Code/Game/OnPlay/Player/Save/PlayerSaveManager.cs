using EventSystem;
using System;
using UnityEngine;

namespace SaveSystem
{
    public class PlayerSaveManager : MonoBehaviour
    {
        string saveKey;
        [SerializeField]
        GameEvent saveEvent;

        private void Start()
        {
            saveKey = transform.name;
            saveEvent.Subscribe(Save);
            Load();
        }

        private void OnApplicationQuit() =>
            Save();

        [Serializable]
        private struct PlayerData
        {
            public float[] pos;
            public int lvl;
        }

        void Save()
        {
            PlayerData data = new()
            {
                pos = new float[2]
                {
                transform.position.x, transform.position.y,
                },
            };
            SaveManager.Save(saveKey, data);
        }

        void Load()
        {
            if (SaveManager.TryLoad(saveKey, out PlayerData data))
            {
                transform.position = new Vector2()
                {
                    x = data.pos[0],
                    y = data.pos[1]
                };
            }
            else
                transform.position = new Vector2();
        }
    }
}