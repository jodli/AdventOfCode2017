using System;
using System.Collections.Generic;
                    
public class Program
{
    public enum Direction
    {
        Up, Down, Left, Right
    }
    
    public static void Main()
    {
        var input = 277678;
        
        var x = 0;
        var y = 0;
        
        var layer = 0;
        var direction = Direction.Right;
        var across = 1;
        var totalInLayer = 1;
        var layerStepCount = 1;
        
        var squareValues = new Dictionary<(int x, int y), int> { { (0, 0), 1 } };
        
        var sum = 0;
        do
        {
            if (layerStepCount == totalInLayer)
            {       
                layer++;
                Console.WriteLine($"Layer: {layer}");       
                
                across = (layer+1)*2 - 1;
                Console.WriteLine($"Across: {across}");
                
                totalInLayer = across*2 + (across-2)*2;
                Console.WriteLine($"TotalInLayer: {totalInLayer}");
                
                layerStepCount = 0;
                direction = Direction.Right;
            }
            
            switch (direction)
            {
                case Direction.Up:
                    y += 1;
                    if (y == Math.Floor(across/2.0))
                    {
                        direction = Direction.Left;
                    }
                    break;
                case Direction.Down:
                    y -= 1;
                    if (y == -Math.Floor(across/2.0))
                    {
                        direction = Direction.Right;
                    }
                    break;
                case Direction.Left:
                    x -= 1;
                    if (x == -Math.Floor(across/2.0))
                    {
                        direction = Direction.Down;
                    }
                    break;
                case Direction.Right:
                    x += 1;
                    if (x == Math.Floor(across/2.0))
                    {
                        direction = Direction.Up;
                    }
                    break;
            }
            layerStepCount++;
            
            Console.WriteLine($"Current position: {x}, {y}");
            Console.WriteLine($"Next move: {direction:G}");
            
            Console.WriteLine($"Current step count: {layerStepCount}");
            
            sum = 0;
            var val = 0;
            if (squareValues.TryGetValue((x-1, y-1), out val))
            {
                Console.WriteLine($"Found value at x-1, y-1: {val}");
                sum += val;
            }
            if (squareValues.TryGetValue((x+1, y+1), out val))
            {
                Console.WriteLine($"Found value at x+1, y+1: {val}");
                sum += val;
            }
            if (squareValues.TryGetValue((x-1, y), out val))
            {
                Console.WriteLine($"Found value at x-1, y: {val}");
                sum += val;
            }
            if (squareValues.TryGetValue((x, y-1), out val))
            {
                Console.WriteLine($"Found value at x, y-1: {val}");
                sum += val;
            }
            if (squareValues.TryGetValue((x+1, y), out val))
            {
                Console.WriteLine($"Found value at x+1, y: {val}");
                sum += val;
            }
            if (squareValues.TryGetValue((x, y+1), out val))
            {
                Console.WriteLine($"Found value at x, y+1: {val}");
                sum += val;
            }
            if (squareValues.TryGetValue((x+1, y-1), out val))
            {
                Console.WriteLine($"Found value at x+1, y-1: {val}");
                sum += val;
            }
            if (squareValues.TryGetValue((x-1, y+1), out val))
            {
                Console.WriteLine($"Found value at x-1, y+1: {val}");
                sum += val;
            }
            
            squareValues.Add((x, y), sum);
            Console.WriteLine($"Sum is: {sum}");
            
            Console.WriteLine();
        } while (sum < input);
        
        Console.WriteLine($"Input {input} is smaller than written value: {sum}");
    }
}
