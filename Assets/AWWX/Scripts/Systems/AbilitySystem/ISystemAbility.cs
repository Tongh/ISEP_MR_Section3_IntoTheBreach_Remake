using FrameworkDesign;

namespace OutOfTheBreach
{
    public interface ISystemAbility : ISystem
    {

    }

    public class SystemAbility : AbstractSystem, ISystemAbility
    {
        private FDataAllAbility mAbilitiesData;
        private FDataAllEffect mEffectsData;

        protected override void OnInit()
        {
            var storage = this.GetUtility<IStorage>();
            mAbilitiesData = storage.LoadAbilitiesConfigData();
            mEffectsData = storage.LoadEffectsConfigData();


        }


    }
}
