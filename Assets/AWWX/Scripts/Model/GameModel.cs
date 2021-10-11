using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IGameModel : IModel
    {
        BindableProperty<int> GameState { get; }
        BindableProperty<int> Difficulty { get; }
        BindableProperty<int> Energy { get; }
        BindableProperty<int> TurnLeft { get; }
        BindableProperty<string> [] MechaModels { get; }
        BindableProperty<string> SelectedMechaId { get; }
    }

    public class GameModel : AbstractModel, IGameModel
    {
        protected override void OnInit()
        {
            ResetArray();
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
            Value = 3
        };

        public BindableProperty<int> TurnLeft { get; } = new BindableProperty<int>()
        {
            Value = 5
        };

        public BindableProperty<string> [] MechaModels { get; } = new BindableProperty<string>[3];

        public BindableProperty<string> SelectedMechaId { get; } = new BindableProperty<string>()
        {
            Value = ""
        };

        private void ResetArray()
        {
            for (int i = 0; i < 3; i++)
            {
                MechaModels[i] = new BindableProperty<string>() { Value = i.ToString() };
            }
        }
    }
}
