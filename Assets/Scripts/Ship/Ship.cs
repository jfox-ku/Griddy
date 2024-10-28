using System;
using System.Collections.Generic;

namespace Ship
{
    public class Ship
    {
        [NonSerialized]
        public Dictionary<int,ShipComponent> Components = new Dictionary<int, ShipComponent>();
        
        public void AddComponent(ShipComponent component)
        {
            Components.Add(component.ComponentIndex, component);
        }
    }
}