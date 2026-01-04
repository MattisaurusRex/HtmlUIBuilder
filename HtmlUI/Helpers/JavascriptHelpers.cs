using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using HtmlUI.Models;
using HtmlUI.Models.Buttons;
using HtmlUI.Models.Details;
using HtmlUI.Models.Entities;

namespace HtmlUI.Helpers
{
    public static class JavascriptHelpers
    {

        public static IHtmlContent DataTableViewBtn_Click(this IHtmlHelper helper, IEnumerable<IEntityBase> entities)
        {
            var type = entities.First().GetType().Name.Replace("Entity","");

            var id = "3"; //"$(this).val();"
            var returnJs = new HtmlString($"<script> $(\".viewBtn\").on('click', function() {{ var {type}Id = {id}; var url =  '/{type}s?{type}Id=' + {type}Id; window.location.href = url;}}); </script>");
            return returnJs;
        }

        public static IHtmlContent DataTablesForDetail(this IHtmlHelper helper, IDetailHeader detailHeader)
        {
            var returnString = "<script> $(document).ready(function () {  ";
            
            foreach (var tab in detailHeader.DetailTabItems) //?
            {
                var detailProps = tab.GetType().GetProperties();

                foreach (var prop in detailProps)
                {
                    if (prop.PropertyType.Name.StartsWith("IEnumerable`1"))
                    {                        
                        var itemType = prop.Name.Replace("Entity", "");
                        returnString += $"$('#{itemType}Table').DataTable({{ searching: false, scrollY:'100%', scrollX: true, paging: false, info: false }}); ";                                                    
                    }
                }                               
            }
            
            return new HtmlString(returnString + "});</script>");
        }

        public static IHtmlContent DataTablesForSearch(this IHtmlHelper helper)
        {
            var returnString = "<script> $(document).ready(function () { $('#searchResultTable').DataTable({ searching: true, scrollY:400, scrollX: true }); ";          
            return new HtmlString(returnString + "});</script>");
        }

        public static IHtmlContent HeaderButtons_Click(this IHtmlHelper helper, IDetailHeader form)
        {
            var returnString = "<script>  ";

            var props = form.GetType().GetProperties();
            var btnRows = props.Where(x => x.PropertyType.Name == "ButtonRow");
            var btnRowsList = new List<ButtonRow>();
            foreach (var btnRow in btnRows)
            {
                var btnRowValue = (ButtonRow)btnRow.GetValue(form);
                btnRowsList.Add(btnRowValue);
            }
            foreach (var btnRow in btnRowsList)
            {
                foreach (var btn in btnRow.Buttons)
                {
                    var btnClass = btnRow.ButtonType + "Btn ";
                    var btnName = btn.Name.Replace(" ", "");
                    returnString += $"$(\"#{btnName}{btnClass}\").on('click', function() {{ {btn.Action} }}); ";                    
                }
            }
            return new HtmlString(returnString + "});</script>");
        }
    }
}
