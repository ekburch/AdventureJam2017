using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace AdventureJam.Reactions
{
    public class PickupItemReaction : DelayedReaction
    {
        [SerializeField]
        private GameObject _item;

        // TODO: Replace this with an inventory class
        private MonoBehaviour _inventory;

        public override void Initialize()
        {
            // TODO: Replace this with an inventory class
            _inventory = FindObjectOfType<MonoBehaviour>();

            base.Initialize();
        }

        protected override void React()
        {
            // something along the lines of `_inventory.AddItem(_item)`
        }
    }
}
