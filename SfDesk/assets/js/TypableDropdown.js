﻿function Typable_Dropdown( a)
{
    $('select[name='+a+'_Name]').change(function () {
        $('input[name=other]').val($(this).val());
    });
    $('#' + a + '_Name').on('keydown', function (e) {
        if (e.keyCode === 9) {
            debugger;
            var s = $(this).val();
            var list=$('#' + a + '_List').find('option');
            for (var i = 0; i < list.length; i++) {
                var z = $(list[i]).val();
                if (z.toLowerCase().indexOf(s.toLowerCase()) != -1) {
                    $(this).val($(list[i]).val());
                    break;
                }
              
            }
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
