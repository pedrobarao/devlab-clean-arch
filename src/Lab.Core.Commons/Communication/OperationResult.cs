// using Lab.Core.Commons.Specifications;
//
// namespace Lab.Core.Commons.Communication;
//
// public interface IOperationResult
// {
//     void AddError(string error);
//
//     void AddErrors(ValidationResult validationResult);
//
//     void AddErrors(IEnumerable<string> errors);
//
//     void ClearErrors();
//
//     bool HasErrors();
//
//     IEnumerable<string> GetErrors();
// }
//
// public interface IOperationResult<TData> : IOperationResult
// {
//     TData GetData();
//
//     void SetData(TData data);
// }
//
// public class OperationResult : IOperationResult
// {
//     private readonly List<string> _errors = new();
//
//     internal OperationResult()
//     {
//     }
//
//     public void AddError(string error)
//     {
//         _errors.Add(error);
//     }
//
//     public void AddErrors(ValidationResult validationResult)
//     {
//         foreach (var error in validationResult.Errors) _errors.Add(error.ErrorMessage);
//     }
//
//     public void AddErrors(IEnumerable<string> errors)
//     {
//         foreach (var error in errors) _errors.Add(error);
//     }
//
//     public void ClearErrors()
//     {
//         _errors.Clear();
//     }
//
//     public bool HasErrors()
//     {
//         return _errors.Count > 0;
//     }
//
//     public IEnumerable<string> GetErrors()
//     {
//         return _errors;
//     }
// }
//
// public class OperationResult<TData> : OperationResult, IOperationResult<TData>
// {
//     private TData _data;
//
//     internal OperationResult(TData data = default)
//     {
//         _data = data;
//     }
//
//     public TData GetData()
//     {
//         return _data;
//     }
//
//     public void SetData(TData data)
//     {
//         _data = data;
//     }
// }
//
// public static class Result
// {
//     public static OperationResult Create()
//     {
//         return new OperationResult();
//     }
//
//     public static OperationResult<T> Create<T>(T data = default)
//     {
//         return new OperationResult<T>(data);
//     }
// }