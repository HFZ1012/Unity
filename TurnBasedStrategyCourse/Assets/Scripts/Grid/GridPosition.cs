using System;

public struct GridPosition : IEquatable<GridPosition> // Struct to represent a grid position;
{
    public int x; // X position of the grid cell;
    public int z; // Z position of the grid cell;
    public GridPosition(int x, int z) // Constructor;
    {
        this.x = x; // Set the x position of the grid cell;
        this.z = z; // Set the z position of the grid cell;
    }

    public bool Equals(GridPosition other) // Override the Equals method;
    {
        return this == other; // Return true if the x and z positions are equal;
    }

    public override bool Equals(object obj) // Override the Equals method;
    {
        return obj is GridPosition position && // Check if the object is a grid position;
               x == position.x && // Check if the x positions are equal;
               z == position.z; // Check if the z positions are equal;
    }

    public override int GetHashCode() // Override the GetHashCode method;
    {
        return HashCode.Combine(x, z); // Return the hash code of the grid position;
    }

    public override string ToString() // Override the ToString method;
    {
        return "x: " + x + ", z: " + z; // Return the string representation of the grid position;
    }
    
    public static bool operator ==(GridPosition a, GridPosition b) // Override the equality operator;
    {
        return a.x == b.x && a.z == b.z; // Return true if the x and z positions are equal;
    }

    public static bool operator !=(GridPosition a, GridPosition b) // Override the inequality operator;
    {
        return !(a == b); // Return true if the x and z positions are not equal;
    }

    public static GridPosition operator +(GridPosition a, GridPosition b) // Override the addition operator;
    {
        return new GridPosition(a.x + b.x, a.z + b.z); // Return the sum of the grid positions;
    }

    public static GridPosition operator -(GridPosition a, GridPosition b) // Override the subtraction operator;
    {
        return new GridPosition(a.x - b.x, a.z - b.z); // Return the difference of the grid positions;
    }
}