class Circle : IFigure, IHasInterior
{
    string IHasInterior.Color { get; set; }

    public Circle(string color)
    {
        ((IHasInterior)this).Color = color;
    }

    public void moveTo(double x, double y)
    {
        throw new System.NotImplementedException();
    }
}

class Square : IFigure, IHasInterior
{
    string IHasInterior.Color { get; set; }

    public Square(string color)
    {
        ((IHasInterior) this).Color = color;
    }

    public void moveTo(double x, double y)
    {
        throw new System.NotImplementedException();
    }
}