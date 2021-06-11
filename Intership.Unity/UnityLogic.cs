using Intership.Abstracts.Logic;
using Intership.Abstracts.Unity.Logic;
using System;
using Unity;

namespace Intership.Unity
{
    public class UnityLogic : IUnityLogic
    {
        private UnityContainer _container;

        public IClientLogic ClientLogic
        {
            get
            {
                if (!_container.IsRegistered<IClientLogic>())
                    _container.RegisterType<IClientLogic>();
                
                return _container.Resolve<IClientLogic>();
            }
        }
    }
}
