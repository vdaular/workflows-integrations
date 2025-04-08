using Microsoft.SemanticKernel;

namespace Elsa.Agents;

public class OllamaChatCompletion : IAgentServiceProvider
{
    public string Name => "OllamaChatCompletion";
    public void ConfigureKernel(KernelBuilderContext context)
    {
        var modelId = (string)context.ServiceConfig.Settings["ModelId"];
        var url = (string)context.ServiceConfig.Settings["Url"];
        var apiKey = context.GetApiKey();
#pragma warning disable SKEXP0010 // Este tipo se incluye solo con fines de evaluación y está sujeto a cambios o a que se elimine en próximas actualizaciones. Suprima este diagnóstico para continuar.
        context.KernelBuilder.AddOpenAIChatCompletion(modelId: modelId, apiKey: apiKey, endpoint: new Uri(url));
#pragma warning restore SKEXP0010 // Este tipo se incluye solo con fines de evaluación y está sujeto a cambios o a que se elimine en próximas actualizaciones. Suprima este diagnóstico para continuar.
    }
}