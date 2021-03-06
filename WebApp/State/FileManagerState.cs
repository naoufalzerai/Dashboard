using Entities.Entity;

namespace WebApp.State;

public class FileManagerState
{
    private SmbConfiguration? savedConfig;

    public SmbConfiguration Property
    {
        get => savedConfig ?? new SmbConfiguration();
        set
        {
            savedConfig = value;
            NotifyStateChanged();
        }
    }

    public event Action? OnChange;

    private void NotifyStateChanged() => OnChange?.Invoke();
}