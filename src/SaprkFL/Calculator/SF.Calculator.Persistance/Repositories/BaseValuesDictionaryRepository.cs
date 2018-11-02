using System;
using System.Linq;
using SF.Calculator.Core.Model;
using SF.Calculator.Core.Repositories;

namespace SF.Calculator.Persistence.Repositories
{
    public class BaseValuesDictionaryRepository : IBaseValuesDictionaryRepository
    {
        private readonly SFCalculatorContext _context;

        public BaseValuesDictionaryRepository(SFCalculatorContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public BaseValuesDictionary Get(string key)
        {
            return _context.BaseValuesDictionaries.FirstOrDefault(x => x.Key.Equals(key));
        }
    }
}