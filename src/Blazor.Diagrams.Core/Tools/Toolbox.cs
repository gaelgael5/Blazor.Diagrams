using Blazor.Diagrams.Core.Serializations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blazor.Diagrams.Core.Tools
{

    public class Toolbox
    {

        public Guid Uuid { get; set; }


        public ToolboxItem GetByUuid(string uuid)
        {
            return GetByUuid(new Guid(uuid));
        }

        public ToolboxItem GetByUuid(Guid uuid)
        {
            return this._items.FirstOrDefault(c => c.Uuid == uuid);
        }

        public IEnumerable<ToolboxCategory> Categories() => this._categories.Values;

        public IEnumerable<ToolboxItem> GetByCategory(ToolboxCategory category) => this._items.Where(c => c.CategoryName == category.Name);

        public Toolbox Add(params ToolboxCategory[] categories)
        {
            
            foreach (var category in categories)
                this._categories.Add(category.Name, category);

            return this;
        }

        public Toolbox Add(params ToolboxItem[] items)
        {
            this._items.AddRange(items);
            return this;
        }

        private Dictionary<string, ToolboxCategory> _categories = new Dictionary<string, ToolboxCategory>();
        private List<ToolboxItem> _items = new List<ToolboxItem>();

    }

}
