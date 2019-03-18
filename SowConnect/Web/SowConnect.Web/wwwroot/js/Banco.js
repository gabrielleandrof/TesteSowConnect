$(document).ready(function () {

    //var rootUri = "http://localhost:56672/api/"
    var rootUri = "https://localhost:44360/api/"

    var grid = $('#grid').grid({
        dataSource: rootUri + 'Bancos/',
        columns: [
            { field: 'id' },
            { field: 'nomeInstituicao', title: "Nome" },
            { field: 'codigoInstituicao', title: 'Código' }
        ]
    });

    $("#btnSalvar").click(function () {
        var nome = $("#txtNomeInstituicao").val().trim();
        var codigo = $("#txtCodigoInstituicao").val().trim();

        if (nome == "") {
            alert("Preencha o nome");
            return;
        }
        if (codigo == "") {
            alert("Preencha o código");
            return;
        }

        var banco = {
            NomeInstituicao: nome,
            CodigoInstituicao: codigo
        };

        $.ajax({
            type: "POST",
            contentType: 'application/json',
            url: rootUri + "Bancos/",
            async: false,
            dataType: "json",
            data: JSON.stringify(banco),
            success: function (r) {
                $("#txtNomeInstituicao").val("");
                $("#txtCodigoInstituicao").val("");
                grid.reload();
            },
            error: function (e) { alert("algo deu errado"); }
        });

    });

});