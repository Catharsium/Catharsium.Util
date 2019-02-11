﻿namespace Catharsium.Util.Testing.Tests._Mocks
{
    public class MockObject
    {
        public readonly IMockInterface1 InterfaceDependency1;
        public readonly IMockInterface2 InterfaceDependency2;
        public readonly string StringDependency;


        public MockObject(IMockInterface1 mockInterface1)
        {
            this.InterfaceDependency1 = mockInterface1;
        }


        public MockObject(IMockInterface1 mockInterface1, IMockInterface2 mockInterface2)
            : this(mockInterface1)
        {
            this.InterfaceDependency2 = mockInterface2;
        }


        public MockObject(IMockInterface1 mockInterface1, IMockInterface2 mockInterface2, string mockString)
           : this(mockInterface1, mockInterface2)
        {
            this.StringDependency = mockString;
        }
    }
}