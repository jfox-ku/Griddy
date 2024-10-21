using System;
using System.Collections.Generic;
using UnityEngine;

namespace Grid
{
    [Serializable]
    public class GridTile
    {
        [NonSerialized]
        public Dictionary<int, GridTileElement> Elements = new Dictionary<int, GridTileElement>();

        [SerializeField]
        private List<GridTileElement> serializedElements = new List<GridTileElement>();

        public void AddElement(GridTileElement element, bool replace = false)
        {
            var e = GetElement(element.ElementIndex);
            if (e != null)
            {
                if (replace)
                {
                    RemoveElement(e);
                }
                else
                {
                    Debug.LogError($"Element already exists in tile. {e.ElementIndex}");
                }
            }
            element.Parent = this;
            Elements.Add(element.ElementIndex, element);
        }

        public void RemoveElement(GridTileElement element)
        {
            Elements.Remove(element.ElementIndex);
        }

        public GridTileElement GetElement(int index)
        {
            if (!Elements.ContainsKey(index))
            {
                return null;
            }
            return Elements[index];
        }

        // Converts the dictionary to a serializable list format
        public void PrepareForSerialization()
        {
            serializedElements.Clear();
            foreach (var element in Elements.Values)
            {
                serializedElements.Add(element);
            }
        }

        // Converts the serializable list back to a dictionary
        public void AfterDeserialization()
        {
            Elements.Clear();
            foreach (var element in serializedElements)
            {
                Elements[element.ElementIndex] = element;
            }
        }

        public string Serialize()
        {
            PrepareForSerialization();
            return JsonUtility.ToJson(this);
        }

        public static GridTile Deserialize(string json)
        {
            GridTile gridTile = JsonUtility.FromJson<GridTile>(json);
            gridTile.AfterDeserialization();
            return gridTile;
        }
    }
}
