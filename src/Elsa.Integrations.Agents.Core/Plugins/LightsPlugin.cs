using System.ComponentModel;
using JetBrains.Annotations;
using Microsoft.SemanticKernel;

namespace Elsa.Agents.Plugins;

[Description("Manages lights and their states")]
[UsedImplicitly]
public class LightsPlugin
{
    private readonly List<LightModel> lights = new()
    {
        new LightModel { Id = 1, Name = "Table Lamp", IsOn = false },
        new LightModel { Id = 2, Name = "Porch Light", IsOn = false },
        new LightModel { Id = 3, Name = "Chandelier", IsOn = true }
    };

    [KernelFunction("get_lights")]
    [Description("Gets a list of lights and their current states.")]
    [return: Description("A list of lights with their states")]
    public async Task<List<LightModel>> GetLightsAsync()
    {
        return lights;
    }

    [KernelFunction("change_state")]
    [Description("Changes the state of a light, such as turning it on or off.")]
    [return: Description("The updated light state; returns null if the light does not exist")]
    public async Task<LightModel?> ChangeStateAsync(
        [Description("The ID of the light to change the state of")] int id,
        [Description("The new state of the light (true for on, false for off)")] bool isOn)
    {
        var light = lights.FirstOrDefault(l => l.Id == id);

        if (light == null)
        {
            return null;
        }

        light.IsOn = isOn;

        return light;
    }

    [KernelFunction("add_light")]
    [Description("Adds a new light to the list.")]
    [return: Description("The added light")]
    public async Task<LightModel> AddLightAsync(
        [Description("The name of the new light")] string name,
        [Description("The initial state of the new light (true for on, false for off)")] bool isOn)
    {
        var newLight = new LightModel
        {
            Id = lights.Any() ? lights.Max(l => l.Id) + 1 : 1,
            Name = name,
            IsOn = isOn
        };

        lights.Add(newLight);
        return newLight;
    }

    [KernelFunction("remove_light")]
    [Description("Removes a light from the list.")]
    [return: Description("The removed light; returns null if the light does not exist")]
    public async Task<LightModel?> RemoveLightAsync(
        [Description("The ID of the light to remove")] int id)
    {
        var light = lights.FirstOrDefault(l => l.Id == id);

        if (light == null)
        {
            return null;
        }

        lights.Remove(light);
        return light;
    }

    public class LightModel
    {
        [Description("The unique identifier of the light")]
        public int Id { get; set; }

        [Description("The name of the light")]
        public string Name { get; set; }

        [Description("The current state of the light (true for on, false for off)")]
        public bool IsOn { get; set; }
    }
}

[UsedImplicitly]
public class LightsPluginProvider : PluginProvider
{
    public override IEnumerable<PluginDescriptor> GetPlugins()
    {
        yield return PluginDescriptor.From<LightsPlugin>();
    }
}
