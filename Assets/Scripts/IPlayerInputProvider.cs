namespace StinkySteak.Rootdash.Player
{
    public interface IPlayerInputProvider
    {
        PlayerInput.PlayerActions Input { get; }
    }
}