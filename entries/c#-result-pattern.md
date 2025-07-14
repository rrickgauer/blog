

This post goes over how I personally like to use the result pattern in my C# applications.

## Error Codes

I always have a database table that stores all the possible error messages that can be returned within the application. Each error message has a unique identifier stored as an integer. From there I map each error message id as an enum in my source code:

```csharp
public enum ErrorCode : int
{
    MiscUnexpectedError                    = 100,
    LoginInvalidCredentials                = 200,
    EventsWeeklyDayIsRequired              = 300,
    EventsWeeklyDayInvalidRange            = 301,
    EventsMonthlyDayIsRequired             = 302,
    EventsMonthlyDayInvalidRangeDayOfMonth = 303,
    EventsMonthlyDayInvalidRangeDayOfWeek  = 304,
    EventsYearlyDayIsRequired              = 305,
    EventsYearlyDayInvalidRangeDayOfMonth  = 306,
    EventsYearlyDayInvalidRangeDayOfWeek   = 307,
    EventsYearlyMonthInvalidRange          = 308,
    EventsInvalidLabelsQueryParm           = 309,
    LabelsInvalidColorValue                = 400,
    SignupEmailTaken                       = 500,
    AccountSettingsInvalidPassword         = 600,
}
```


## Base Class

Here is the base `ServiceResponse` class:

```csharp
public class ServiceResponse
{
    public List<ErrorCode> Errors { get; set; } = new();
    public bool Successful => Errors.Count == 0;

    public ServiceResponse() { }

    public ServiceResponse(ErrorCode errorCode)
    {
        Errors.Add(errorCode);
    }

    public ServiceResponse(IEnumerable<ErrorCode> errors)
    {
        Errors = errors.ToList();
    }

    public ServiceResponse(ServiceResponse other)
    {
        AddErrors(other.Errors);
    }
}
```

## Returning Data

If I need to return data, I use a the `ServiceResponse<T>` class:

```csharp
public class ServiceResponse<T> : ServiceResponse
{
    public T? Data { get; set; }

    #region - Constructors -
    public ServiceResponse() : base() { }

    public ServiceResponse(T? data) : base()
    {
        Data = data;
    }

    public ServiceResponse(ErrorCode error) : base(error) { }
    public ServiceResponse(IEnumerable<ErrorCode> errors) : base(errors) { }
    public ServiceResponse(ServiceResponse other) : base(other) { }
    #endregion

    public T GetData()
    {
        return Data ?? throw new NotFoundHttpResponseException();
    }

    public bool TryGetData([NotNullWhen(true)] out T? data)
    {
        data = Data;

        return data != null;
    }

    #region - Casting Overloads -
    public static implicit operator ServiceResponse<T>(T other)
    {
        return new(other);
    }
    #endregion
}
```

