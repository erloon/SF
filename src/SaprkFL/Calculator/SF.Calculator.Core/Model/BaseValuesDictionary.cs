using System;
using SF.Shared.Infrastructure;

namespace SF.Calculator.Core.Model
{
    public class BaseValuesDictionary : Entity
    {
        public string Key { get;protected set; }
        public string Value { get;protected set; }

        protected BaseValuesDictionary(){}

        public BaseValuesDictionary(string key, string value)
        {
            this.Id = Guid.NewGuid();
            this.Key = key;
            this.Value = value;
        }
    }
}