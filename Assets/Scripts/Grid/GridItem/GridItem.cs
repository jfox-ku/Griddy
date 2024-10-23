using System;
using System.Collections.Generic;
using UnityEngine;

namespace Grid.GridItem
{
    public class GridItem
    {
        public List<Vector2Int> Span;
        public List<Vector2Int> EffectSpan;
        public int Rotation;
        public GridItemView View;
        
        public int Size => Span.Count;
        
        
        public IEnumerable<Vector2Int> PositionsFrom(Vector2Int Origin)
        {
            foreach (var pos in Span)
            {
                yield return RotatePosition(pos) + Origin;
            }
        }
        
        public IEnumerable<Vector2Int> EffectPositionsFrom(Vector2Int Origin)
        {
            foreach (var pos in EffectSpan)
            {
                yield return RotatePosition(pos) + Origin;
            }
        }

        private Vector2Int RotatePosition(Vector2Int pos)
        {
            switch (Rotation % 4)
            {
                case 0: // No rotation
                    return pos;
                case 1: // 90 degrees
                    return new Vector2Int(pos.y, -pos.x);
                case 2: // 180 degrees
                    return new Vector2Int(-pos.x, -pos.y);
                case 3: // 270 degrees
                    return new Vector2Int(-pos.y, pos.x);
                default:
                    throw new ArgumentException("Invalid rotation value");
            }
        }
    }
}