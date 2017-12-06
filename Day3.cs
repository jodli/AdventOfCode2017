using System;
                    
public class Program
{
    public static void Main()
    {
        var input = 277678;
        
        var (layerDistance, distanceToCenter) = GetDistanceToLayerAndCenter(input);
        Console.WriteLine($"Input {input} has distance to center {layerDistance} and to center on layer {distanceToCenter}");
        Console.WriteLine($"Manhattan Distance: {layerDistance + distanceToCenter}");
    }
    
    public static (int distanceToLayer, int distanceToCenter) GetDistanceToLayerAndCenter(int input)
    {
        if (input == 1)
        {
            return (0, 0);
        }
        
        var first = 1;
        var last = 1;
        
        var centers = new [] { 0,0,0,1 };
        
        var layer = 0;
        var minDistance = 0;
        
        do {
            layer++;            
            var across = (layer+1)*2 - 1;
            
            var totalInLayer = across*2 + (across-2)*2;
            
            first = last + 1;
            last = first + totalInLayer - 1;
            
            var centerOffset = totalInLayer / 4;
            
            centers[0] = centers[3] + across - 2;
            centers[1] = centers[0] + centerOffset;
            centers[2] = centers[1] + centerOffset;
            centers[3] = centers[2] + centerOffset;
            
            minDistance = across;           
            foreach (var center in centers)
            {
                var distance = Math.Abs(center - input);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }
        } while (!(input >= first && input <= last));
        
        return (layer, minDistance);
    }
}
