using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedBjorn.Utils
{
    public class Logger : ILogger
    {
        public void Info(object message)
        {
            Debug.Log(message);
        }

        public void Warning(object message)
        {
            Debug.LogWarning(message);
        }

        public void Error(object message)
        {
            Debug.LogError(message);
        }
    }
}