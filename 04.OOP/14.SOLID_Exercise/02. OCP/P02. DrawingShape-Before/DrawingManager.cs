namespace P02._DrawingShape_Before
{
    using Contracts;

    class DrawingManager : IDrawingManager
    {
        public void Draw(IShape shape)
        {
            shape.Draw();
        }
    }
}
