using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AdventureJam.Reactions
{
    public abstract class Reaction : ScriptableObject
    {
        public virtual void Initialize() { }
        public virtual void React(MonoBehaviour behaviour) { }
    }
}
