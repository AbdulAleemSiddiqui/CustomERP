function Typable_Dropdown( a)
{
    debugger;
    $('select[name='+a+'_Name]').change(function () {
        $('input[name=other]').val($(this).val());
       


    });
    $('#' + a + '_Name').on('keydown', function (e) {
        debugger
        if (e.keyCode === 9) {

            var input = $(this)
            var list = $("#" + input.attr("list"))
            var options = $($(list).prop("options"))
            written = $('#' + a + '_Name').val();
       
            input.val(options.eq(0).val())

        }
    });
   
    $('#' + a + '_Name').on('change', function () {
    
        var value = $('#' + a + '_Name').val();
        var name = "#" + a + "_List";
        name = name + " option[value='" + value+ "']";
        value = $(name).data('id');
        debugger
        $("[name='" + a + "_ID']").val(value);
    });
    
}
function DropDown_Fill(a)
{
    var id = $("#" + a + "_ID").val();
    var name = "#" + a + "_List";
    name = name + " option[id='" + id + "']";

    var value = $(name).val();
    $("#"+a+"_Name").val(value);
}