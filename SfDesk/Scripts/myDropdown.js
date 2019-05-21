
     function valueSelect(index, input) {
        var input = $('#' + input)
        var list = $("#" + input.attr("list"))
        var options = $($(list).prop("options"))
        input.val(options.eq(index).val())
 };//your stuff

   
   
   