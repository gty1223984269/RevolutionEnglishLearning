 var Tool={};
 Tool.url="http://localhost:62861/api/WordRoot/AllWordRoots?pageNumber=";
 Tool.address="http://localhost:62861/api/WordRoot/AllRelatedWordByRootId?wordRootId=";
function createContent(word,wordmeaning,id)
 {	
	$("#WordContent").append("<div class='boxword'><h3 class='bgWhite'><a href=detail.html?wordRootId="+id+"&word="+word+">"+word+"</a></h3><h4 class='textLeft'>汉语释义:</h4><div class='boxContent'>  <span class='boxContentspan'>"+wordmeaning+"</span><span style='display:none' id='wordId'>"+id+"</span></div>");
	 
 }
Tool.sendGetRequest=function(index)
 {
	 $.get(Tool.url+index,function(data,status){
		 $("#WordContent").empty();
		 $("#wordCount").text("");
		 $("#wordCount").append("词根总数"+data.pageCount);
		   
			 $.each(data,function(index,value){
				 
				 $.each(value,function(index,value)
				 {
					 console.log(value);
					createContent(value.word,value.chineseMeaning,value.id);
					 
				 })
					  });
	 	});		
	 
 }
 
 
 function createContentDetail(word,chineseMeaning,id,rememberLogic,wordroot)
  {	
		// var str="<span style='color:red'>"+word+"</span><span></span>";
 	$("#WordContent").append("<div class='boxword extraHeight'><h3 class='bgWhite'>"+word+"</h3><h4 class='textLeft'>汉语释义:</h4><div class='boxContent reduceHeight'> <span class='boxContentspan'>"+chineseMeaning+"</span></div><h4 class='textLeft'>记忆逻辑:</h4><div class='boxContent'> <span class='boxContentspan'>"+rememberLogic+"</span></div><div></div></div>");
 	 
  }
 
Tool.sendGetRequestForAllWords=function(wordId,wordroot)
  {
		
		$("#wordRootSB").empty();
		$("#wordRootSB").text("");
		$("#wordRootSB").append("词根:"+wordroot);
 	 $.get(Tool.address+wordId,function(data,status){
 			 $.each(data,function(index,value){
 					 createContentDetail(value.word,value.chineseMeaning,value.id,value.rememberLogic,wordroot);
 					  });
 	 		
 	 
  });
 }
 
 
 Tool.getAddress=function GetRequest() {
            var url = location.search; //获取url中"?"符后的字串 
          url= decodeURI(url);
            var theRequest = new Object();
            if (url.indexOf("?") != -1) {
                var str = url.substr(1);
                strs = str.split("&");
                for (var i = 0; i < strs.length; i++) {
                    theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
                }
            }
            return theRequest;
        }