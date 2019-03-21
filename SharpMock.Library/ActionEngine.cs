
using SharpMock.Library.Action;
using SharpMock.Library.Matchers;

namespace SharpMock.Library
{
    public class ActionEngine : ActionEngineBase, IActionEngine
    {
        public ActionEngine(string methodName) : base(methodName) { }
    
        public void Execute()
        {
            Execute((m, o) => ((MultiArgMatcher) m).Match(o),
                x => ((MultiArgAction) x).Execute());
        }
    
        public IActionSetup Setup()
        {
            var setup = new ActionSetup();
            _activeSetups.Add(setup);
    
            return setup;
        }
    }
    
    public class ActionEngine<T1> : ActionEngineBase, IActionEngine<T1>
    {
        public ActionEngine(string methodName) : base(methodName) { }
    
        public void Execute(T1 arg1)
        {
            Execute((m, o) => ((MultiArgMatcher<T1>) m).Match(arg1, o),
                x => ((MultiArgAction<T1>) x).Execute(arg1));
        }
    
        public IActionSetup<T1> Setup()
        {
            var setup = new ActionSetup<T1>();
            _activeSetups.Add(setup);
    
            return setup;
        }
    }
    
    public class ActionEngine<T1, T2> : ActionEngineBase, IActionEngine<T1, T2>
    {
        public ActionEngine(string methodName) : base(methodName) { }
    
        public void Execute(T1 arg1, T2 arg2)
        {
            Execute((m, o) => ((MultiArgMatcher<T1, T2>) m).Match(arg1, arg2, o),
                x => ((MultiArgAction<T1, T2>) x).Execute(arg1, arg2));
        }
    
        public IActionSetup<T1, T2> Setup()
        {
            var setup = new ActionSetup<T1, T2>();
            _activeSetups.Add(setup);
    
            return setup;
        }
    }
    
}
