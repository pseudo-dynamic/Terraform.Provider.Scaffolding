using Microsoft.AspNetCore.Hosting;
using PseudoDynamic.Terraform.Plugin;
using PseudoDynamic.Terraform.Plugin.Schema;
using PseudoDynamic.Terraform.Plugin.Sdk;

const string providerName = "registry.terraform.io/pseudo-dynamic/scaffolding";

var webHost = new WebHostBuilder()
    .UseTerraformPluginServer(IPluginServerSpecification.NewProtocolV5()
        .UseProvider(providerName, provider =>
        {
            provider.AddResource<ResourceImpl>();
            provider.AddDataSource<DataSourceImpl>();
        }))
    .Build();

await webHost.RunAsync();

[Block]
class ResourceSchema
{
    /// <summary>
    /// Same attribute.
    /// The description is taken from this XML comment.
    /// Used by Terraform documentation generator and Terraform language server.
    /// </summary>
    public string? SampleAttribute { get; set; } // Is implicit optional because nullable

    /// <summary>
    /// Same attribute.
    /// The description is taken from this XML comment.
    /// Used by Terraform documentation generator and Terraform language server.
    /// </summary>
    [Computed]
    public TerraformValue<string> ComputedAttribute { get; set; } = null!; // Is implicit required because string is non-nullable
}

/* If using constructor, the constructor parameters are resolved by service provider. */
internal class ResourceImpl : Resource<ResourceSchema>
{
    public override string TypeName => "my_resource";

    public override Task Plan(IPlanContext<ResourceSchema, object> context)
    {
        if (context.HasPlan(out var planContext))
        {
            planContext.Plan.ComputedAttribute = TerraformValue.OfUnknown<string>();
        }

        return context.CompletedTask;
    }

    public override Task Apply(IApplyContext<ResourceSchema, object> context)
    {
        if (context.IsCreating(out var createContext))
        {
            createContext.Plan.ComputedAttribute = "Hello from C# (Creating)";
        }

        if (context.IsUpdating(out var updateContext))
        {
            createContext.Plan.ComputedAttribute = "Hello from C# (Updating)";
        }

        return context.CompletedTask;
    }
}

[Block]
internal class DataSourceSchema
{
    /// <summary>
    /// Same attribute.
    /// The description is taken from this XML comment.
    /// Used by Terraform documentation generator and Terraform language server.
    /// </summary>
    public string SampleAttribute { get; set; } = null!; // Is implicit required because non-nullable

    /// <summary>
    /// Same attribute.
    /// The description is taken from this XML comment.
    /// Used by Terraform documentation generator and Terraform language server.
    /// </summary>
    [Computed]
    public int ComputedAttribute { get; set; } // Is implicit required because int is non-nullable
}

/* If using constructor, the constructor parameters are resolved by service provider. */
internal class DataSourceImpl : DataSource<DataSourceSchema>
{
    public override string TypeName => "my_data_source";

    public override Task Read(IReadContext<DataSourceSchema, object> context)
    {
        context.State.ComputedAttribute = 10;
        return context.CompletedTask;
    }
}