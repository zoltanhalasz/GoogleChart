using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.DataTable.Net.Wrapper;
using Google.DataTable.Net.Wrapper.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GoogleChart.Pages
{


    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }

        public ActionResult OnGetChartData()
        {
            Random rnd = new Random();
            var pizza = new[]
                {
                new {Name = "Mushrooms", Count = rnd.Next(1, 13)},
                new {Name = "Onions", Count = rnd.Next(1, 13)},
                new {Name = "Olives", Count = rnd.Next(1, 13)},
                new {Name = "Zucchini", Count = rnd.Next(1, 13)},
                new {Name = "Pepperoni", Count = rnd.Next(1, 13)}
            };

            var json = pizza.ToGoogleDataTable()
                    .NewColumn(new Column(ColumnType.String, "Topping"), x => x.Name)
                    .NewColumn(new Column(ColumnType.Number, "Slices"), x => x.Count)
                    .Build()
                    .GetJson();

            return Content(json);
        }
    }
}
