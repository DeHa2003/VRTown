namespace Lessons.Architecture
{
    public abstract class Interactor
    {
        public virtual void OnCreate() { } // огда все репо и интеракторы созданы
        public virtual void Initialize() { }// огда все репо и интеракторы выполнили OnCreate()
        public virtual void OnStart() { }// огда все репо и интеракторы выполнили Initialize()
    }
}
