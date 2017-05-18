using Fungus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AdventureJam.Reactions
{
    [CreateAssetMenu]
    public class ExecuteBlockReaction : Reaction
    {
        [SerializeField]
        private string _blockName;

        private Block _block;

        public override void Initialize()
        {
            var flowchart = FindObjectOfType<Flowchart>();
            if (flowchart != null)
            {
                _block = flowchart.FindBlock(_blockName);
            }
        }

        protected override void React()
        {
            _block.StartExecution();
        }
    }
}
