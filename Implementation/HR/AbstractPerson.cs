using System;
using Practice.Common;
using Practice.HR.Events;

namespace Practice.HR
{
    /// <summary>
    ///     Абстрактная база для описания конкретных реализаций типа "Человек".
    ///     Используется для дальнейшего наследования.
    /// </summary>
    internal abstract class AbstractPerson : IPerson
    {
        /*internal Organization.Department Department
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
                throw new System.NotImplementedException();
            }
        }

        internal Common.Name Name
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
                throw new System.NotImplementedException();
            }
        }*/

        /*
        * TODO #3: Реализуйте интерфейс IPerson для класса AbstractPerson
        */
        private IName _name;

        public IName Name
        {
            get => _name;

            set
            {
                NameChange?.Invoke(this, new ValueChangeEventArgs<IName>(_name));
                _name = value;
            }
        }

        public event EventHandler<ValueChangeEventArgs<IName>> NameChange;
    }
}
