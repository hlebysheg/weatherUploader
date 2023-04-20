using System.Text;
using System.Web.Mvc;
using weatherUploader.Models.DTO;
namespace weatherUploader.Views.helper
{
	public static class PagingHelpers
	{
		//public static System.Web.Mvc.MvcHtmlString PageLinks(this System.Web.Mvc.HtmlHelper html,
		//	TableDTO pageInfo, Func<int, string> pageUrl)
		//{
		//	StringBuilder result = new StringBuilder();
		//	for (int i = 1; i <= pageInfo.PageTotal; i++)
		//	{
  //              System.Web.Mvc.TagBuilder tag = new System.Web.Mvc.TagBuilder("a");
		//		tag.MergeAttribute("href", pageUrl(i));
		//		tag.InnerHtml = i.ToString();
		//		// если текущая страница, то выделяем ее,
		//		// например, добавляя класс
		//		if (i == pageInfo.PageTotal)
		//		{
		//			tag.AddCssClass("selected");
		//			tag.AddCssClass("btn-primary");
		//		}
		//		tag.AddCssClass("btn btn-default");
		//		result.Append(tag.ToString());
		//	}
		//	return System.Web.Mvc.MvcHtmlString.Create(result);
		//}
	}
}
