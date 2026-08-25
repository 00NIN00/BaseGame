namespace _Project.Develop.Runtime.Utilities.Conditions
{
    public class ParameterlessAdapter<T> : ICondition<T>
    {
        private readonly ICondition _condition;

        public ParameterlessAdapter(ICondition condition)
        {
            _condition = condition;
        }

        public bool Evaluate(T context) => _condition.Evaluate();
    }
}