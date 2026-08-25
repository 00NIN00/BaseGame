using System;

namespace _Project.Develop.Runtime.Utilities.Conditions
{
    public class FuncCondition : ICondition
    {
        private Func<bool> _condition;

        public FuncCondition(Func<bool> condition)
        {
            _condition = condition;
        }

        public bool Evaluate() => _condition.Invoke(); 
    }
    
    public class FuncCondition<T> : ICondition<T>
    {
        private readonly Func<T, bool> _condition;

        public FuncCondition(Func<T, bool> condition)
        {
            _condition = condition;
        }

        public bool Evaluate(T context) => _condition.Invoke(context);
    }
}