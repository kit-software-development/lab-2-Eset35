using System;
using Practice.Common;
using Practice.Organization;

namespace Practice.HR
{
    /// <summary>
    ///     Класс-фабрика, позволяющий получать экземпляры типов,
    ///     инкапсулированных на уровне библиотеки.
    /// </summary>
    public static class Builders
    {
        /// <summary>
        ///     Возвращает экземпляр "Строителя" клиентов.
        /// </summary>
        /// <returns>
        ///     Экземпляр типа IClientBuilder.
        /// </returns>

        private static IClientBuilder _clientBuilder;
        private static IEmployeeBuilder _employeeBuilder;

        public static IClientBuilder ClientBuilder()
        {
            /*
             * TODO #6: Реализовать фабричный метод ClientBuilder класса Builders
             */

            if (_clientBuilder == null)
                _clientBuilder = new ClientBuilder();

             return _clientBuilder;
        }

        /// <summary>
        ///     Возвращает экземпляр "Строителя" сотудников.
        /// </summary>
        /// <returns>
        ///     Возвращает экземпляр типа IEmployeeBuilder.
        /// </returns>
        public static IEmployeeBuilder EmployeeBuilder()
        {
            /*
             * TODO #7: Реализовать фабричный метод EmployeeBuilder класса Builders
             */
            if (_employeeBuilder == null)
                _employeeBuilder = new EmployeeBuilder();

            return _employeeBuilder;
        }

    }

    internal class EmployeeBuilder : IEmployeeBuilder
    {
        private IName _name;

        private IDepartment _department;

        public IEmployee Build()
        {
            IEmployee employee = new Employee();
            employee.Name = _name;
            employee.Department = _department;

            return employee;
        }

        public IEmployeeBuilder Department(IDepartment department)
        {
            this._department = department;
            return this;
        }

        public IEmployeeBuilder Department(string department)
        {
            return Department(new Department { Name = department });
        }

        public IEmployeeBuilder Name(IName name)
        {
            this._name = name;
            return this;
        }

        public IEmployeeBuilder Name(string name, string surname, string patronymic)
        {
            return Name(new Name { FirstName = name, Surname = surname, Patronymic = patronymic });
        }
    }

    internal class ClientBuilder : IClientBuilder
    {
        private IName _name;
        private float _discount;

        public IClient Build()
        {
            IClient client = new Client();
            client.Name = _name;
            client.Discount = _discount;

            return client;
        }

        public IClientBuilder Discount(float discount)
        {
            this._discount = discount;
            return this;
        }

        public IClientBuilder Name(IName name)
        {
            this._name = name;
            return this;
        }

        public IClientBuilder Name(string name, string surname, string patronymic)
        {
            return Name(new Name { FirstName = name, Surname = surname, Patronymic = patronymic });
        }
    }
}
