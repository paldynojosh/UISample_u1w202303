using VContainer;
using VContainer.Unity;

namespace Pallab.WithVContainer
{
    class メニューLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // インスタンスを作ってもらう
            builder.Register<画面の状態>(Lifetime.Singleton);
        }
    }
}