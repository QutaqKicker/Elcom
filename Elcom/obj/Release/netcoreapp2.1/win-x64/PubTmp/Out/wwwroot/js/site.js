// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
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