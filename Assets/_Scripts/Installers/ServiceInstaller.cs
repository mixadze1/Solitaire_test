using _Scripts.GameLogic;
using Zenject;

namespace _Scripts.Installers
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGeneratorCards();
        }

        private void BindGeneratorCards()
        {
            Container.Bind<GeneratorCards>().AsSingle();
        }
    }
}
