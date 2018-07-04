using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace PersonalHealthStats.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Dictionary<string, object> Dependencies { get; protected set; }
        protected virtual void InitDependencies()
        {
            Dependencies = new Dictionary<string, object>();
        }
        protected virtual void UpdateDependencies(string PropertyName)
        {
            if (Dependencies.ContainsKey(PropertyName))
            {
                var value = Dependencies[PropertyName];
                if (value is string[] dependencyNames)
                {
                    foreach (var str in dependencyNames)
                    {
                        NotifyPropertyChanged(str);
                    }
                }
                else if (value is string str)
                {
                    NotifyPropertyChanged(str);
                }
            }
            else
                Debug.WriteLine($"Dependencies are not defined for {PropertyName}");

        }

        protected void Set<SetType>(ref SetType target, SetType value, string PropertyName)
        {
            if (target == null)
            {
                target = value;
                NotifyPropertyChanged(PropertyName);
                UpdateDependencies(PropertyName);

            }
            else if (!target.Equals(value))
            {
                target = value;
                NotifyPropertyChanged(PropertyName);
                UpdateDependencies(PropertyName);
            }

        }

        protected void NotifyPropertyChanged(string PropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));

    }
}
