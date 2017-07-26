//Переменная с id 
window.CurrentId = 0;

$(document).ready(function () {
    $(".btn.btn-success.show-edit").click(function () {
        CurrentId = $(this).val();
        $(".form-control.NewFirstName").val($("#FirstName-" + CurrentId).text());
        $(".form-control.NewSecondName").val($("#SecondName-" + CurrentId).text());
        $(".form-control.NewPatronymic").val($("#Patronymic-" + CurrentId).text());
        $(".form-control.NewPosition").val($("#Position-" + CurrentId).text());
    });
});

$(document).ready(function () {
    $(".btn.btn-success.goedit").click(function () {
        $(".form-control.editId").val(CurrentId);
    });
});


//Очистка формы после выполения запроса на добавление сотрудника
//и сворачивание
function ClearAddForm() {
    $('#Addform')[0].reset();
    //$("#forms").slideToggle("slow");
}


$(document).ready(function () {
    $("#test").click(function () {
        $("#forms").slideToggle("slow");
    });
});

$(document).ready(function () {
    $("#add-div").click(function () {
        $("#add-division").slideToggle("slow");
    });
});

$(document).ready(function () {
    $(".form-control.modal-edit-form").change(function () {
        $.get(
            "Home/CurentDivision",
            {
                Type: $(this).val(),
            },
            success
        );
        $(".form-control.modal-edit-form-select").empty();
        function success(data) {
            $.each(data, function (key, val) {
                $(".form-control.modal-edit-form-select").append('<option value="' + val.DivisionName + '">' + val.DivisionName + '</option>');
            });
        }
    });
})

$(document).ready(function () {
    $(".form-control.main-add-form").change(function () {
        $.get(
            "Home/CurentDivision",
            {
                Type: $(this).val(),
            },
            successAdd
        );
        $(".form-control.main-add-form-select").empty();
        function successAdd(data) {
            $.each(data, function (key, val) {
                $(".form-control.main-add-form-select").append('<option value="' + val.DivisionName + '">' + val.DivisionName + '</option>');
            });
        }
    });
})