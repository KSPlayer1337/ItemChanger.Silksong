using ItemChanger.Modules;

namespace ItemChanger.Silksong.Modules;

public abstract class HookModule : Module
{
    private readonly List<IDisposable> disposables = [];

    protected void Using(IDisposable disposable) => disposables.Add(disposable);

    protected override void DoUnload()
    {
        foreach (IDisposable disposable in disposables) disposable.Dispose();
        disposables.Clear();
    }
}
