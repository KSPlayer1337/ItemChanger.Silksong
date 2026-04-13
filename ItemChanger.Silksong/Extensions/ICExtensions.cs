using ItemChanger.Containers;
using ItemChanger.Costs;
using ItemChanger.Items;
using ItemChanger.Placements;
using ItemChanger.Serialization;
using Newtonsoft.Json;

namespace ItemChanger.Silksong.Extensions;

internal static class ICExtensions
{
    /// <summary>
    /// Converts an object to a writable value provider wrapping that object.
    /// </summary>
    public static IWritableValueProvider<T> ToValueProvider<T>(this T t) => new LiftedT<T> { Value = t };
    /// <summary>
    /// Converts a struct-returning value provider to an object-returning value provider.
    /// </summary>
    public static IValueProvider<object> Embox<T>(this IValueProvider<T> t) where T : struct => new Box<T> { Source = t };
    /// <summary>
    /// Returns a name incorporating the name of the placement and the indices of the items associated with the container.
    /// </summary>
    public static string GetGameObjectName(this ContainerInfo info, string prefix)
    {
        string itemSuffix;
        IEnumerable<Item> items = info.GiveInfo.Items;
        Placement placement = info.GiveInfo.Placement;

        if (ReferenceEquals(placement.Items, items))
        {
            itemSuffix = "all";
        }
        else
        {
            itemSuffix = string.Join(",", items.Select(i => placement.Items.IndexOf(i) is int j && j >= 0 ? j.ToString() : "?"));
        }


        return $"{prefix}-{placement.Name}-{itemSuffix}";
    }

    public static string GetUIName(this Placement pmt, IEnumerable<Item> items, int maxLength = 120)
    {
        IEnumerable<string> itemNames = items
            .Where(i => !i.IsObtained())
            .Select(i => i.GetPreviewName(pmt) ?? "Unknown Item");
        string itemText = string.Join(", ", itemNames);
        if (itemText.Length > maxLength)
        {
            itemText = itemText[..(maxLength > 3 ? maxLength - 3 : 0)] + "...";
        }

        return itemText;
    }

    public static string GetUIName(this ContainerCostInfo info, int maxLength = 120)
        => info.Placement.GetUIName(info.PreviewItems, maxLength);

    /// <summary>
    /// Pay the cost if it has not been paid. If it has been paid, this is a no-op.
    /// </summary>
    public static void PayIfNotPaid(this Cost c)
    {
        if (!c.Paid)
        {
            c.Pay();
        }
    }

    /// <summary>
    /// Return a value provider that returns the same object as self but strongly typed as a subclass.
    /// </summary>
    public static IValueProvider<TDerived> Downcast<TBase, TDerived>(this IValueProvider<TBase> self) where TDerived : TBase
    {
        return new CastingProvider<TBase, TDerived>() { Inner = self };
    }

    private class Box<T> : IValueProvider<object> where T : struct
    {
        public required IValueProvider<T> Source { get; init; }
        public object Value => Source.Value;
    }

    private class LiftedT<T> : IWritableValueProvider<T>
    {
        public required T Value { get; set; }
    }

    private class CastingProvider<TBase, TDerived> : IValueProvider<TDerived> where TDerived : TBase
    {
        public required IValueProvider<TBase> Inner { get; init; }

        [JsonIgnore] public TDerived Value => (TDerived)Inner.Value!;
    }
}
