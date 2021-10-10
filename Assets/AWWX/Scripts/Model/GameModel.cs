using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface IGameModel : IModel
    {
        BindableProperty<int> SelectedMechaId { get; }
    }

    public class GameModel : AbstractModel, IGameModel
    {
        protected override void OnInit()
        {

        }

        public BindableProperty<int> SelectedMechaId { get; } = new BindableProperty<int>()
        {
            Value = 0
        };
    }
}
