namespace PizzaBox.Domain.Abstracts
{
    public abstract class AStore
    {
    public string name{ get; protected set;}
        public AStore()
        {
            name = "Yet to be Named";
        }
        public override string ToString()
        {
            return name;
        }
    }
}