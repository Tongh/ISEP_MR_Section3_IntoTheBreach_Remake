using System;
using System.Collections.Generic;

namespace FrameworkDesign
{
    public interface IArchitecture
    {
        void RegisterSystem<T>(T system) where T : ISystem;

        void RegisterModel<T>(T model) where T : IModel;

        void RegisterUtility<T>(T utility);

        T GetSystem<T>() where T : class, ISystem;

        T GetModel<T>() where T : class, IModel;

        T GetUtility<T>() where T : class, IUtility;

        void SendCommand<T>() where T : ICommand, new();

        void SendCommand<T>(T command) where T : ICommand;

        void SendEvent<T>() where T : new();

        void SendEvent<T>(T e);

        IUnRegister RegisterEvent<T>(Action<T> onEvent);

        void UnRegisterEvent<T>(Action<T> onEvent);
    }

    public abstract class Architecture<T> : IArchitecture where T : Architecture<T>, new()
    {
        private bool mInited = false;
        private List<ISystem> mSystems = new List<ISystem>();

        public void RegisterSystem<Type>(Type system) where Type : ISystem
        {
            system.SetArchitecture(this);
            mContainer.Register<Type>(system);

            if (mInited)
            {
                system.Init();
            }
            else
            {
                mSystems.Add(system);
            }
        }

        private List<IModel> mModels = new List<IModel>();

        public void RegisterModel<Type>(Type model) where Type : IModel
        {
            model.SetArchitecture(this);
            mContainer.Register<Type>(model);

            if (mInited)
            {
                model.Init();
            }
            else
            {
                mModels.Add(model);
            }
        }

        #region
        public static Action<T> OnRegisterPatch = architecture => { };
        private static T mArchitecture = null;

        public static IArchitecture Interface
        {
            get
            {
                if (mArchitecture == null)
                {
                    MakeSureContainer();
                }
                return mArchitecture;
            }
        }

        static void MakeSureContainer()
        {
            if (mArchitecture == null)
            {
                mArchitecture = new T();
                mArchitecture.Init();

                OnRegisterPatch?.Invoke(mArchitecture);

                foreach (var architectureModel in mArchitecture.mModels)
                {
                    architectureModel.Init();
                }
                mArchitecture.mModels.Clear();

                foreach (var architectureSystem in mArchitecture.mSystems)
                {
                    architectureSystem.Init();
                }
                mArchitecture.mSystems.Clear();

                mArchitecture.mInited = true;
            }
        }
        #endregion

        private IOCContainer mContainer = new IOCContainer();
        protected abstract void Init();

        public static void Register<Type>(Type instance)
        {
            MakeSureContainer();
            mArchitecture.mContainer.Register<Type>(instance);
        }

        //public static Type Get<Type>() where Type : class
        //{
        //    MakeSureContainer();
        //    return mArchitecture.mContainer.Get<Type>();
        //}

        public void RegisterUtility<Type>(Type utility)
        {
            mContainer.Register<Type>(utility);
        }

        public Type GetSystem<Type>() where Type : class, ISystem
        {
            return mContainer.Get<Type>();
        }

        public Type GetModel<Type>() where Type : class, IModel
        {
            return mContainer.Get<Type>();
        }

        public Type GetUtility<Type>() where Type : class, IUtility
        {
            return mContainer.Get<Type>();
        }

        public void SendCommand<Type>() where Type : ICommand, new()
        {
            var command = new Type();
            command.SetArchitecture(this);
            command.Execute();
        }

        public void SendCommand<Type>(Type command) where Type : ICommand
        {
            command.SetArchitecture(this);
            command.Execute();
        }

        private ITypeEventSystem mTypeEventSystem = new TypeEventSystem();

        public void SendEvent<Type>() where Type : new()
        {
            mTypeEventSystem.Send<Type>();
        }

        public void SendEvent<Type>(Type e)
        {
            mTypeEventSystem.Send<Type>(e);
        }

        public IUnRegister RegisterEvent<Type>(Action<Type> onEvent)
        {
            return mTypeEventSystem.Register<Type>(onEvent);
        }

        public void UnRegisterEvent<Type>(Action<Type> onEvent)
        {
            mTypeEventSystem.UnRegister<Type>(onEvent);
        }
    }
}
