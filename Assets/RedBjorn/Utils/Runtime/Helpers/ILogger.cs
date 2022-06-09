using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedBjorn.Utils
{
    public interface ILogger
    {
        void Info(object message);
        void Warning(object message);
        void Error(object message);
    }
}
