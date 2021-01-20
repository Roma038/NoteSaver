using React;
using JavaScriptEngineSwitcher.Core;
using JavaScriptEngineSwitcher.V8;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ReactApp.ReactConfig), "Configure")]

namespace ReactApp
{
    public static class ReactConfig
    {
        public static void Configure()
        {
            // Регистрация движка V8
            JsEngineSwitcher.Current.DefaultEngineName = V8JsEngine.EngineName;
            JsEngineSwitcher.Current.EngineFactories.AddV8();
        }
    }
}