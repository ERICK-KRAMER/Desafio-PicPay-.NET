namespace PicPay.Model.Response;

public class Result<T>
{
    public bool IsSuccess { get; set; }
    public string ErrorMessage { get; set; }
    public T Value { get; set; }

    public Result(bool isSuccess, string errorMessage, T value)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
        Value = value;
    }

    public static Result<T> Success(T value) => new Result<T>(true, null, value);
    public static Result<T> Falied(string errorMessage) => new Result<T>(false, errorMessage, default);
}