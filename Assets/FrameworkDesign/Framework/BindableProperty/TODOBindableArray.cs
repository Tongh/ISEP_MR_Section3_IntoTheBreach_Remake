using System;
using System.Collections.Generic;

namespace FrameworkDesign
{
    public class TODOBindableArray<T>: List<T>
    {
        public Action<int, T> mOnValueChanged = (k, v) => { };

        public void SetListValueAt(int index, T value)
        {

        }

        public IUnRegister RegisterOnValueChanged(Action<int, T> onValueChanged)
        {
            mOnValueChanged += onValueChanged;

            return new BindableArrayUnRegister<T>()
            {
                BindableArray = this,
                OnValueChanged = onValueChanged
            };
        }

        public void UnReigsterOnValueChanged(Action<int, T> onValueChanged)
        {
            mOnValueChanged -= onValueChanged;
        }
    }

    public class BindableArrayUnRegister<T> : IUnRegister
    {
        public TODOBindableArray<T> BindableArray { get; set; }

        public Action<int, T> OnValueChanged { get; set; }

        public void UnRegister()
        {
            BindableArray.UnReigsterOnValueChanged(OnValueChanged);
        }
    }
}
