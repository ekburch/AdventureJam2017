using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AdventureJam.DataPersistence
{
    public abstract class ResettableScriptableObject : ScriptableObject
    {
        public abstract void Reset();
    }
}
