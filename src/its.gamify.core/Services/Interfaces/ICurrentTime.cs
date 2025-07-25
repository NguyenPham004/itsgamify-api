namespace its.gamify.core.Services.Interfaces;

public interface ICurrentTime
{
    DateTime GetCurrentTime { get; }
}


public class CurrentTime : ICurrentTime
{
    public DateTime GetCurrentTime { get => DateTime.UtcNow; }
}