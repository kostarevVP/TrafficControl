namespace Assets.LocalPackages.Lukomor.Scripts.Common.DIContainer
{
    public interface IDIContainer
    {
        public bool IsRoot { get; }
        public void Bind<T>(T instance) where T : class;
        public T Resolve<T>() where T : class;
    }
}
