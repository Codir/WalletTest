using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class UnityMainThreadDispatcher : MonoBehaviour
    {
        #region fields

        private static UnityMainThreadDispatcher _instance;
        private readonly Queue<Action> _actions;

        #endregion

        #region properties

        public static UnityMainThreadDispatcher Instance
        {
            get
            {
                if (_instance != null) return _instance;

                var go = new GameObject("UnityMainThreadDispatcher");
                _instance = go.AddComponent<UnityMainThreadDispatcher>();

                return _instance;
            }
        }

        #endregion

        #region contructor

        private UnityMainThreadDispatcher()
        {
            _actions = new Queue<Action>();
        }

        #endregion

        #region public methods

        public void Enqueue(Action action)
        {
            lock (_actions)
            {
                _actions.Enqueue(action);
            }
        }

        #endregion

        #region private methods

        private void Update()
        {
            lock (_actions)
            {
                while (_actions.Count > 0)
                {
                    _actions.Dequeue().Invoke();
                }
            }
        }

        #endregion
    }
}