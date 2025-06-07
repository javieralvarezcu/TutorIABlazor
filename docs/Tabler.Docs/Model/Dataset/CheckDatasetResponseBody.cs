using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Tabler.Docs.Model.Dataset
{
    public class CheckDatasetResponseBody
    {
        public bool exists { get; set; }
        public string message { get; set; }
        public JsonElement data { get; set; } // flexible
        public List<Datum>? ParsedData { get; set; } // datos realmente útiles
    }

    public class Datum
    {
        public int order_id { get; set; }
        public int user_id { get; set; }
        public string skill_name { get; set; }
        public int correct { get; set; }
        public string item_id { get; set; }
        public string subject_id { get; set; }
    }
}
