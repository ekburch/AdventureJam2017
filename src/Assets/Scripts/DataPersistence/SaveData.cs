using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AdventureJam.DataPersistence
{
    [CreateAssetMenu]
    public class SaveData : ResettableScriptableObject
    {
        private Dictionary<string, object> _playerPrefs = new Dictionary<string, object>();

        public void Set<T>(string key, T value)
        {
            if (_playerPrefs.ContainsKey(key))
                _playerPrefs[key] = value;
            else
                _playerPrefs.Add(key, value);
        }

        public bool Get<T>(string key, ref T param)
        {
            object value;
            if (_playerPrefs.TryGetValue(key, out value))
            {
                param = (T)value;
                return true;
            }

            return false;
        }

        public override void Reset()
        {
            _playerPrefs.Clear();
        }

        public bool FromString(string value)
        {
            _playerPrefs = JsonConvert.DeserializeObject<Dictionary<string, object>>(value);
            return _playerPrefs != null;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(_playerPrefs);
        }
    }
}
