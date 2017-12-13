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

        public const string Style = @"
            .mainPage { background-color: #DAE3E7; }
            .tree { background: #fff; padding: 30px; }
			.treeTitle {color: #545e69; font-size: 24px;}
			.changes { font-family: 'Lato', arial, sans-serif; }
			.changeTitle {border-top: 1px solid #c7cdd8; display: block; padding: 18px 30px;    color: #333333;    font-weight: 600;    font-size: 18px;}
			.changeTitle:hover {background-color: silver;}
			.changeTable {width:100%; display:none; word-wrap:break-word;}
			.changeDiff {}
			.stepIdColumn {width:50px;}			
			.deletedText {background-color: Salmon;}
			.addedText {background-color: LightGreen;}";

    }
}
