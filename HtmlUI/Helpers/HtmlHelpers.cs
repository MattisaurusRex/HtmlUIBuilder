using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using HtmlUI.Models;
using HtmlUI.Models.Buttons;
using HtmlUI.Models.Details;
using HtmlUI.Models.Entities;
using HtmlUI.Models.Search;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace HtmlUI.Helpers
{
    public static class HtmlHelpers
    {
        public static HtmlString NavbarHeader(this IHtmlHelper helper, string configMode)
        {
            var colourClass = "navBarLive";
            if (configMode.ToUpper() == "DEBUG")
            {
                colourClass = "navBarDebug";
            }
            return new HtmlString(String.Format(" <nav class=\"navbar navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow {0}\">", colourClass));
        }
        public static HtmlString NavbarFooter(this IHtmlHelper helper, string configMode)
        {
            var colourClass = "navBarFooterLive";
            if (configMode.ToUpper() == "DEBUG")
            {
                colourClass = "navBarFooterDebug";
            }
            return new HtmlString(String.Format(" <footer class=\"{0} text-muted\">", colourClass));
        }

        public static HtmlString NavbarButtons(this IHtmlHelper helper, IEnumerable<string> buttonsList, string configMode)
        {
            var retString = "<div class=\"navbar-collapse btn-group collapse d-sm-inline-flex justify-content-between\"> <ul class=\"navbar-nav flex-grow-1\">";
            var buttonClass = "headerNavButtonLive";
            if (configMode.ToUpper() == "DEBUG")
            {
                buttonClass = "headerNavButtonDebug";
            }
            foreach (var item in buttonsList)
            {
                retString = retString + String.Format("<li class=\"nav-item {0}\"> <a class=\"nav-link \" href=\"/Home/{1}\"><span class=\"headerTextBtn\">{1}</span></a> </li>", buttonClass, item);
            }
            return new HtmlString(retString + "</ul> </div>");
        }

        public static HtmlString NavbarVersionInfo(this IHtmlHelper helper, IEnumerable<string> versionNums)
        {
            var retString = "<div class=\" versionInfo \"> <ul class=\" versionsList \">";

            foreach (var item in versionNums)
            {
                retString = retString + String.Format("<li class=\" \"> <p class=\" versionItem \">{0}</p> </li>", item);
            }
            return new HtmlString(retString + "</ul> </div>");
        }

        public static HtmlString DashboardList(this IHtmlHelper helper, Dictionary<string, string> actionsAndIconsList, string controller = "Home")
        {
            var retString = "<div class=\"dashboardList container\"> <ul class=\"col-md-12\">";

            foreach (var item in actionsAndIconsList)
            {
                retString = retString + String.Format("<li> <a class=\"nav-link dashboardLink col-md-11 col-sm-9\" href=\"/{0}/{1}\"><div class=\"col-md-4 col-sm-2\"><img class=\" icon \" src=\"\\images\\{2}.png\" ></img></div> <p class=\"dashboardLinkText col-md-8 col-sm-10\">{1}</p></a> <div class=\"col-md-1 sm-col-3\"></div> </li>", controller, item.Key, item.Value);
            }
            return new HtmlString(retString + "</ul> </div>");
        }

        public static HtmlString EntityDetailHeader(this IHtmlHelper helper, IDetailHeader detailHeader)
        {            
            var retString = "<div class=\"col-md-12 detailHeader row\">";
            var detailHeaderProps = detailHeader.GetType().GetProperties();
            var btnRows = detailHeaderProps.Where(x => x.PropertyType.Name == "ButtonRow");
            var btnRowsList = new List<ButtonRow>();
            foreach (var btnRow in btnRows)
            {
                var btnRowValue = (ButtonRow)btnRow.GetValue(detailHeader);
                btnRowsList.Add(btnRowValue);
            }
            var inputBtnRows = btnRowsList.Where(x => x.AssociatedInput != "");
            var noOfColumns = detailHeader.headerView.Count() / 2;           
            var columnsWidth = 12 / noOfColumns; 
            var remainder = 12 % noOfColumns;
            var columnCount = 1;
            var i = 0;

            foreach (var headerProp in detailHeader.headerView)
            {                
                var prop = detailHeaderProps.FirstOrDefault(x => x.Name == headerProp[1]);
                var inputType = "text";
                var inputClass = "form-control";
                IEnumerable<ButtonRow> assocBtnRow = new List<ButtonRow>();
                if(prop != null)
                    assocBtnRow = inputBtnRows.Where(x => x.AssociatedInput == prop.Name);
                var btnRowString = "";
                var btnRowDivClass = "";
                if (assocBtnRow.Any())
                {
                    // deal with associated button row
                    btnRowString = CreateHeaderButtonRow(detailHeader, assocBtnRow.FirstOrDefault(), true);
                    btnRowDivClass = "inputWithBtnRow";
                }
                if (i == 2)
                {
                    retString = retString + "</div>";
                    columnCount++;
                    i = 0;
                }
                if (i == 0)
                {
                    if(columnCount == noOfColumns)
                    {
                        columnsWidth = columnsWidth + remainder;
                    }
                    retString = retString + String.Format("<div class=\"detailHeaderColumn col-md-{0} col-sm-{0}\">", columnsWidth);                    
                }

                retString = retString + String.Format("<div class=\"col-md-{0} col-sm-{0} detailHeaderCell \"> ", columnsWidth);                
                var inputValue = prop.GetValue(detailHeader);
                if (prop.Name == "EntityID")
                {
                    retString = retString + String.Format("<div class=\"col-md-12 \"> <label class=\"headerLabel\" >ID#</label> </div> <div class=\"col-md-12\"> <input class=\"text {0}\" data-val=\"true\" id=\"EntityID\" name=\"EntityID\" type=\"text\" value=\"{1}\"> </div>", inputClass, inputValue);
                    retString = retString + "</div>";
                    i++;
                    continue;
                }                
                switch (prop.PropertyType.Name)
                {
                    case "ButtonRow":
                        var btnRow = (ButtonRow)prop.GetValue(detailHeader);
                        if (btnRow.AssociatedInput == "")
                        {
                            retString = retString + CreateHeaderButtonRow(detailHeader, btnRow);
                            retString = retString + "</div>";
                            i++;                            
                        }
                        continue;
                    case "String":
                    case "Int32":
                        break;
                    case "Boolean":
                        inputType = String.Format("checkbox\" value=\"true\">\r\n<input name=\"{0}\" type=\"hidden", prop.Name);
                        inputClass = "formCheckbox";
                        break;
                    case "DateTime":
                        inputType = "date";
                        break;
                    case "String[]":
                        inputType = "select";
                        break;                    
                    default:
                        break;
                }
                if (inputType == "select")
                {
                    retString = retString + $"<div class=\"col-md-12 \"> <label class=\"headerLabel\" for=\"{prop.Name}\">{GetDisplayName(prop)}</label></div> <div class=\"col-md-12 {btnRowDivClass}\"><select class=\"{inputClass} form-select\" data-val=\"true\" id=\"{prop.Name}\" name=\"{prop.Name}\"><option value>Select a {GetDisplayName(prop)}</option>";
                    foreach (var selectListItem in (String[])inputValue)
                    {
                        retString = retString + String.Format("<option value=\"{0}\">{0}</option>", selectListItem);
                    }
                    retString = retString + $"</select>{btnRowString}</div>";
                }
                else
                {
                    retString = retString + $"<div class=\"col-md-12 \"> <label class=\"headerLabel\" for=\"{prop.Name}\">{GetDisplayName(prop)}</label></div> <div class=\"col-md-12 {btnRowDivClass}\"><input class=\"{inputClass}\" data-val=\"true\" id=\"{prop.Name}\" name=\"{prop.Name}\" type=\"{inputType}\" value=\"{inputValue}\">{btnRowString}</div>";
                }
                retString = retString + "</div> ";
                i++;
            }

            retString = retString + "</div></div></div>";

            return new HtmlString(retString);
        }

        public static string GetDisplayName(PropertyInfo pi)
        {
            var displayName = pi
              .GetCustomAttributes(typeof(DisplayNameAttribute), true)
              .FirstOrDefault() as DisplayNameAttribute;

            if (displayName != null)
                return displayName.DisplayName;

            return pi.Name;
        }

        public static HtmlString SearchForm(this IHtmlHelper helper, SearchBase searchObj)
        {
            var formHeadings = searchObj.Headings.Select(x => x[0]).Distinct().ToList();
            var retString = String.Format("<form action=\"/{0}/Search\" method=\"post\">", searchObj.Type);
            
            foreach (var heading in formHeadings)
            {
                var columnNum = 0;
                var skipNum = 0;                
                var gridNum = 12 / searchObj.FormColumnsPerHeading;
                var headingPropNames = searchObj.Headings.Where(x => x[0] == heading).Select(x => x[1]);
                var searchObjProps = searchObj.GetType().GetProperties();
                var relevantSearchObjProps = searchObjProps.Where(x => headingPropNames.Contains(x.Name));
                var noOfRows = relevantSearchObjProps.Count() / searchObj.FormColumnsPerHeading;

                retString = retString + String.Format("<h6 class=\"borderGroupHeading\">{0}</h6><div class=\"borderGroup row col-md-12\">", heading);                

                while(columnNum < searchObj.FormColumnsPerHeading)
                {
                    retString = retString + String.Format("<div class=\"col-md-{0} col-sm-{0}\">", gridNum);
                    var columnProps = relevantSearchObjProps.Skip(skipNum).Take(noOfRows);
                    retString = retString + CreateFormColumn(searchObj, columnProps);
                    retString = retString + String.Format("</div>");
                    skipNum = skipNum + noOfRows;
                    columnNum++;
                }

                retString = retString + String.Format("</div>");
            }

            return new HtmlString(retString + "<button type=\"submit\" class=\" pushable\"><span class=\"shadow\"></span> <span class=\"edgeSubmitBtn\"></span><span class=\"frontSubmitBtn\">Submit</span></button> </form>");
        }

    

        public static HtmlString CreateFormColumn(IFormBase formObj, IEnumerable<PropertyInfo> props, bool singleButtonForm = false)
        {
            var retString = "";
            var i = 0;
            var btnRows = props.Where(x => x.PropertyType.Name == "ButtonRow");
            var btnRowsList = new List<ButtonRow>();
            foreach (var btnRow in btnRows)
            {
                var btnRowValue = (ButtonRow)btnRow.GetValue(formObj);
                btnRowsList.Add(btnRowValue);
            }
            var inputBtnRows = btnRowsList.Where(x => x.AssociatedInput != "");
            var singleButtonFormNeeded = singleButtonForm && btnRowsList.Count() == 1 && btnRowsList.FirstOrDefault().Buttons.Count() == 1;

            foreach (var prop in props)
            {
                var inputType = "text";
                var propType = prop.PropertyType.Name;
                var inputValue = prop.GetValue(formObj);
                var incValidMessage = true;
                var inputClass = "form-control";
                var assocBtnRow = inputBtnRows.Where(x => x.AssociatedInput == prop.Name);
                var btnRowString = "";
                var btnRowDivClass = "";
                if (assocBtnRow.Any()) {
                    // deal with associated button row
                    btnRowString = CreateButtonRow(formObj, assocBtnRow.FirstOrDefault(), true);
                    btnRowDivClass = "inputWithBtnRow";
                }

                switch (propType)
                {
                    case "ButtonRow":
                        var btnRow = (ButtonRow)prop.GetValue(formObj);
                        if (btnRow.AssociatedInput == "")
                        {
                            retString = retString + CreateButtonRow(formObj, btnRow, false, singleButtonFormNeeded);
                            i++;
                        }
                        continue;
                    case "String":
                    case "Int32":
                        break;
                    case "Boolean":
                        inputType = String.Format("checkbox\" value=\"true\">\r\n<input name=\"{0}\" type=\"hidden", prop.Name);
                        inputValue = "false";
                        incValidMessage = false;
                        inputClass = "formCheckbox";
                        break;
                    case "DateTime":
                        inputType = "date";
                        break;
                    case "String[]":
                        inputType = "select";
                        break;
                    case "IEnumerable`1":
                        try
                        {
                            var inputList = (IEnumerable<IEntityBase>)inputValue;
                            var table = DataTable(inputList, $"{prop.Name}Table", "");
                            retString = retString + String.Format("<div class=\"col-md-12 form-group \"> <label class=\"col-md-4 form-label\">{0}</label></div> <div class=\"col-md-12 form-group \"> <div class=\"col-md-7 form-check-inline detailTable\">{1}</div></div>", GetDisplayName(prop), table);
                        }
                        catch (Exception ex)
                        {
                            break;
                        }
                        continue;
                    default:                
                        break;
                }
                if (inputType == "select")
                {
                    retString = retString + String.Format("<div class=\"col-md-12 form-group \"> <label class=\"col-md-4 form-label\" for=\"{0}\">{1}</label> <div class=\"col-md-7 form-check-inline {2}\"> <select class=\"{3} form-select col-md-9\" data-val=\"true\" data-val-required=\"The {0} field is required\" id=\"{0}\" name=\"{0}\"><option value>Select a {1}</option>", prop.Name, GetDisplayName(prop), btnRowDivClass, inputClass);
                    foreach (var selectListItem in (String[])inputValue)
                    {
                        retString = retString + String.Format("<option value=\"{0}\">{0}</option>", selectListItem);
                    }
                    retString = retString + $"</select>{btnRowString}";
                }
                else
                {
                    retString = retString + String.Format("<div class=\"col-md-12 form-group \"> <label class=\"col-md-4 form-label\" for=\"{0}\">{1}</label> <div class=\"col-md-7 form-check-inline {2}\"> <input class=\"{3} col-md-9\" data-val=\"true\" data-val-required=\"The {0} field is required\" id=\"{0}\" name=\"{0}\" type=\"{4}\" value=\"{5}\">{6}", prop.Name, GetDisplayName(prop), btnRowDivClass, inputClass, inputType, inputValue, btnRowString);
                }

                if (incValidMessage)
                    retString = retString + String.Format("<span class=\"field-validation-valid\" data-valmsg-for=\"{0}\" data-valmsg-replace=\"true\"></span>", prop.Name);

                retString = retString + "</div></div>";
                i++;
            }

            return new HtmlString(retString);
        }
        

        public static string CreateButtonRow(IFormBase formObj, ButtonRow btnRow, bool assocInput = false, bool singleButtonForm = false)
        {
            var retString = "<div class=\"col-md-12 row form-group \">";
            var btnClass = btnRow.ButtonType + "Btn ";
            var divClass = " col-md-2 ";
            var singleBtnRow = false;
            var singleButtonFormClass = "";
            if (assocInput)
            {
                retString = "";
                divClass = " col-md-1 assocInputBtn ";
            }
            else if(btnRow.Buttons.Count() == 1)
            {
                singleBtnRow = true;
                singleButtonFormClass = singleButtonForm ? "singleBtn" : "";
                divClass = singleButtonForm ? " col-md-8 " : divClass;
            }

            foreach (var btn in btnRow.Buttons)
            {
                var btnColour = btn.Color.ToLower();
                var btnName = btn.Name.Replace(" ", "");
                if(singleBtnRow)
                {
                    retString = retString + "<label class=\"col-md-4 form-label\"></label>";
                }
                retString = retString + $"<div class=\"{divClass}\">";
                if (btn.Icon != "")
                {
                    retString = retString + $"<button class=\" pushable{btnClass} {singleButtonFormClass}\" id=\"{btnName}{btnClass}\" type=\"button\" ><span class=\"shadow\"></span> <span class=\"{btnColour}Edge{btnClass} edge{btnClass}\"></span><span class=\"{btnColour}Front{btnClass} front{btnClass}\"><img class=\"iconBtn\" src=\"\\images\\{btn.Icon}.png\"></img>{btn.Text}</span></button>";
                }
                else
                {
                    retString = retString + $"<button class=\" pushable{btnClass} {singleButtonFormClass}\" id=\"{btnName}{btnClass}\" type=\"button\" ><span class=\"shadow\"></span> <span class=\"{btnColour}Edge{btnClass} edge{btnClass}\"></span><span class=\"{btnColour}Front{btnClass} front{btnClass}\">{btn.Text}</span></button>";
                }
                retString = retString + "</div>";
            }
            retString = assocInput ? retString : retString + "</div>";
            return retString;
        }

        public static string CreateHeaderButtonRow(IDetailHeader detailHeader, ButtonRow btnRow, bool assocInput = false)
        {
            var retString = string.Empty;
            var btnClass = btnRow.ButtonType + "Btn ";
            var divClass = " col-md-12 ";
            if (assocInput)
            {
                divClass = " col-md-1 assocInputBtn ";
            }
            foreach (var btn in btnRow.Buttons)
            {
                retString = retString + $"<div class=\"{divClass}\">";
                var btnColour = btn.Color.ToLower();
                var btnName = btn.Name.Replace(" ", "");          
                var btnText = btn.Text;

                if (btn.Icon != "")
                {
                    retString = retString + $"<button class=\"headerBtn {btnColour}HeaderBtn col-md-12\" id=\"{detailHeader.EntityType}{btnName}\" type=\"button\"><span class=\"headerBtnSpan\"><img class=\"iconBtn\" src=\"\\images\\{btn.Icon}.png\"></img>{btn.Text}</span></button>";                    
                }
                else
                {
                    retString = retString + $"<button class=\"headerBtn {btnColour}HeaderBtn col-md-12\" id=\"{detailHeader.EntityType}{btnName}\" type=\"button\"><span class=\"headerBtnSpan\">{btn.Text}</span></button>";
                }
                retString = retString + "</div>";
            }
            return retString;
        }

        public static HtmlString CreateDataTable(this IHtmlHelper helper, IEnumerable<IEntityBase> entities, string tableId, string controllerName)
        {
            return DataTable(entities, tableId, controllerName);
        }

        public static HtmlString DataTable(IEnumerable<IEntityBase> entities, string tableId, string controllerName)
        {
            var retString = String.Format("<table id=\"{0}\" class=\"table table-striped table-bordered\"><thead><tr>", tableId);
            var i = 0;
            var viewBtn = tableId != "" && controllerName != "";

            foreach (var entity in entities)
            {
                var entityProps = entity.GetType().GetProperties();
                if (i == 0)
                {
                    foreach (var prop in entityProps)
                    {
                        if (prop.Name == "State")
                        {
                            continue;
                        }
                        if (prop.Name == "PK")
                        {
                            retString = retString + "<th> </th>";
                            continue;
                        }
                        retString = retString + "<th>" + GetDisplayName(prop) + "</th>";
                    }
                    retString = retString + "</tr></thead><tbody>";
                }
                retString = retString + "<tr>";
                foreach (var prop in entityProps)
                {
                    if (prop.Name == "State")
                    {
                        continue;
                    }
                    if (prop.Name == "PK")
                    {
                        if (viewBtn)
                        {
                            retString = retString + String.Format("<td><button class=\"pushable viewBtn\" id=\"{0}{1}\" type=\"button\"><span class=\"shadow\"></span> <span class=\"edgeViewBtn\"></span><span class=\"frontViewBtn\">View</span></button></td>", controllerName, prop.GetValue(entity));                            
                        }
                        else
                        {
                            retString = retString + "<td></td>";
                        }
                            continue;
                    }
                    retString = retString + "<td>" + prop.GetValue(entity) + "</td>";
                }
                retString = retString + "</tr>";

                i++;
            }
            retString = retString + "</tbody></table>";

            return new HtmlString(retString);
        }

        public static HtmlString EntityDetailNavTabs(this IHtmlHelper helper, IEnumerable<IDetailTabItem> tabItems)
        {
            var retString = "<div class=\"container\"><ul class=\"nav nav-tabs\">";
            var tabContent = "<div class=\"tab-content\">";
            var i = 0;
            foreach(var item in tabItems)
            {
                var activeClass = "";
                var fadeClass = "";                
                if (i == 0)
                {
                    activeClass = "active";
                }
                else
                {
                    fadeClass = "fade";
                }
                retString = retString + String.Format("<li class=\"nav-item detailNavItem\"> <a class=\"nav-link detailNavItemLink {0}\" data-bs-toggle=\"tab\" href=\"#{1}\"><img class=\"iconSmall\" src=\"\\images\\{2}.png\"></img>{1}</a></li>", activeClass, item.PageHeading, item.iconType);

                //this.SearchForm(item);

                tabContent = tabContent + String.Format("<div class=\"tab-pane container {0} {1}\" id=\"{2}\">", activeClass, fadeClass, item.PageHeading);
                // detail form (can contain datatables and buttons)
                tabContent = tabContent + DetailForm(item);

                tabContent = tabContent + "</div>";

                i++;
            }
            tabContent = tabContent + "</div></div>";
            retString = retString + "</ul>" + tabContent;

            return new HtmlString(retString);
        }



        public static HtmlString DetailForm(IDetailTabItem tabItem)
        {
            var formHeadings = tabItem.Headings.Count() > 0 ? tabItem.Headings.Select(x => x[0]).Distinct().ToList() : new List<string>();
            var retString = String.Format("<form action=\"/{0}/Edit\" method=\"post\">", tabItem.Type);
            var headingColumnsGridNum = 12 / tabItem.HeadingsColumnsNo;
            var headingsPerColumn = Math.Ceiling((double)formHeadings.Count() / (double)tabItem.HeadingsColumnsNo);
            var i = 1;
            var headingsColumnsNeeded = tabItem.HeadingsColumnsNo > 1;
            var submitBtn = string.Empty;
            var singleButtonForm = false;
            var objProps = tabItem.GetType().GetProperties();
            var submitBtnNeeded = true;
            var headingsPropsNames = tabItem.Headings.Select(x => x[1]);
            var headingsProps = objProps.Where(x => headingsPropsNames.Contains(x.Name));
            var btnRow = headingsProps.Where(x => x.PropertyType.Name != "ButtonRow");
            if (headingsProps.Where(x => x.PropertyType.Name != "ButtonRow").Count() == 0)
            {
                submitBtnNeeded = false; //only buttons so no need for submit button
                singleButtonForm = tabItem.HeadingsColumnsNo == 1;
            }

            if (headingsColumnsNeeded)
                retString = retString + String.Format("<div class=\"row col-md-12 headingsColumnsRow\">");

            foreach (var heading in formHeadings)
            {
                if (headingsColumnsNeeded && i == 1)
                {
                    retString = retString + String.Format("<div class=\" col-md-{0} col-sm-{0} headingsColumn\">", headingColumnsGridNum);
                }
                var columnNum = 0;
                var skipNum = 0;
                var gridNum = 12 / tabItem.FormColumnsPerHeading;
                var headingPropNames = tabItem.Headings.Where(x => x[0] == heading).Select(x => x[1]);
                var relevantObjProps = objProps.Where(x => headingPropNames.Contains(x.Name));                
                var noOfRows = relevantObjProps.Count() / tabItem.FormColumnsPerHeading; 
                noOfRows = noOfRows == 0 ? 1 : noOfRows; 

                if(heading != "")
                    retString = retString + String.Format("<h6 class=\"borderGroupHeading\">{0}</h6>", heading);

                retString = retString + "<div class=\"borderGroup row col-md-12\">";                

                while (columnNum < tabItem.FormColumnsPerHeading)
                {
                    retString = retString + String.Format("<div class=\"col-md-{0} col-sm-{0}\">", gridNum);
                    var columnProps = relevantObjProps.Skip(skipNum).Take(noOfRows);
                    if(columnProps.Count() == 1 && columnProps.FirstOrDefault().PropertyType.Name == "IEnumerable`1")
                    {
                        var prop = columnProps.FirstOrDefault();
                        var inputValue = prop.GetValue(tabItem);
                        var inputList = (IEnumerable<IEntityBase>)inputValue;
                        retString = retString + " <div class=\"form-check-inline detailTable\">" + DataTable(inputList, $"{prop.Name}Table", "") + "</div>";
                    }
                    else
                    {
                        retString = retString + CreateFormColumn(tabItem, columnProps, singleButtonForm);
                    }                        
                    retString = retString + String.Format("</div>");
                    skipNum = skipNum + noOfRows;
                    columnNum++;
                }

                retString = retString + String.Format("</div>");
                if(headingsColumnsNeeded && i == headingsPerColumn) //were done and need to start new column
                {
                    retString = retString + String.Format("</div>");
                    i = 1; //reset count
                }
                else if (headingsColumnsNeeded && formHeadings.IndexOf(heading) + 1 == formHeadings.Count()) //were done 
                {
                    retString = retString + String.Format("</div>");
                }
                else if(headingsColumnsNeeded) //were not done - increment 
                {
                    i++;
                }
            }
            if (headingsColumnsNeeded)
                retString = retString + String.Format("</div>");

            submitBtn = submitBtnNeeded ? "<button type=\"submit\" class=\"pushable\"><span class=\"shadow\"></span> <span class=\"edgeSubmitBtn\"></span><span class=\"frontSubmitBtn\">Submit</span></button>" : "<div class=\"pushable\"><span></span></div>";
            return new HtmlString(retString + $"{submitBtn}</form>");
        }


    }
}
