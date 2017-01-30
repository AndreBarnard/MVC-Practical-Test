namespace SOLIDBox
{
    
    public abstract class Box : IDatabase
    {
        public BoxType _BoxType { get; set; }
        public abstract void Add();
        public abstract double CalculateArea();
    }

   


}
