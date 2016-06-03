using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyCucumber
{
    public class Feature
    {
        private readonly string description;
        private readonly string name;
        private readonly List<Statement> statements = new List<Statement>();

        public Feature()
            : this("Untitled", null)
        { }

        /// <summary>
        /// Cotr
        /// </summary>
        /// <param name="name">Name of the function</param>
        /// <param name="description">Describe your feature</param>
        public Feature(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public Feature WithBackground(Feature background)
        {
            this.statements.AddRange(background.statements);
            return this;
        }

        public Feature Given(string statementString)
        {
            this.statements.Add(new Statement(statementString));
            return this;
        }

        public Feature And(string statementString)
        {
            return Given(statementString);
        }

        public Feature When(string statementString)
        {
            return Given(statementString);
        }

        public Feature Then(string statementString)
        {
            return Given(statementString);
        }

        public Feature Except(string statementString)
        {
            return Given(statementString);
        }

        public void Using<T>(string methodName=null)
        {
            Using(typeof(T), methodName);
        }

        public void Using(Type delegateType, string methodName)
        {
            Using(Activator.CreateInstance(delegateType), methodName);
        }

        /// <summary>
        /// Using the <paramref name="instance"/> provided to invoke the Do member.
        /// </summary>
        /// <param name="delegateType"></param>
        /// <param name="instance"></param>
        /// <param name="methodName">Name of the method to invoke</param>
        public void Using(object instance, string methodName=null)
        {
            // get the method to call
            var delegateType = instance.GetType();
            methodName = methodName ?? "Do";
            var method = delegateType.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
            if (method == null) throw new MissingMethodException(delegateType.FullName, methodName);

            // now get all the parameters
            var methodParameters = method.GetParameters().Select(x => x.ParameterType).ToArray();
            var actualParameters = statements.SelectMany(x => x.Tokens).ToArray();
            var preparedParameters = actualParameters.CastAppropriately(methodParameters).ToArray();
            if (methodParameters.Length != actualParameters.Length) throw new IndexOutOfRangeException(string.Format("Feature {0} was expecting {1:N0} parameters, but implementaton {2} had {3:N0}", name, actualParameters, delegateType.Name, methodParameters));

            // invoke
            method.Invoke(instance, preparedParameters);
        }
    }
}