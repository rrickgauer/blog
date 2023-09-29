namespace BlogPilot.Services.Domain.TableViews;

public interface ITableViewModel<in TSelf, out TModel>
    where TSelf : ITableViewModel<TSelf, TModel>, ITableView
{
    public static abstract explicit operator TModel(TSelf other);
}
