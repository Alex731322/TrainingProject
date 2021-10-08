using JavaScriptEngineSwitcher.Core;
using JavaScriptEngineSwitcher.V8;
using React;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TrainingProject.ReactConfig), "Configure")]

namespace TrainingProject
{
	public static class ReactConfig
	{
		public static void Configure()
		{
			JavaScriptEngineSwitcher.Core.JsEngineSwitcher.Current.DefaultEngineName = V8JsEngine.EngineName;
			JavaScriptEngineSwitcher.Core.JsEngineSwitcher.Current.EngineFactories.AddV8();
		}
	}
}