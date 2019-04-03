namespace SharpMock.Library
{
    public static class MockEngineAccessor
    {
        public static MockHolder<I> Add<I>(this IMock<I> mock)
        {
            return new MockHolder<I>(mock);
        }
    }
}
