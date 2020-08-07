using Catharsium.Util.Interfaces;
using Catharsium.Util.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Loader;

namespace Catharsium.Util.IO.Types
{
    public class TypesLoader : ITypesLoader
    {
        private readonly ITypesRetriever typesRetriever;
        private readonly IFileFactory fileFactory;


        public TypesLoader(ITypesRetriever typesRetriever, IFileFactory fileFactory)
        {
            this.typesRetriever = typesRetriever;
            this.fileFactory = fileFactory;
        }


        public IEnumerable<Type> Load<T>(string folder)
        {
            var pluginsDirectory = this.fileFactory.CreateDirectory(folder);
            var assemblyFiles = pluginsDirectory.GetFiles("*.dll");
            var result = new List<Type>();
            foreach (var assemblyFile in assemblyFiles) {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyFile.FullName);
                result.AddRange(this.typesRetriever.GetImplementationsFor<T>(assembly));
            }

            return result;
        }
    }
}