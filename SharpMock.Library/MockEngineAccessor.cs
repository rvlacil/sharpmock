namespace SharpMock.Library
{
    public static class MockEngineAccessor
    {
        public static MockHolder<I> Do<I>(this IMock<I> mock)
        {
            return new MockHolder<I>(mock);
        }
    }
}
