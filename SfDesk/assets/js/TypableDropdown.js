function Typable_Dropdown( a)
{
    $('select[name='+a+'_Name]').change(function () {
        $('input[name=other]').val($(this).val());
    });
    $('#' + a + '_Name').on('change', function () {
        var id = $("option").filter("[value='" + $('#' + a + '_Name').val() + "']").data("id");
        $("[name='"+a+"_ID']").val(id);
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