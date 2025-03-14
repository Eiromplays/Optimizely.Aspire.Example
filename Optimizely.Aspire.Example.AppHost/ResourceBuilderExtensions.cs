namespace Optimizely.Aspire.Example.AppHost;

public static class ResourceBuilderExtensions
{
    public static IResourceBuilder<T> WithBuildSecret<T>(this IResourceBuilder<T> builder, string name, ParameterResource parameterResource) where T : ContainerResource
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentNullException.ThrowIfNull(parameterResource);

        var annotation = builder.Resource.Annotations.OfType<DockerfileBuildAnnotation>().SingleOrDefault();

        if (annotation is null)
        {
            throw new InvalidOperationException("The resource does not have a Dockerfile build annotation. Call WithDockerfile before calling WithSecretBuildArg.");
        }

        annotation.BuildSecrets[name] = parameterResource;

        return builder;
    }
}