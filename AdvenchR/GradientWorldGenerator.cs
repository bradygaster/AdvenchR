// GradientWorldGenerator.cs
using AdvenchR;

public class GradientWorldGenerator : IWorldGenerator
{
    public string[,] GenerateWorld(int width, int height)
    {
        string[,] world = new string[width, height];
        var offset = Random.Shared.Next(20);

        // Generate initial terrain type for each cell
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                world[x, y] = DetermineTerrainType(x, y, width, height, offset);
            }
        }

        // Gradually transition terrain types
        for (int i = 0; i < 10; i++) // Adjust the number of iterations as needed
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (Random.Shared.Next(10) < 5) // Randomly choose cells to transition
                    {
                        world[x, y] = DetermineTerrainType(x, y, width, height, offset);
                    }
                }
            }
        }

        return world;
    }

    private string DetermineTerrainType(int x, int y, int width, int height, int offset)
    {
        float noiseValue = SimplexNoise.Noise.CalcPixel2D(x, y, 0.1f);

        Console.WriteLine(noiseValue);

        if (noiseValue < 30 + offset)
            return "water";
        else if (noiseValue > 30 + offset && noiseValue < 80 + offset)
            return "desert";
        else if (noiseValue > 80 + offset && noiseValue < 90 + offset)
            return "castle";
        else if (noiseValue > 100 + offset && noiseValue < 120 + offset)
            return "wasteland";
        else if (noiseValue > 130 + offset && noiseValue < 200 + offset)
            return "mountain";
        else
            return "forest";
    }
}
