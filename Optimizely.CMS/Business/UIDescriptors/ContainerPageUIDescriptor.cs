using Optimizely.CMS.Models.Pages;
using EPiServer.Shell;

namespace Optimizely.CMS.Business.UIDescriptors;

/// <summary>
/// Describes how the UI should appear for <see cref="ContainerPage"/> content.
/// </summary>
[UIDescriptorRegistration]
public class ContainerPageUIDescriptor : UIDescriptor<ContainerPage>
{
    public ContainerPageUIDescriptor()
        : base(ContentTypeCssClassNames.Container)
    {
        DefaultView = CmsViewNames.AllPropertiesView;
    }
}