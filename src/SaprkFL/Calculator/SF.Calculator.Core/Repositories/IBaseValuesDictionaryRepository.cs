using SF.Calculator.Core.Model;

namespace SF.Calculator.Core.Repositories
{
    public interface IBaseValuesDictionaryRepository
    {
        BaseValuesDictionary Get(string key);
    }
}