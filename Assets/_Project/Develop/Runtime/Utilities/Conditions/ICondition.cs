namespace _Project.Develop.Runtime.Utilities.Conditions
{
    public interface ICondition
    {
        bool Evaluate();
    }
    
    public interface ICondition<T>
    {
        bool Evaluate(T context);
    }
}