using System.ComponentModel;

public class Cell : INotifyPropertyChanged
{
    private bool isAlive;

    public int X { get; set; }
    public int Y { get; set; }

    public bool IsAlive
    {
        get => isAlive;
        set
        {
            if (isAlive != value)
            {
                isAlive = value;
                OnPropertyChanged(nameof(IsAlive));
            }
        }
    }

    public bool isEffectiveNow { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}