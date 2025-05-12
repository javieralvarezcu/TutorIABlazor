using Microsoft.AspNetCore.Components;
using TutorIA.Components.Tables;

namespace TutorIA.Components.Tables
{
    public class TableHeaderToolsBase<TableItem> : ComponentBase
    {
        [CascadingParameter(Name = "Table")] public ITable<TableItem> Table { get; set; }

    }
}
