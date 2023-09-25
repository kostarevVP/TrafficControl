using Assets.LocalPackages.Lukomor.Scripts.Common.DIContainer;

namespace Lukomor.Common.DIContainer
{
    public static class InjectDI<T> where T : class
	{
		private static IDIContainer _dIcontainer = null;

        public static void AddProjectContainer(IDIContainer dIcontainer)
        {
            _dIcontainer = dIcontainer;
        }

        public static TRresolve Get<TRresolve>() where TRresolve : class
        {
            return _dIcontainer.Resolve<TRresolve>();
        }
    }
}