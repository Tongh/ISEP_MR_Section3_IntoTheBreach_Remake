using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IGameModel : IModel
    {
        BindableProperty<int> GameState { get; }
        BindableProperty<int> Difficulty { get; }
        BindableProperty<int> Energy { get; }
        BindableProperty<int> TurnLeft { get; }
        BindableProperty<string> SelectedMechaId { get; }
    }

    public class GameModel : AbstractModel, IGameModel
    {
        protected override void OnInit()
        {

        }

        public BindableProperty<int> GameState { get; } = new BindableProperty<int>()
        {
            Value = (int)EGameState.GameSetting
        };

        public BindableProperty<int> Difficulty { get; } = new BindableProperty<int>()
        {
            Value = (int)EGameDifficulty.NORMAL
        };

        public BindableProperty<int> Energy { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        public BindableProperty<int> TurnLeft { get; } = new BindableProperty<int>()
        {
            Value = 0
        };

        public BindableProperty<string> SelectedMechaId { get; } = new BindableProperty<string>()
        {
            Value = ""
        };
    }
}
