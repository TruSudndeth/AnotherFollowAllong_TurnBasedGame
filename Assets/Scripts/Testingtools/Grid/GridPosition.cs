


public struct GridPosition
{
    public int x;
    public int z;

    public GridPosition(int X, int Z)
    {
        x = X;
        z = Z;
    }

    public override string ToString()
    {
        return "X: " + x + "; Z: " + z;
    }
}