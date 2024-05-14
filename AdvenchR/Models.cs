namespace AdvenchR;

public class GridCell
{
    public int X { get; set; }
    public int Y { get; set; }
    public string TerrainType { get; set; } // Add a property for terrain type
}

public interface IGridService
{
    List<GridCell> GetGrid(int width, int height);
}

public interface IWorldGenerator
{
    string[,] GenerateWorld(int width, int height);
}

public class GridService(IWorldGenerator worldGenerator) : IGridService
{
    private List<GridCell> grid;
    private readonly IWorldGenerator worldGenerator = worldGenerator;

    private void InitializeGrid(int width, int height)
    {
        var world = worldGenerator.GenerateWorld(width, height);
        grid = new List<GridCell>();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid.Add(new GridCell { X = x, Y = y, TerrainType = world[x,y] });
            }
        }
    }

    public List<GridCell> GetGrid(int width, int height)
    {
        InitializeGrid(width, height);
        return grid;
    }
}

