using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigFramework.ThickClient.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Via v = new Via();

            v.test(t => Enter.TheValue(""));
            Enter.TheValue("True").Into(new object());
            //v.test(string2bool<bool>.instance);
            Assert.IsNotNull(v.function);
        }
    }

    public class Via
    {
        public Func<string, object > function;

        public void test(Func<string, object> c )
        {
            function = c;
        }

        public bool funcinstance(string arg)
        {
            throw new NotImplementedException();
        }
    }

    public class Enter  : TargetableAction<EnterValue>
    {
        public static Enter TheValue(string value)
        {
            return new Enter(value);
        }

        private Enter(string str):base(t=> new EnterValue(str,t))
        {

        }

      
    }

    public class EnterValue :TargetedAction 
    {
        /// <summary>
        /// Gets the value to enter
        /// </summary>
        public string Value { get; }
        /// <summary>
        /// Gets the action's name
        /// </summary>
        public   string Name => $"Enter the value '{Value}' into '{Target.ToString()}'";

        /// <summary>
        /// Creates a new instance of <see cref="EnterValue"/>
        /// </summary>
        /// <param name="value">The value to enter</param>
        /// <param name="target">The target on which the value is entered</param>
        public EnterValue(string value, object target)
            : base(target)
        {
            Value = value;
        }

        /// <summary>
        /// Enter the value
        /// </summary>        
        /// <param name="actor"></param>
        /// <param name="element"></param>
        //protected override void ExecuteAction(IActor actor, IWebElement element)
        //{
        //    element.SendKeys(Value);
        //}

        /// <summary>
        /// Returns the action's name
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"Enter the value '{Value}' into '{Target.ToString()}'";
    }

    public abstract class TargetableAction<TAction> 
    {
        /// <summary>
        /// Creates a new instance of <see cref="TargetableAction{TAction}"/>
        /// </summary>
        /// <param name="buildAction">A function used to build a new instance of the derived class</param>
        protected TargetableAction(Func<object, TAction> buildAction)
        {
            BuildAction = buildAction;
        }

        /// <summary>
        /// Gets the build action
        /// </summary>
        public Func<object, TAction> BuildAction { get; }

        /// <summary>
        /// Creates a new action which will be performed on the given target
        /// </summary>
        /// <param name="target">The target to perform the action on</param>
        /// <returns>A new action</returns>
        public TAction Into(object target)
        {
            return BuildAction(target);
        }
    }


    public abstract class TargetedAction 
    {
        /// <summary>
        /// Gets the target into which the action is executed
        /// </summary>
        public object Target { get; }

        /// <summary>
        /// Creates a new instance of <see cref="TargetedAction"/>
        /// </summary>
        /// <param name="target">The target into which the action is executed</param>
        protected TargetedAction(object  target)
        {
            Target = target;
        }

        /// <summary>
        /// Execute the action
        /// </summary>
        /// <param name="actor"></param>
        /// <param name="ability"></param>
        //protected override void ExecuteWhen(IActor actor, WebBrowser ability)
        //{
        //    var element = Target.ResolveFor(ability.Driver);
        //    ExecuteAction(actor, element);
        //}

        /// <summary>
        /// Execute the action
        /// </summary>        
        /// <param name="actor"></param>
        /// <param name="element"></param>
        //protected abstract void ExecuteAction(IActor actor, IWebElement element);
    }
}
