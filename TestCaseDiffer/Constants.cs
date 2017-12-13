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
            .tree { background: #fff; padding: 20px; }
			.treeTitle {color: #545e69; font-size: 24px;}
			.treeContent { font-family: 'Lato', arial, sans-serif; }
			.treeContentTitle {
                border-top: 2px solid #c7cdd8; 
                padding: 10px 10px; 
                font-weight: 600; 
                font-size: 18px; 
                transition-duration: 0.3s;
                cursor: pointer; }
			.treeContentTitle:hover {background-color: #c7cdd8;}
			.changesTable {width:100%; display:none;}
            .tableRow {}
            .tableCell {padding: 5px; text-align: left; vertical-align: top;}
			.stepIdCell {width:50px; }			
			.deletedText {background-color: Salmon;}
			.addedText {background-color: LightGreen;}";

    }
}
