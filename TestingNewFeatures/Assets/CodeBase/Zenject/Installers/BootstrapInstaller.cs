using CodeBase.Infrastructure.Services;
using Zenject;

namespace CodeBase.Zenject.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            RegisterInputService();
        }

        private void RegisterInputService()
        {
            Container.Bind<IInputService>().To<InputService>().AsSingle();
        }
    }
}