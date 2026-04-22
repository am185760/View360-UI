namespace EView360.Services
{
    public class NotifyService
    {
        public event Action? OnAtmChange;
        public event Action? OnRegionChange;
        public event Action? OnNodeChange;
        public event Action? OnSearchListChange;


        public async Task NotifyAtmChanged()
        {
            OnAtmChange?.Invoke();
            await Task.CompletedTask;
        }
        public async Task NotifyRegionChanged()
        {
            OnRegionChange?.Invoke();
            await Task.CompletedTask;
        }

        public async Task NotifyNodeChanged()
        {
            OnNodeChange?.Invoke();
            await Task.CompletedTask;
        }

        public async Task NotifySearchListChanged()
        {
            OnSearchListChange?.Invoke();
            await Task.CompletedTask;
        }
    }
}
