 var Tool={};
 Tool.url="http://localhost:62861/api/WordRoot/AllWordRoots?pageNumber=1";
 
function createContent(word,wordmeaning)
 {
	$("#WordContent").append("<div class='boxword'><h3 class='bgWhite'>"+word+"</h3><h4 class='textLeft'>汉语释义:</h4><div class='boxContent'>  <span class='boxContentspan'>"+wordmeaning+"</span></div></div>");
	 
 }
Tool.sendGetRequest=function()
 {
	 $.get(Tool.url,function(data,status){
	 		console.log(data);
			 $.each(data,function(index,value){
				 
				 $.each(value,function(index,value)
				 {
					 console.log(value);
				var word=value.word;
				var meaning=value.chineseMeaning;
				createContent(word,meaning);
					 
				 })
					  });
	 	});		
	 
 }
 