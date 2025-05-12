using Microsoft.AspNetCore.Components;

namespace TutorIA.Components
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
    }
}

