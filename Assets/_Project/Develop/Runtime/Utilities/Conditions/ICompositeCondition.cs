namespace _Project.Develop.Runtime.Utilities.Conditions
{
    public interface ICompositeCondition : ICondition
    {
        ICompositeCondition Add(ICondition condition);
        
        ICompositeCondition Remove(ICondition condition);
    }
    
    public interface ICompositeCondition<T> : ICondition<T>
    {
        ICompositeCondition<T> Add(ICondition<T> condition);
        ICompositeCondition<T> Remove(ICondition<T> condition);
    }
}