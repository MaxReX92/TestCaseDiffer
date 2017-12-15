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
				var lastTitle;
				function toggle(elementId, titleId) {		 		
					var ele = document.getElementById(elementId);	
					var title = document.getElementById(titleId);
					
					if(ele.style.display == ""inline-table"") {
    					ele.style.display = ""none"";
						title.removeAttribute(""style"");
  					}
					else {
						ele.style.display = ""inline-table"";	
						title.style.background = ""#99d6ff"";
						if (lastItem != null){
							lastItem.style.display = ""none"";
							lastTitle.removeAttribute(""style"");
						}
					}			
					
					if (lastItem == ele){
						lastItem = null;
						lastTitle = null;
					}
					else{
						lastItem = ele;	
						lastTitle = title;
					}
				}";

		public const string Style = @"
            .mainPage { background-color: #DAE3E7; }
            .tree { background: #fff; padding: 20px; }
			.treeTitle {color: #545e69; font-size: 24px;}
			.treeContent { font-family: 'Lato', arial, sans-serif; font-size: 14px; border-bottom: 2px solid #c7cdd8;}
			.treeContentTitle {
                border-top: 2px solid #c7cdd8;
				border-left: 2px solid #c7cdd8;
				border-right: 2px solid #c7cdd8;				
                padding: 10px 10px; 
                font-weight: 600; 
                font-size: 16px; 
                transition-duration: 0.3s;
                cursor: pointer;
				}
			.treeContentTitle:hover {background-color: #eaf7ff;}
			.changesTable {
				width:100%; 
				display:none;
				border-collapse:collapse;
				background-color:#eaf7ff;
				border: 2px solid #c7cdd8;
				table-layout: fixed;
				word-wrap: break-word;
				}
            .tableRow {border: 2px solid #c7cdd8;}
            .tableCell {
				padding-top:15px; 
				padding-bottom:15px; 
				padding-left:5px; 
				text-align:left; 
				vertical-align:top; border: 
				1px solid #c7cdd8;
				width:40%;}
			.stepIdCell {padding:5px; text-align:center; width:50px; border: 1px solid #c7cdd8; }			
			.deletedText {background-color: Salmon;}
			.addedText {background-color: LightGreen;}";

    }
}
