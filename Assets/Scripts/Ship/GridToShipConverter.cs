using Grid;

namespace Ship
{
    public static class GridToShipConverter
    {
        public static Ship ConvertGrid(GridBase grid)
        {
            Ship ship = new Ship();
            foreach (var gridTile in grid.Grid)
            {
                ShipComponent shipComponent = ConvertGridComponent(gridTile);
                ship.AddComponent(shipComponent);
            }
            return ship;
        }

        private static ShipComponent ConvertGridComponent(GridTile tile)
        {
            return null;
        }
    }
}