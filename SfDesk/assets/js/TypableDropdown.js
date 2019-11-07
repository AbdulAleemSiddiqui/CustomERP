function Typable_Dropdown( a)
{
   
    var s = $('#' + a + '_List').find('option').length;
    if (s == 0)
    {
        $('#' + a + '_Name').val("No Data");
        $('#' + a + '_Name').prop('disabled', true);
    }
    $('select[name='+a+'_Name]').change(function () {
        $('input[name=other]').val($(this).val());
    });
    $('#' + a + '_Name').on('keydown', function (e) {
        if (e.keyCode === 9) {
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
        if (typeof value === "undefined") {
            $('#' + a + '_Name').val("");
            alert("Not Match");
        }
        $("[name='" + a + "_ID']").val(value);
    });
    
}
function DropDown_Fill(a)
{
    var id = $("#" + a + "_ID").val();
    var name = "#" + a + "_List";
    console.log(name)
    var dd = $(name);
    name = name + " option[id='" + id + "']";
    var de= $(name);

    var value = $(name).val();
    $("#"+a+"_Name").val(value);
}
