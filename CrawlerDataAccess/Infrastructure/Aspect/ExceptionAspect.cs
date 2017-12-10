using CrawlerDataAccess.Infrastructure.Helpers;
using Newtonsoft.Json;
using PostSharp.Aspects;
using PostSharp.Aspects.Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDataAccess.Infrastructure.Aspect
{
    [Serializable]
    public class LogAspect : OnMethodBoundaryAspect
    {
        public override void OnSuccess(MethodExecutionArgs args)
        {
            //var argumnts = args.Method.GetParameters().Select((p, i) => new { Name = p.Name, Value = args.Arguments[i] });
            var parameters = JsonConvert.SerializeObject(args.Arguments.ToArray());
            //if (args.Method.ToString().Substring(0, 10) != "Void .ctor")
            //Logger.Info(args.Method.DeclaringType.FullName, args.Method.ToString(), parameters, "Method executed successfully");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            base.OnExit(args);
        }
    }

    [Serializable]
    [AspectTypeDependency(AspectDependencyAction.Order,
                          AspectDependencyPosition.After, typeof(LogAspect))]
    public class RunInTransactionAspect : OnMethodBoundaryAspect
    {

        public override void OnEntry(MethodExecutionArgs args)
        {
            base.OnEntry(args);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            var lclargs = args.Method.GetParameters().ToList();
            var argumnts = args.Method.GetParameters().Select((p, i) => new { Name = p.Name, Value = args.Arguments[i] });
            var parameters = JsonConvert.SerializeObject(args.Arguments.ToList());
            //Logger.Info(args.Method.DeclaringType.FullName, args.Method.ToString(), parameters, "Method executed successfully");
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            base.OnExit(args);
        }
    }

    [Serializable]
    public class ExceptionAspect : OnExceptionAspect
    {
        public override void OnException(MethodExecutionArgs args)
        {
            var parameters = JsonConvert.SerializeObject(args.Arguments.ToList());
            //Logger.Error(args.Method.DeclaringType.FullName, args.Method.ToString(), parameters, "Exception Ocurred", args.Exception);
            //  args.FlowBehavior = FlowBehavior.Continue;
            //   base.OnException(args);
        }
    }
}
