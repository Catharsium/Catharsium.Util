using Catharsium.Util.Testing.Interfaces;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Catharsium.Util.Testing.Substitutes
{
    public class SubstituteService : ISubstituteService
    {
        private readonly IEnumerable<ISubstituteFactory> substituteHandlers;


        public SubstituteService(IEnumerable<ISubstituteFactory> substituteHandlers)
        {
            this.substituteHandlers = substituteHandlers;
        }


        public object GetSubstitute(Type type)
        {
            if (type.GetTypeInfo().IsInterface) {
                return Substitute.For(new[] {type}, new object[0]);
            }

            if (type == typeof(Guid)) {
                return Guid.NewGuid();
            }

            foreach (var substituteHandler in this.substituteHandlers) {
                if (!substituteHandler.CanCreateFor(type)) {
                    continue;
                }

                var method = substituteHandler.GetType().GetMethod("CreateSubstitute");
                method = method?.MakeGenericMethod(type);
                return method?.Invoke(substituteHandler, new object[] {type});
            }

            return null;
        }
    }
}