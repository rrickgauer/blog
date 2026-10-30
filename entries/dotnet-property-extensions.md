
C# just recently added [extension properties](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14?utm_source=chatgpt.com#extension-members). This new feature allows you to add new properties to exisisting types/classes. Even ones that you do not have control over. They behave similarly to the pre-existing extension methods feature.

## Example

Let's start by making a new `Person` class with a few properties:

```csharp
public class Person
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required DateOnly Birthday { get; init; }
}
```

Now, let's add a few additional properties to the `Person` class using the new extension property feature:

```csharp
public static class PersonExtensions
{
    extension(Person person)
    {
        public bool CanPurchaseAlcohol => person.Birthday <= GetCurrentDate().AddYears(-21);
        public string FullName => $"{person.FirstName} {person.LastName}";
    }

    private static DateOnly GetCurrentDate() => DateOnly.FromDateTime(DateTime.Today);
}
```

Now you can use those extension properties elsewhere in your code like they are normal class properties:

```csharp
Person p1 = new
{
    FirstName = "Ryan",
    LastName = "Rickgauer",
    Birthday = DateOnly.ParseExact("1996/03/08", "yyyy/MM/dd", CultureInfo.InvariantCulture),
};

Console.WriteLine(p1.FullName);             // Ryan Rickgauer
Console.WriteLine(p1.CanPurchaseAlcohol);   // true
```

## Real World Example

The previous example shows how you can add these new properties to a class you created. However, that doesn't really help us out too much since we just could have added those 2 new properties to our `Person` class ourselves.

The true power of these extension properties comes from the fact that you can add new properties to existing classes that you *don't* control. For instance, here's a snippet from some code I use to extract data from an `ActionExecutingContext` class. This class is provided to us from C#, and I can't just add new properties to the class definition like I could before in my `Person` class:

```csharp
public static class ActionExecutingContextUtility
{
    extension(ActionExecutingContext context)
    {
        public int ClientId => context.GetSessionClientId();
        public CollectionId CollectionId => context.GetActionItem<CollectionId>();
        public QuestionId QuestionIdBase => context.GetActionItem<QuestionId>();
        public QuestionForm QuestionForm => context.GetActionItem<QuestionForm>();
        public AnswerId AnswerId => context.GetActionItem<AnswerId>();
        public AnswerSelectionForm AnswerSelectionForm => context.GetActionItem<AnswerSelectionForm>();
        public AnswerTextForm AnswerTextForm => context.GetActionItem<AnswerTextForm>();
    }

    public static T GetActionItem<T>(this ActionExecutingContext context)
    {
        return (T)context.ActionArguments.Values.First(a => a is T)!;
    }
}
```

Now when I implement an `IAsyncActionFilter` on a controller/endpoint I can just call these new property extensions on the given `ActionExecutingContext` parameter:

```csharp
public class GetCollectionFilter(GetCollectionAuth auth) : IAsyncActionFilter
{
    private readonly GetCollectionAuth _auth = auth;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var hasAuth = await _auth.HasPermissionAsync(new()
        {
            ClientId = context.ClientId,            // property extension
            CollectionId = context.CollectionId,    // property extension
        });

        await this.HandlePermissionsAuthResponse(context, next, hasAuth);
    }
}
```

## Further Reading

https://mareks-082.medium.com/after-17-years-c-finally-gets-extension-properties-04409fba592e