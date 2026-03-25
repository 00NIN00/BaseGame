using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Develop.Runtime.Utilities.Reactive;

namespace _Project.Develop.Runtime.Meta.Features.Wallet
{
    public class WalletService
    {
        private readonly Dictionary<CurrencyType, ReactiveVariable<int>> _currencies;

        public WalletService(Dictionary<CurrencyType, ReactiveVariable<int>> currencies)
        {
            _currencies = new(currencies);
        }

        public IReadOnlyList<CurrencyType> AvailableCurrencies => _currencies.Keys.ToList();
        
        public IReadOnlyReactiveValue<int> GetCurrency(CurrencyType type) => _currencies[type];

        public bool Enough(CurrencyType type, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            return _currencies[type].Value >= amount;
        }

        public void Add(CurrencyType type, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            _currencies[type].Value += amount;
        }
        
        public void Spend(CurrencyType type, int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (Enough(type, amount) == false)
                throw new ArgumentOutOfRangeException($"Not enough {type} amount");
            
            _currencies[type].Value -= amount;
        }
    }
}