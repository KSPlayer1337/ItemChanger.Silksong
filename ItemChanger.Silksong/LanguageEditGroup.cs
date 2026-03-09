using ItemChanger.Silksong.Serialization;
using System.Collections;

namespace ItemChanger.Silksong;

/// <summary>
/// Object to manage hooking and unhooking a group of language string edits.
/// </summary>
public sealed class LanguageEditGroup : IDisposable, IEnumerable<(LanguageString, Func<string, string>)>
{
    private readonly List<(LanguageString, Func<string, string>)> edits = [];

    public void Add(LanguageString id, Func<string, string> edit)
    {
        edits.Add((id, edit));
        Host.AddLanguageEdit(id, edit);
    }

    /// <summary>
    /// Removes all edits associated with the group.
    /// </summary>
    public void Dispose()
    {
        foreach ((LanguageString id, Func<string, string> edit) in edits) Host.RemoveLanguageEdit(id, edit);
    }

    IEnumerator<(LanguageString, Func<string, string>)> IEnumerable<(LanguageString, Func<string, string>)>.GetEnumerator()
    {
        return edits.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return edits.GetEnumerator();
    }
}
