// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function UpdateSalesOrders() {
    var forms = document.getElementsByClassName("UpdateSO");
    Array.prototype.forEach.call(forms, function (form) {
        console.log('/Sheets/UpdateDelayedSO' + ' ? ' + $(form).serialize());
        $.ajax({
            url: '/Sheets/UpdateDelayedSO' + '?' + $(form).serialize(),
            type: 'GET',
            contentType: "application/json",
            success: function (result) {
                document.getElementById("Complete" + result).innerHTML = "Успешно";
            },
            fail: function () {
                document.getElementById("Complete" + result).innerHTML = 'Неудачно';
            }
        });
    });
}

function LoadPriceSubmit() {
    var j = 0;
    $(".NewPricesToLoadIPO").each(function (form) {
        if (form.NewPrice.value != "") {
            $("#numberIPOsLoadPrice").value += form.IPONumber.value + '\n';
            $("#lineNumbersLoadPrice").value += form.LineNumber.value + '\n';
            $("#itemNumbersLoadPrice").value += form.ItemNumber.value + '\n';
            $("#newPricesLoadPrice").value += form.NewPrice.value + '\n';
        }
        $("#LoadPrices").submit;
    });
}

function UploadFromClipboardTo(items) {
    navigator.clipboard.readText().then(Text => {
        console.log(Text);
        var Rows = Text.split('\r\n');
        Rows.forEach(function (row) {
            var elems = row.split('\t');
            console.log(items);
            for (var i = 0; i < items.length; i++) {
                document.getElementById(items[i]).innerHTML += elems[i] + '\n';
            }
        });
    }).catch(err => {
        console.error("Failed to read clipboard contents: ", err);
    });
}

function SubmitPartial(form) {
    form.partial.value = 1;
    ShowLoading();
    $("#TargetTable").load(form.action + '?' + $(form).serialize(), function () { HideLoading() });
}

function ShowLoading() {
    document.getElementById('TargetTable').innerHTML = "";
    document.getElementById('LoadingModal').style.display = 'block';
}

function HideLoading() {
    document.getElementById('LoadingModal').style.display = 'none';
}

function LoadToTargetTable(action) {
    ShowLoading();
    $('#TargetTable').load(action, function () { HideLoading() });
}

function SubmitExcel(form) {
    form.partial.value = 0;
    ShowLoading();
    
    $.ajax({
        url: form.action + '?' + $(form).serialize(),
        method: 'GET',
        success: function (data) {
            HideLoading();
            window.open(form.action + '?' + $(form).serialize())
        },
        error: function () {
            HideLoading();
            alert('Загрузить файл не удалось! Обратитесь в ОА с подробным описанием проблемы.');
        }
    });
    //form.submit();
}

