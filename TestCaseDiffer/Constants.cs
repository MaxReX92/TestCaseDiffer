using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCaseDiffer
{
	public static class Constants
	{
        public const string JavaScript = @"var lastItem;				
				function toggle(elementId) {		 		
					var ele = document.getElementById(elementId);	
					if(ele.style.display == ""inline-table"") {
    					ele.style.display = ""none"";
  					}
					else {
						ele.style.display = ""inline-table"";	
						if (lastItem != null)
						   lastItem.style.display = ""none"";								
					}			
					
					if (lastItem == ele)
					   lastItem = null;
					else
						lastItem = ele;	
				}";

        public const string Style = @".tree {padding-left: 3px; padding-bottom: 3px;}
			.treeTitle {font-family: Verdana; background-color: lightblue; padding:4px; border: solid 1px; border-top-left-radius:3px; border-top-right-radius: 6px; font-weight: bold;}
			.changes {border-bottom:solid 1px; border-left:solid 1px; border-right:solid 1px; border-bottom-left-radius:3px; border-bottom-right-radius:3px;}
			.changeTitle { line-height:30px; padding: 0 10px; border-bottom:dotted 1px;}
			.changeTitle:hover { background-color: silver; cursor: pointer;}
			.changeTable {width:100%; padding: 5px; background-color:lightgrey; display:none;}
			.changeDiff {float:left; font-size: 12px; padding: 5px;}";

    }
}
