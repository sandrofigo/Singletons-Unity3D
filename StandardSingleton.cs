namespace Singletons
{
    public abstract class StandardSingleton<T> where T : class, new() //TODO: this pattern is flawed, the constructor needs to be public, but we don't want that! (╯°□°）╯︵ ┻━┻
    {
        private static T instance;
        public static T Instance => instance ?? (instance = new T());
    }
}